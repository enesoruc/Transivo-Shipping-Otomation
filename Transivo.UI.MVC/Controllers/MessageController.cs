using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;
using Transivo.UI.MVC.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult ListMessages()
        {
            Admin admin = Session["admin"] as Admin;
            return View(_messageService.GetByID(admin.CompanyID));
        }

        [HttpPost]
        public ActionResult ListMessages(int value)
        {
            if (value < 1 || value > 4)
            {
                return RedirectToAction("ListMessage");
            }
            Admin admin = Session["admin"] as Admin;
            List<Message> messages = new List<Message>();
            messages = GetMessages(admin.CompanyID, value);
            return View(messages);
        }

        private List<Message> GetMessages(int companyID, int selectNumber)
        {
            List<Message> messages = _messageService.GetMessagesBySelectNumber(companyID, selectNumber);
            return messages;
        }

        public JsonResult GetByID(int id)
        {
            Message msg = _messageService.Get(id);
            if (msg != null)
            {
                MessageVM msgVM = new MessageVM()
                {
                    MessageID = msg.ID,
                    NameSurname = msg.User.FirstName + " " + msg.User.LastName,
                    CreatedDate = msg.CreatedDate.ToShortDateString(),
                    Detail = msg.Detail
                };
                return Json(msgVM, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("");
            }
        }

        //public JsonResult GetBySelectedDate(int id)
        //{
        //    List<Message> messages = new List<Message>();
        //    messages= _messageService.GetMessagesBySelectNumber(id);
        //    return Json(messages, JsonRequestBehavior.AllowGet);
        //}
    }
}