using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System.Dynamic;

namespace GeneralPackage
{
    public class JsonRestService : RestService
    {
        private string baseUrl;
        public JsonRestService(string baseUrl) : base(baseUrl)
        {
            this.baseUrl = baseUrl;
        }
        public ExpandoObject GetDynamicJsonRestAnswer(string extension, Method method)
        {
            try
            {
                var response = GetRestAnswer(extension, method);
                var data = JsonConvert.DeserializeObject<ExpandoObject>(response.Content, new ExpandoObjectConverter());

                return data;
            }
            catch
            {
                return null;
            }


        }

        public T GetStaticJsonRestAnswer<T>(string extension, Method method)
        {
            try
            {
                var response = GetRestAnswer(extension, method);
                var data = JsonConvert.DeserializeObject<T>(response.Content);

                return data;
            }
            catch
            {
                return default(T);
            }

        }

        public bool SetStaticJsonRestRequest(string extension, object model, Method method)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var response = SetRestRequest(data, extension, method);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
