using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.BLL.Abstract;
using Transivo.DAL.Abstract;
using Transivo.Model.Models;

namespace Transivo.BLL.Concrete
{
    public class MessageService : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageService(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public bool Add(Message model)
        {
            return _messageDAL.Add(model) > 0;
        }

        public bool Delete(Message model)
        {
            return _messageDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Message message = _messageDAL.Get(a => a.ID == modelID);
            return _messageDAL.Delete(message) > 0;
        }

        public Message Get(int modelID)
        {
            return _messageDAL.Get(a => a.ID == modelID);
        }

        public List<Message> GetAll()
        { 
            return _messageDAL.GetAll().ToList();
        }

        public List<Message> GetByID(int id)
        {
            return _messageDAL.GetAll(a => a.CompanyID == id).ToList();
        }

        public List<Message> GetMessagesByDate(int companyID, DateTime startDate, DateTime endDate)
        {
            List<Message> AllMessages = _messageDAL.GetAll(a=>a.CompanyID==companyID).ToList();
            List<Message> messages = new List<Message>();
            foreach (Message item in AllMessages)
            {
                if (item.CreatedDate.Day >= startDate.Day || item.CreatedDate.Day <= endDate.Day)
                {
                    messages.Add(item);
                }
            }
            return messages;
        }

        public List<Message> GetMessagesByDate(int companyID,DateTime Date)
        {
            List<Message> AllMessages = _messageDAL.GetAll(a=>a.CompanyID==companyID).ToList();
            List<Message> messages = new List<Message>();
            foreach (Message item in AllMessages)
            {
                if (item.CreatedDate.Day == Date.Day)
                {
                    messages.Add(item);
                }
            }
            return messages;
        }

        public List<Message> GetMessagesBySelectNumber(int companyID,int selectNumber)
        {
            List<Message> messages = new List<Message>();
            switch (selectNumber)
            {
                case 1:
                    messages = GetMessagesByDate(companyID, DateTime.MinValue, DateTime.Now);//tüm zamanlar
                    break;
                case 2:
                    messages= GetMessagesByDate(companyID, DateTime.Now.AddMonths(-1), DateTime.Now);//bu ay
                    break;
                case 3:
                    messages= GetMessagesByDate(companyID, DateTime.Now.AddDays(-7), DateTime.Now);// bu hafta
                    break;
                case 4:
                    messages = GetMessagesByDate(companyID, DateTime.Now);//bu gün
                    break;
                default:
                    messages= GetMessagesByDate(companyID, DateTime.MinValue, DateTime.Now);//tüm zamanlar
                    break;
            }
            return messages;
        }

        public bool Update(Message model)
        {
            return _messageDAL.Update(model) > 0;
        }
    }
}
