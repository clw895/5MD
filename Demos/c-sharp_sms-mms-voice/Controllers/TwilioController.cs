using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

namespace c_sharp_sms_mms_voice.Controllers
{
    [Route("api/[controller]")]
    public class TwilioController : Controller
    {
        [Produces("application/xml")]
        [HttpGet]
        public IActionResult Get()
        {
            var message = new Message();
            message.Body("This demo was brought to you by Twilio and its .NET SDK. Thanks for joining. See you soon.");

            var response = new MessagingResponse();
            response.Message(message);
            return Content(response.ToString());
        }

        [HttpGet]
        public IActionResult Call()
        {
            TwilioClient.Init("ACCOUNT_SID", "AUTH_TOKEN");

            var result = CallResource.Create(
                to: new Twilio.Types.PhoneNumber("7183445334"),
                from: new Twilio.Types.PhoneNumber("INSERT TWILIO PHONE NUMBER HERE"),
                url: new Uri(""));

            return Content(result.ParentCallSid);
        }
    }
}