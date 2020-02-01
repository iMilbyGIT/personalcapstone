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

        [HttpPost]
        public TwiMLResult Index(SmsRequest request)
        {
            var response = new MessagingResponse();
            response.Message("I need assistance. Please let me know when you're available.");
            return TwiML(response);
        }
    }
}