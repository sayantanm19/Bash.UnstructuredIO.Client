using System.Net;

namespace UnstructuredAPI.Models
{
    public class ApiResponse
    {
        public List<Element> Data { get; set; }
        public object Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
