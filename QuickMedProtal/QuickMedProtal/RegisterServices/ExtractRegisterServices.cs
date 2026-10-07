using Microsoft.AspNetCore.Identity;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository;

namespace QuickMedProtal.RegisterServices
{
    public static class ExtractRegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddHttpClient();
            services.AddScoped<IDemo, DemoService>();
            services.AddScoped<IPrescription, PrescriptionService>();
            services.AddScoped<ICompany, CompanyService>();
            services.AddScoped<IGeneric, GenericService>();
            services.AddScoped<IMenu, MenuServices>();
            services.AddScoped<IBrand, BrandService>();
            services.AddScoped<IDoctor, DoctorService>();
            services.AddScoped<IDashboard, DashBoardServicecs>(); ;
            services.AddScoped<ILicence, LicenceServicecs>();
            services.AddScoped<IDosage, DosageService>();
            services.AddScoped<IType, TypeService>();

            return services;
        }
    }
}