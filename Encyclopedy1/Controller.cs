using System;

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
            unitOfWork.Users.Create(new User {Login = login, Password = EncodePasswordToBase64(password), Name = name, Surname = surname, Email = email, Editnum = 0});
            unitOfWork.Save();
        }

        public static void Login(string login, string password) //перевіряє чи є такий користувач в бд, правильність паролю і логіниться
        {
            
        }
        public static void CreateArticle(string branch, string subbranch, string title, string intro, string content, string main)
        {
            
        }

        private static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        private static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

    }
}