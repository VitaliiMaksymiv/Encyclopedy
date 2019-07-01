using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Encyclopedy
{

    public class DataAccesManager
    {
        public UnitOfWork unitOfWork;
        public DataAccesManager()
        {
            unitOfWork = new UnitOfWork();
        }
        /// <summary>
        /// Add user to the database.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="email"></param>
        public void AddUser(string login, string password, string name, string surname, string email)
        {
            HashManager hashManager = new HashManager();
            unitOfWork.Users.Create(new User {Login = login, Password = hashManager.HashPassword(password), Name = name, Surname = surname, Email = email, Editnum = 0});
            unitOfWork.Save();
        }
        /// <summary>
        /// Verifies whether the entered fields are not empty, whether such a user is in the database and whether the password is correct.
        /// If all the conditions are fulfilled - log in to the system.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void Login(string login, string password)
        {
            if (login == "" || password == "")
            {
                Output.WriteLine(ConsoleColor.Red, "Should not be empty lines!");
            }
            else
            {
                User user = unitOfWork.Users.Get(login);
                if (user != null)
                {
                    HashManager hashManager = new HashManager();
                    if (!hashManager.VerifyHashedPassword(user.Password, password))
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
        /// <summary>
        /// Add article to the database.
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="subbranch"></param>
        /// <param name="title"></param>
        /// <param name="intro"></param>
        /// <param name="content"></param>
        /// <param name="main"></param>
        /// <param name="userLogin"></param>
        public void CreateArticle(string branch, string subbranch, string title, string intro, string content, string main, string userLogin)
        {
            unitOfWork.Articles.Create(new Article(){DisciplineId = GetOrAddDiscipline(branch,subbranch), Title = title, Intro = intro, Content = content, Main = main, Version = 1, Lasteditor = userLogin});
            unitOfWork.Save();
        }
        /// <summary>
        /// Edits an article, as well as all related tables in the database.
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="userLogin"></param>
        /// <param name="editable"></param>
        /// <param name="newversion"></param>
        public void MakeEdit(int articleId, string userLogin, string editable, string newversion)
        {
            var editableArticle = unitOfWork.Articles.Get(articleId);
            var editor = unitOfWork.Users.Get(userLogin);
            var editableProperty = typeof(Article).GetProperty(editable);
            unitOfWork.Edits.Create(new Edit()
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
            unitOfWork.Articles.Update(editableArticle);
            editor.Editnum++;
            unitOfWork.Users.Update(editor);
            unitOfWork.Save();
        }
        /// <summary>
        /// Returns the ID of a discipline in its branch and sub-branch.
        /// If there is no such discipline - returns NULL.
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="subbranch"></param>
        /// <returns></returns>
        private int? GetDisciplineId(string branch, string subbranch)
        {
            var foundedId = unitOfWork.Disciplines.GetAll().SingleOrDefault(discipline => (discipline.Branch == branch && discipline.Subbranch == subbranch))?.Id ;
            return foundedId;
        }
        /// <summary>
        /// Returns the ID of a discipline in its branch and sub-branch.
        /// If there is no such discipline, then it adds to the database and returns its newly created ID.
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="subbranch"></param>
        /// <returns></returns>
        public int GetOrAddDiscipline(string branch, string subbranch)
        {
            var id = GetDisciplineId(branch, subbranch);
            if (id == null)
            {
                unitOfWork.Disciplines.Create(new Discipline {Branch = branch, Subbranch = subbranch});
                unitOfWork.Save();   
                id = GetDisciplineId(branch, subbranch);
            }
            return (int)id;
        }

    }
}