using AssignmentTask_Api.Models;
using AssignmentTask_Api.Returns;
using System.Net;

namespace AssignmentTask_Api.Iservices
{
    public interface IGenaricService<TModel> where TModel: class
    {
        Task<ApiReturnObj<List<TModel>>> Get();
        Task<ApiReturnObj<TModel>> GetById(int id);
        Task<ApiReturnObj<TModel>> Add(TModel model);
        HttpStatusCode Update(TModel model);
        Task<HttpStatusCode> Delete(int id);
    }
}
