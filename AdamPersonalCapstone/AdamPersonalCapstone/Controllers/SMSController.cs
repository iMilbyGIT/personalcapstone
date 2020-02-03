using AdamPersonalCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace AdamPersonalCapstone.Controllers
{
    public class SMSController : TwilioController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [ChildActionOnly]
        public async System.Threading.Tasks.Task<TwiMLResult> Index(SmsRequest incomingMessage)
        {
            var response = new MessagingResponse();
            response.Message("User Says:" + incomingMessage.Body);
            return TwiML(response);
        }
        [ChildActionOnly]
        public ActionResult MapClick()
        {
            const string accountSid = PrivateKeys.twilioAccountSid;
            const string authToken = PrivateKeys.twilioToken;
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
            body: "There is a local customer in need of Nerd assistance! Please log into NeighborNerd to address the request.",
            from: new Twilio.Types.PhoneNumber("+17867890420"),
            to: new Twilio.Types.PhoneNumber("+16084210953")
            );
            Console.WriteLine(message.Sid);
            return RedirectToAction("Index", "SMS");
        }
    }
}