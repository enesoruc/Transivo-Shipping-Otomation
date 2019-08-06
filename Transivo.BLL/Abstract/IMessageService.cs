using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IMessageService : IBaseService<Message>
    {
        List<Message> GetByID(int id);
        List<Message> GetMessagesBySelectNumber(int companyID, int selectNumber);
        List<Message> GetMessagesByDate(int companyID, DateTime Date);
        List<Message> GetMessagesByDate(int companyID, DateTime startDate, DateTime endDate);
    }
}
