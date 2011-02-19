using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;

namespace RESTService
{
    public class ObjectResult<T> : ActionResult
    {
        private static UTF8Encoding UTF8 = new UTF8Encoding(false);

        public T Data { get; set; }

        public Type[] IncludedTypes = new[] { typeof(object) };
        
        public ObjectResult(T data)
        {
            this.Data = data;
        }

        public ObjectResult(T data, Type[] extraTypes)
        {
            this.Data = data;
            this.IncludedTypes = extraTypes;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // If ContentType is not expected to be application/json, then return XML
            if ((context.HttpContext.Request.ContentType ?? string.Empty).Contains("application/json"))
            {
                new JsonResult { Data = this.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet }
                    .ExecuteResult(context);
            }
            else
            {
                using (MemoryStream stream = new MemoryStream(500))
                {
                    using (var xmlWriter =
                        XmlTextWriter.Create(stream,
                            new XmlWriterSettings()
                            {
                                OmitXmlDeclaration = true,
                                Encoding = UTF8,
                                Indent = true
                            }))
                    {
                        new XmlSerializer(typeof(T), IncludedTypes)
                            .Serialize(xmlWriter, this.Data);
                    }
                    // NOTE: We need to cache XmlSerializer for specific type. Probably use the 
                    // GenerateSerializer to generate compiled custom made serializer for specific
                    // types and then cache the reference
                    new ContentResult
                    {
                        ContentType = "text/xml",
                        Content = UTF8.GetString(stream.ToArray()),
                        ContentEncoding = UTF8
                    }
                        .ExecuteResult(context);
                } 
            }
        }

    }
}
