using RestSharp;

namespace GeneralPackage
{
    public class RestService
    {
        private string baseUrl;
        private RestClient _client;
        public RestService(string baseUrl)
        {
            this.baseUrl = baseUrl;
            _client = new RestClient(baseUrl);
        }

        public IRestResponse GetRestAnswer(string extension, Method method)
        {
            try
            {
                var request = new RestRequest(baseUrl + extension, method);
                request.RequestFormat = DataFormat.Json;
                IRestResponse response = _client.Execute(request);

                return response;
            }
            catch
            {
                return null;
            }
        }

        public bool SetRestRequest(object model, string extension, Method method)
        {
            try
            {
                var request = new RestRequest(baseUrl + extension, method);
                request.AddJsonBody(model);
                _client.Execute(request);
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
