using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.UI.Utility;

namespace WebProject.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public void ShowMessage(MessageType tip,string msg,int? sure=3,bool kapansinmi=true)
        {
            Message mesaj = new Message();
            mesaj.Text = msg;
            mesaj.Type = tip;
            mesaj.Duration = sure;
            mesaj.Closeable = kapansinmi;

            List<Message> messages = null;

            if (TempData[Message.MessageName]!=null)
            {
                messages =(List<Message>) TempData[Message.MessageName];
            }
            else
            {
                messages = new List<Message>(); // TempData nullsa instance aldık listeden ve içerisine mesaj ekliycez .
            }

            messages.Add(mesaj);

            TempData[Message.MessageName] = messages;


        }
    }
}