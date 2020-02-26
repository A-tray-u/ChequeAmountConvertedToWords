using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChequeAmountToWordsConverter.Controllers
{
    [Route("ChequeConverter")]
    public class ChequeConverterController : ApiController
    {
        [HttpGet]
        [Route("{ChequeValue}")]
        public HttpResponseMessage Get(string chequeValue)
        {
            if (String.IsNullOrEmpty(chequeValue))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No value was passed to the API");
            }
            var logic = new Logic.ChequeConvertToWords();

            var result = logic.ChequeAmountToWords(chequeValue);

            if (!result.IsSuccessfull)
            {
               if(result.errorType == "ClientError")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result.Error);
                }
               else if(result.errorType == "ServerError")
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Error);
                }
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, result.NumberInEnglish);            
        }
    }
}