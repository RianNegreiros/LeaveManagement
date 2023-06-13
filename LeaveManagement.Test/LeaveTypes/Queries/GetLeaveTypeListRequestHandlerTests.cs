using AutoMapper;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Profiles;
using LeaveManagement.Test.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LeaveManagement.Test.LeaveTypes.Queries
{
  public class GetLeaveTypeListRequestHandlerTests
  {
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    public GetLeaveTypeListRequestHandlerTests()
    {
      _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<MappingProfile>();
      });

      _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
      var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

      var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

      result.ShouldBeOfType<List<LeaveTypeDto>>();

      result.Count.ShouldBe(3);
    }
  }
}