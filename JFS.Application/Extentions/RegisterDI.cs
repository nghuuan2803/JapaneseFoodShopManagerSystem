using System.Reflection;
using FluentValidation;
using JFS.Application.Helper;
using JFS.Application.ValidateBehavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JFS.Application.Extentions
{
    public static class RegisterDI
    {
        public static void AddApplication(this IServiceCollection services)
        {            
            services.AddAutoMapper(typeof(RegisterDI).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Đăng ký ValidationBehavior
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
