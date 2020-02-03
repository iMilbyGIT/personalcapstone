using AdamPersonalCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace AdamPersonalCapstone.Controllers
{
    public class SMSController : TwilioController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async System.Threading.Tasks.Task<TwiMLResult> Index(SmsRequest incomingMessage)
        {
            var response = new MessagingResponse();
            response.Message("User Says:" + incomingMessage.Body);
            return TwiML(response);
        }
    }
}