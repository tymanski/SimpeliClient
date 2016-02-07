using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpeliWebHook.Controllers
{
    public class WebHookController : ApiController
    {
        private HttpResponseMessage _response;

        [Route("pdfbin")]
        [HttpPost]
        public HttpResponseMessage SavePdf()
        {
            int iUploadedCnt = 0;

            // Inbox path, where received files will be stored
            string inboxPatk = System.Web.Hosting.HostingEnvironment.MapPath("/Inbox/");

            System.Web.HttpFileCollection fileCollection = System.Web.HttpContext.Current.Request.Files;

            string refferenceId = System.Web.HttpContext.Current.Request.Form.GetValues("referenceId").FirstOrDefault();

            // Check file count.
            for (int iCnt = 0; iCnt <= fileCollection.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = fileCollection[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // Check if file already exists to avoid dupliactes
                    if (!File.Exists(inboxPatk + Path.GetFileName(hpf.FileName)))
                    {
                        // Save it in inbox folder
                        hpf.SaveAs(inboxPatk + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }

            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return null;
            }
            else
            {
                return null;
            }
        }

        [Route("ping")]
        [HttpGet]
        public HttpResponseMessage test()
        {
            _response = null;

            _response = Request.CreateResponse(HttpStatusCode.OK);
            _response.Content = new StringContent("pong");

            return _response;
        }

    }
}