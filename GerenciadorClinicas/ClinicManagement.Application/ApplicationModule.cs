using ClinicManagement.Application.Commands.Care.CreateCare;
using ClinicManagement.Application.Commands.Care.DeleteCare;
using ClinicManagement.Application.Commands.Medic.RegisterMedic;
using ClinicManagement.Application.Commands.Medic.UpdateMedic;
using ClinicManagement.Application.Commands.Patient.RegistePatient;
using ClinicManagement.Application.Commands.Patient.UpdatePatient;
using ClinicManagement.Application.Commands.Service.CreateService;
using ClinicManagement.Application.Commands.Service.DeleteService;
using ClinicManagement.Application.Commands.Speciality.CreateSpeciality;
using ClinicManagement.Application.Commands.Speciality.DeleteSpeciality;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Application.DTO.ViewModel.Medic;
using ClinicManagement.Application.DTO.ViewModel.Patient;
using ClinicManagement.Application.DTO.ViewModel.Service;
using ClinicManagement.Application.DTO.ViewModel.Speciality;
using ClinicManagement.Application.Query.Care.DetailsCare;
using ClinicManagement.Application.Query.Care.ListCare;
using ClinicManagement.Application.Query.Medic.DetailsMedic;
using ClinicManagement.Application.Query.Medic.ListMedic;
using ClinicManagement.Application.Query.Patient.DetailsPatient;
using ClinicManagement.Application.Query.Patient.ListPatient;
using ClinicManagement.Application.Query.Service.DetailsService;
using ClinicManagement.Application.Query.Service.ListService;
using ClinicManagement.Application.Query.Speciality.DetailsSpeciality;
using ClinicManagement.Application.Query.Speciality.ListSpeciality;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCqrs();


            return services;
        }

        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {

            services.AddScoped<IHandler<CreateCareCommand, ResultViewModel<Guid>>, CreateCareCommandHadler>();
            services.AddScoped<IHandler<ListCareQuery, ResultViewModel<List<ListCareDto>>>, LIstCareQueryHandler>();
            services.AddScoped<IHandler<DeleteCareCommand, ResultViewModel<Guid>>, DeleteCareCommandHandler>();
            services.AddScoped<IHandler<DetailsCareQuery, ResultViewModel<DetailsCareDto>>, DetailsCareQueryHandler>();

            services.AddScoped<IHandler<ListMedicQuery, ResultViewModel<List<ListMedicDto>>>, ListMedicQueryHandler>();
            services.AddScoped<IHandler<DetailsMedicQuery, ResultViewModel<DetailsMedicDto>>, DetailsMedicQueryHandler>();
            services.AddScoped<IHandler<RegisterMedicCommand, ResultViewModel<Guid>>, RegisterMedicCommandHandler>();
            services.AddScoped<IHandler<UpdateMedicCommand, ResultViewModel<Guid>>, UpdateMedicCommandHandler>();

            services.AddScoped<IHandler<ListPatientQuery, ResultViewModel<List<ListPatientDto>>>, ListPatientQueryHandler>();
            services.AddScoped<IHandler<DetailsPatientQuery, ResultViewModel<DetailsPatientDto>>, DetailsPatientQueryHandler>();
            services.AddScoped<IHandler<RegisterPatientCommand, ResultViewModel<Guid>>, RegisterPatientCommandHandler>();
            services.AddScoped<IHandler<UpdatePatientCommand, ResultViewModel<Guid>>, UpdatePatientCommandHandler>();

            services.AddScoped<IHandler<ListServiceQuery, ResultViewModel<List<ListServiceDto>>>, ListServiceQueryHandler>();
            services.AddScoped<IHandler<DetailsServiceQuery, ResultViewModel<DetailsServiceDto>>, DetailsServiceQueryHandler>();
            services.AddScoped<IHandler<CreateServiceCommand, ResultViewModel<Guid>>, CreateServiceCommandHandler>();
            services.AddScoped<IHandler<DeleteServiceCommand, ResultViewModel<Guid>>, DeleteServiceCommandHandler>();

            services.AddScoped<IHandler<ListSpecialityQuery, ResultViewModel<List<ListSpecialityDto>>>, ListSpecialityQueryHandler>();
            services.AddScoped<IHandler<DetailsSpecialityQuery, ResultViewModel<DetailsSpecialityDto>>, DetailsSpecialityQueryHandler>();
            services.AddScoped<IHandler<CreateSpecialityCommand, ResultViewModel<Guid>>, CreateSpecialityCommandHandler>();
            services.AddScoped<IHandler<DeleteSpecialityCommand, ResultViewModel<Guid>>, DeleteSpecialityCommandHandler>();

            return services;
        }
    }
}
