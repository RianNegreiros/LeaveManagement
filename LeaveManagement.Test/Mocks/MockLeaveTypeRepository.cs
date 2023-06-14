using System.Collections.Generic;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Moq;

namespace LeaveManagement.Test.Mocks
{
  public static class MockLeaveTypeRepository
  {
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
      var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                },
                new LeaveType
                {
                    Id = 3,
                    DefaultDays = 15,
                    Name = "Test Maternity"
                }
            };

      var mockRepo = new Mock<ILeaveTypeRepository>();

      mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

      mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
      {
        leaveTypes.Add(leaveType);
        return leaveType;
      });

      return mockRepo;

    }
  }
}