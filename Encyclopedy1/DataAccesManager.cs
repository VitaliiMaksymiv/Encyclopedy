namespace Encyclopedy1
{
    using System;
    using System.Linq;
    using Encyclopedy1.Console;
    using Encyclopedy1.Models;
    using Encyclopedy1.Repository;

    public class DataAccesManager
    {
        private readonly UnitOfWork _unitOfWork;

        public DataAccesManager()
        {
            _unitOfWork = new UnitOfWork();
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
            var hashManager = new HashManager();
            _unitOfWork.Users.Create(new User { Login = login, Password = hashManager.HashPassword(password), Name = name, Surname = surname, Email = email, Editnum = 0 });
            _unitOfWork.Save();
        }

        /// <summary>
        /// Verifies whether the entered fields are not empty, whether such a user is in the database and whether the password is correct.
        /// If all the conditions are fulfilled - log in to the system.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void Login(string login, string password)
        {
            if (login == string.Empty || password == string.Empty)
            {
                Output.WriteLine(ConsoleColor.Red, "Should not be empty lines!");
            }
            else
            {
                var user = _unitOfWork.Users.Get(login);
                if (user != null)
                {
                    var hashManager = new HashManager();
                    if (!hashManager.VerifyHashedPassword(user.Password, password))
                    {
                        Output.WriteLine(ConsoleColor.Red, "Incorrect Password");
                    }
                    else
                    {
                        var loginUser = AuthenticationProvider.GetInstance();
                        loginUser.LoggedUser = user;
                        Output.WriteLine(ConsoleColor.Green, "You are logged in!");
                    }
                }
                else
                {
                    Output.WriteLine(ConsoleColor.Red, "LoggedUser Not Found!");
                }
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
            _unitOfWork.Articles.Create(new Article { DisciplineId = GetOrAddDiscipline(branch, subbranch), Title = title, Intro = intro, Content = content, Main = main, Version = 1, Lasteditor = userLogin });
            _unitOfWork.Save();
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
            var editableArticle = _unitOfWork.Articles.Get(articleId);
            var editor = _unitOfWork.Users.Get(userLogin);
            var editableProperty = typeof(Article).GetProperty(editable);
            _unitOfWork.Edits.Create(new Edit
            {
                    ArticleId = articleId,
                    UserId = userLogin,
                    Editable = editable,
                    Oldtext = editableProperty.GetValue(editableArticle, null).ToString(),
                    Oldversion = editableArticle.Version,
                    EditDate = DateTime.Now,
            });
            editableProperty.SetValue(editableArticle, newversion);
            editableArticle.Version++;
            editableArticle.Lasteditor = userLogin;
            _unitOfWork.Articles.Update(editableArticle);
            editor.Editnum++;
            _unitOfWork.Users.Update(editor);
            _unitOfWork.Save();
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
                _unitOfWork.Disciplines.Create(new Discipline { Branch = branch, Subbranch = subbranch });
                _unitOfWork.Save();
                id = GetDisciplineId(branch, subbranch);
            }

            return (int)id;
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
            var foundedId = _unitOfWork.Disciplines.GetAll().SingleOrDefault(discipline => (discipline.Branch == branch && discipline.Subbranch == subbranch))?.Id;
            return foundedId;
        }
    }
}