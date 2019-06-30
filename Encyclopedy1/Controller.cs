using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Encyclopedy
{

    public static class Controller
    {
        static UnitOfWork unitOfWork;
        static Controller()
        {
            unitOfWork = new UnitOfWork();
        }

        public static void AddUser(string login, string password, string name, string surname, string email)
        {
            unitOfWork.Users.Create(new User {Login = login, Password = HashPassword(password), Name = name, Surname = surname, Email = email, Editnum = 0});
            unitOfWork.Save();
        }

        public static void Login(string login, string password) //перевіряє чи є такий користувач в бд, правильність паролю і логіниться
        {
            if (login == "" || password == "")
            {
                Output.WriteLine(ConsoleColor.Red, "Should not be empty lines!");
            }
            else
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                User user = unitOfWork.Users.Get(login);
                if (user != null)
                {
                    if (!Controller.VerifyHashedPassword(user.Password, password))
                        Output.WriteLine(ConsoleColor.Red, "Incorrect Password");
                    else
                    {
                        LoginedUser luser = LoginedUser.GetInstance();
                        luser.User = user;
                        Output.WriteLine(ConsoleColor.Green, "You are logged in!");
                    }
                }
                else
                    Output.WriteLine(ConsoleColor.Red, "User Not Found!");

            }
        }
        public static void CreateArticle(string branch, string subbranch, string title, string intro, string content, string main, string userLogin)
        {
            UnitOfWork db = new UnitOfWork();
            db.Articles.Create(new Article(){DisciplineId = GetOrAddDiscipline(branch,subbranch), Title = title, Intro = intro, Content = content, Main = main, Version = 1, Lasteditor = userLogin});
            db.Save();
        }

        public static void MakeEdit(int articleId, string userLogin, string editable, string newversion)
        {
            UnitOfWork db = new UnitOfWork();
            var editableArticle = db.Articles.Get(articleId);
            var editor = db.Users.Get(userLogin);
            var editableProperty = typeof(Article).GetProperty(editable);
            db.Edits.Create(new Edit()
                {
                    ArticleId = articleId,
                    UserId = userLogin,
                    Editable = editable,
                    Oldtext = editableProperty.GetValue(editableArticle,null).ToString(),
                    Oldversion = editableArticle.Version,
                    EditDate = DateTime.Now
                });
            editableProperty.SetValue(editableArticle,newversion);
            editableArticle.Version++;
            editableArticle.Lasteditor = userLogin;
            db.Articles.Update(editableArticle);
            editor.Editnum++;
            db.Users.Update(editor);
            db.Save();
        }

        public static int? GetDisciplineId(string branch, string subbranch)
        {
            UnitOfWork db = new UnitOfWork();
            var foundedId = db.Disciplines.GetAll().SingleOrDefault(discipline => (discipline.Branch == branch && discipline.Subbranch == subbranch))?.Id ;
            return foundedId;
        }

        public static int GetOrAddDiscipline(string branch, string subbranch)
        {
            var id = GetDisciplineId(branch, subbranch);
            if (id == null)
            {
                var db = new UnitOfWork();
                db.Disciplines.Create(new Discipline {Branch = branch, Subbranch = subbranch});
                db.Save();   
                id = GetDisciplineId(branch, subbranch);
            }
            return (int)id;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

    }
}