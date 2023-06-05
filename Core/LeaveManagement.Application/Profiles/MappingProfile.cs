using AutoMapper;
using LeaveManagement.Domain;
using LeaveManagement.Application.DTOs;
using LeaveManagement.Application.DTOs.LeaveRequest;

namespace LeaveManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
      CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
      CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
    }
  }
}