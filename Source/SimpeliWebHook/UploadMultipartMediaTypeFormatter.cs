using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpeliWebHook
{
    public class UploadMultipartMediaTypeFormatter : MediaTypeFormatter
    {
        public UploadMultipartMediaTypeFormatter()
        {
            SupportedMediaTypes
        .Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            bool a = true;
            return a;
        }

        public override bool CanWriteType(Type type)
        {
            bool a = true;
            return a;
        }
    }
}