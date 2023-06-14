using AutoMapper;
using LeaveManagement.MVC.Models;
using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
      CreateMap<CreateLeaveRequestDto, CreateLeaveRequestVM>().ReverseMap();
      CreateMap<LeaveRequestDto, LeaveRequestVM>()
          .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
          .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
          .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
          .ReverseMap();
      CreateMap<LeaveRequestListDto, LeaveRequestVM>()
          .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
          .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
          .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
          .ReverseMap();
      CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
      CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
      CreateMap<RegisterVM, RegistrationRequest>().ReverseMap();
      CreateMap<EmployeeVM, Employee>().ReverseMap();
    }
  }
}