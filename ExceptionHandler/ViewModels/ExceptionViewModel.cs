using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ExceptionHandler.ViewModels
{
    internal class ExceptionViewModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}