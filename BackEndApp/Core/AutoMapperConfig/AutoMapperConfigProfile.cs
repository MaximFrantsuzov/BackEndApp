using AutoMapper;
using BackEndApp.Core.Dtos.Departament;
using BackEndApp.Core.Dtos.Employee;
using BackEndApp.Core.Dtos.HistoryDepartament;
using BackEndApp.Core.Dtos.HistorySubdivision;
using BackEndApp.Core.Dtos.JobTitle;
using BackEndApp.Core.Dtos.SubDivision;
using BackEndApp.Core.Dtos.WorkActivity;
using BackEndApp.Core.Entities;

namespace BackEndApp.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        //Automapper
        //Сопоставление обьектов  
        public AutoMapperConfigProfile()
        {
            //Departament
            CreateMap<CreateDepartamentCreateDto, Departament>();
            CreateMap<Departament, GetDepartamentDto>()
                .ForMember(dest => dest.SubdivisionName, opt=>opt.MapFrom(src=>src.Subdivision.NameSubdivision));
            CreateMap<UpdateDepartamentDto, Departament>();
            //Subdivision
            CreateMap<CreateSubdivisionDto, Subdivision>();
            CreateMap<Subdivision, GetSubdivisionDto>();
            CreateMap<UpdateSubdivisionDto, Subdivision>();
            //Employee
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee,GetEmployeeDto>()
                .ForMember(employee=>employee.DepartamentName,opt=>opt.MapFrom(src=>src.Departament.NameDepartament));
            CreateMap<UpdateEmployeeDto, Employee>();
            
            //WorkActivity
            CreateMap<CreateWorkActivityDto, WorkActivity>();
            CreateMap<WorkActivity, GetWorkActivityDto>()
                .ForMember(workactivity => workactivity.FIO, opt => opt.MapFrom(src => src.Employee.FIO))
                .ForMember(workactivity => workactivity.DepartamentName, opt => opt.MapFrom(src => src.Departament.NameDepartament));
               
                
            //JobTitle
            CreateMap<CreateJobTitileDto, JobTitle>();
            CreateMap<JobTitle, GetJobTitleDto>();
            //HistoryDepartament
            CreateMap<CreateHistoryDepartamentDto, HistoryDepartament>();
            CreateMap<HistoryDepartament,GetHistoryDepartamentDto>()
                .ForMember(historydepartament=>historydepartament.NameDepartament,opt=>opt.MapFrom(src=>src.Departament.NameDepartament));
            //HistorySubDivision
            CreateMap<CreateHistorySubdidvisionDto, HistorySubdivision>();
            CreateMap<HistorySubdivision, GetHistorySubDivisionDto>()
                .ForMember(historysubdivision => historysubdivision.SubdivisionName, opt => opt.MapFrom(src => src.Subdivision.NameSubdivision));


        }
    }
}
