using SinglePageToDo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePageToDo.Models;
using System.Threading.Tasks;

namespace SinglePageToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        public HomeController(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        private async Task<IEnumerable<MessageViewModel>> GetMyToDosAsync() {
            var messages = await _messageRepository.GetAllMessages();
            List<MessageViewModel> messageViewList = new List<MessageViewModel>();
            foreach (var message in messages)
            {
                messageViewList.Add(new MessageViewModel
                {
                    MessageText = message.MessageText,
                    Date = message.DatePosted
                });
            }
            return messageViewList;
        }

        [HttpGet]
        public async Task<ActionResult> GetMessages()
        {
            var messages = await _messageRepository.GetAllMessages();
            List<MessageViewModel> messageViewList = new List<MessageViewModel>();
            foreach (var message in messages)
            {
                messageViewList.Add(new MessageViewModel
                {
                    MessageText = message.MessageText,
                    Date = message.DatePosted
                }) ;
            }

            return PartialView("_ToDoList", messageViewList);
        }

        [HttpPost]
        public async Task<ActionResult> PostMessage(string message)
        {
            await _messageRepository.AddNewMessage(message);
            return Json(new { success = true });
        }
    }
}