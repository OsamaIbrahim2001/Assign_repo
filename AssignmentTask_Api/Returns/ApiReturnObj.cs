using System.Net;

namespace AssignmentTask_Api.Returns
{
    public class ApiReturnObj<TModel> where TModel : class
    {
        public TModel? Value { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
