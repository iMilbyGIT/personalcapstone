using AdamPersonalCapstone.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt.AccessToken;

namespace AdamPersonalCapstone
{
    //public interface ITokenGenerator
    //{
    //    string Generate(string indentity, string endpointId);
    //}

    //public class TokenGenerator : ITokenGenerator
    //{
    //    public string Generate(string identity, string enpointId)
    //    {
    //        var grants = new HashSet<IGrant>
    //        {
    //            new ChatGrant {EndpointId = EndPoint, ServiceSid = Configuration.ChatServiceSID}
    //        };

    //        var Token = new Token(
    //            Configuration.AccountSID,
    //            Configuration.ApiKey,
    //            Configuration.ApiSecret,
    //            identity,
    //            grants: grants);

    //        return token.ToJwt();
    //    }
    //}
}
