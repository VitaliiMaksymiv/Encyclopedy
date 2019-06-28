using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Encyclopedy
{
    public class Start
    {
        static void Main(string[] args)
        {
            //using (var context = new EncyclopedyContext())
            //{
            //    //var commandText = "INSERT INTO dbo.Disciplines(Branch, Subbranch)VALUES('Space', 'Planets'),('Space', 'Stars'),('Space', 'Galaxy'),('Biology', 'Zoology'),('Biology', 'Anatomy'),('Biology', 'Botanica'),('Culture', 'Architecture'),('Culture', 'Arts'),('Technics', 'Devices'),('History', 'Events'),('History', 'Personalities'); ";
            //    //var commandText1 =
            //        "INSERT INTO users (Login, Password, Name, Surname, Email, Editnum) VALUES ('aa', 'AJYxsRxe73/xXWsmrf9Jz1HHZxcq53AxnUBWTWPZ+U/kLLQ65MXkK73YUK4cWK4fvw==', 'Ann', 'Ivanova', 'aa@gmail.com', 1),('bb', 'AJX/J7PIsfCEH8YhCGAb4A1aZz6PxfqIB4FaFGX+4d7J1uqQ92uSnR4L0qrF/6uq+Q==', 'Ann', 'Petrova', 'bb@gmail.com', 2),('cc', 'AD+QOZALwEfrfv46yeh5Cs50hwwAUA4rl+50VER/MiGVpOL8XUirHYcNBDHFXkNVlQ==', 'Calvin', 'Harris', 'cc@gmail.com', 1),('dd', 'ABponly5vmztZ6g/yP/v0voYoBu8Twm0i44p6SxXQNiVeK6AfHAK2xRKrolIuduQNA==', 'Denis', 'Dan', 'dd@gmail.com', 0),('ee', 'ANq6oL71UFkz5coqq5rpb04vqctgl91f0hYewhOcCJI/7R9KJmz5F6H6ha45fSIE+A==', 'John', 'Wok', 'ee@gmail.com', 1),('ff', 'ALfXJ/3xy5w7ZnbbE+9zvGH/nryDbGRSCRc2kw6G9ZN04qd8WbP48QFcsc0VOsoU0Q==', 'Fedir', 'Ivanov', 'ff@gmail.com', 0),('gg', 'AGzUlCT0mFGkxPtKnGLVSFjsS25FGdhrx8S69Wk1KA5FwNqNsXAOSinfwpoUws77PA==', 'George', 'Dan', 'gg@gmail.com', 1),('hh', 'AEBpqxmdOZR9g1dHOYhsknof8b3mblzCDJmXh5lTPV+uhbthR4dbh2eqfjopZTZmZg==', 'Ham', 'Wok', 'hh@gmail.com', 1),('ii', 'ALmemLYYpsh7Z69prL6gr54ZZxoiWt0QQtjoBEhmI6TSI7pywRy8R9VTMJ+tAZ2tnA==', 'John', 'Deer', 'ii@gmail.com', 1),('jj', 'AOeRRe+EMv6bVHWlT74GoB/IY/wFNui63dAjzNdHzcSRnJrdJS7VGA8FVlqGYYe37Q==', 'John', 'Deer', 'jj@gmail.com', 0); ";
            //    //var name = new SqlParameter("@CategoryName", "Test");
            //    context.Database.ExecuteSqlCommand(commandText1);
            //}
            Console.WriteLine("ENCYCLOPEDY 1.0");
            new DemoProgram().Run();
            //string[] strings = new string[]{"aa1234","bb1234","cc1234","dd1234","ee1234", "ff1234", "gg1234","hh1234","ii1234", "jj1234"};
            //foreach (var VARIABLE in strings)
            //{
            //UnitOfWork db = new UnitOfWork();
            //Type myType = typeof(Article);
            //PropertyInfo[] myField = myType.GetProperties();
            //for (int i = 0; i < myField.Length; i++)
            //{
            //        Console.WriteLine(myField[5].GetValue(db.Articles.Get(1), null));
            //}
            //Controller.MakeEdit(3,"ff", "Title", "Horses");

            //Console.WriteLine(db.Articles.Get(1).(myField[4]));
            //}
            //Console.WriteLine(db.Disciplines.Get(db.Articles.GetAll().FirstOrDefault().DisciplineId).Branch);

            Console.ReadKey();

        }
    }
}