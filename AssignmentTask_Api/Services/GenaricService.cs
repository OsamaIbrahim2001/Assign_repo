using AssignmentTask_Api.Iservices;
using AssignmentTask_Api.Models.Context;
using AssignmentTask_Api.Returns;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AssignmentTask_Api.Services
{
    public class GenaricService<TModel> : IGenaricService<TModel> where TModel : class
    {
        private readonly ApplicationContext _context;
        public GenaricService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ApiReturnObj<TModel>> Add(TModel model)
        {
            if (model == null)
                return new ApiReturnObj<TModel> { HttpStatusCode = HttpStatusCode.NoContent, Value = null };
            await _context.Set<TModel>().AddAsync(model);
            return new ApiReturnObj<TModel> { HttpStatusCode = HttpStatusCode.OK, Value = model };
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            if (id <= 0)
                return HttpStatusCode.NotFound;

            var entity = await _context.Set<TModel>().FindAsync(id);
            if (entity == null)
                return HttpStatusCode.NoContent;
            _context.Set<TModel>().Remove(entity);
            return HttpStatusCode.OK;
        }

        public async Task<ApiReturnObj<List<TModel>>> Get()
        {
            var result = await _context.Set<TModel>().ToListAsync();
            if (result == null || result.Count == 0)
                return new ApiReturnObj<List<TModel>> { HttpStatusCode = HttpStatusCode.NoContent, Value = null };
            return new ApiReturnObj<List<TModel>> { HttpStatusCode = HttpStatusCode.OK, Value = result };
        }

        public async Task<ApiReturnObj<TModel>> GetById(int id)
        {
            if (id <= 0)
                return new ApiReturnObj<TModel> { HttpStatusCode = HttpStatusCode.NotFound, Value = null };
            var entity = await _context.Set<TModel>().FindAsync(id);
            if (entity == null)
                return new ApiReturnObj<TModel> { HttpStatusCode = HttpStatusCode.NoContent, Value = null };

           return new ApiReturnObj<TModel> { HttpStatusCode= HttpStatusCode.OK,Value=entity};

        }

        public HttpStatusCode Update(TModel model)
        {
            if (model == null)
                return HttpStatusCode.NotFound;
            _context.Set<TModel>().Update(model);
            return HttpStatusCode.OK;
        }
    }
}
