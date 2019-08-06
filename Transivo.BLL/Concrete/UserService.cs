using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Transivo.BLL.Abstract;
using Transivo.DAL.Abstract;
using Transivo.Model.Models;

namespace Transivo.BLL.Concrete
{
    public class UserService : IUserService
    {
        IUserDAL _userDAL;

        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool ActivateUser(User user)
        {
            user.IsActive = true;
            return Update(user);
        }

        public bool Add(User model)
        {
            try
            {
                //    CheckPassword(model.Password);
                CheckMail(model.EMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _userDAL.Add(model) > 0;
        }

        public bool Delete(User model)
        {
            return _userDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            User user = _userDAL.Get(a => a.ID == modelID);
            return _userDAL.Delete(user) > 0;
        }

        public User Get(int modelID)
        {
            return _userDAL.Get(a => a.ID == modelID);
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll().ToList();
        }

        public User GetUserByCode(Guid code)
        {
            return _userDAL.Get(a => a.ActivationCode == code);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _userDAL.Get(a => a.UserName == userName && a.Password == password);
        }

        public bool Update(User model)
        {
            return _userDAL.Update(model) > 0;
        }

        public bool Insert(User model)
        {
            try
            {
                CheckPassword(model.Password);
                CheckMail(model.EMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _userDAL.Add(model) > 0;
        }

        void CheckPassword(string password)
        {
            string numbers = "0123456789";
            int numberCount = 0;

            if (password.Length < 8 || password.Length > 16)
            {
                throw new Exception("Şifre uzunluğu 8 ile 16 karakter arasında olmalıdır!");
            }
            else
            {
                foreach (char item in password)
                {
                    if (numbers.Contains(item))
                    {
                        numberCount++;
                    }
                }
                if (numberCount < 3)
                {
                    throw new Exception("Şifreniz en az 3 rakam içermelidir!");
                }
            }
        }

        void CheckMail(string mail)
        {
            try
            {
                MailAddress checkAddress = new MailAddress(mail);
            }
            catch
            {
                throw new Exception("Mail adresi uygun formatta değildir!");
            }
        }

        public User GetUserByEmail(string email)
        {
            return _userDAL.GetAll(a => a.EMail == email).SingleOrDefault();
        }

    }
}
