using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveAllocation;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Domain;

namespace LeaveManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      #region LeaveRequest Mappings
      CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestListDto>()
          .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
          .ReverseMap();
      CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
      CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
      #endregion LeaveRequest

      CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
      CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
      CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

      CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
      CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
    }
  }
}