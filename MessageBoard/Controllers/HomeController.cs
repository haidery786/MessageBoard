using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private  IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail , IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }
    
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var topic = _repo.GetTopics()
                .OrderByDescending(t => t.Created)
                .Take(25)
                .ToList();

            return View(topic);

           // return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from: {1}{0}Email:{2}{0}Website:{3}{0}Comment", 
                Environment.NewLine,
                model.Name , 
                model.Email ,
                model.Website ,
                model.Comment);
           
            //var svc = new MailService();
            
           if( _mail.SendMail("noreply@gmail.com", "foo@yahoo.com", "Message Subject", msg))
           {
               ViewBag.MailSent = true;
           }

            
            return View();
        }
        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }
    }
}
