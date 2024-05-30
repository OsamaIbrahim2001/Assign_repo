using AssignmentTask_Api.IWork;
using AssignmentTask_Api.Work;

namespace AssignmentTask_Api.RegisterationService
{
    public static class HandelRegistration
    {
        public static void AddRegisterationService(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
