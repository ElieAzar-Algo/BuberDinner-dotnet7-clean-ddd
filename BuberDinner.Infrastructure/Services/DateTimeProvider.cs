using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;


public class DateTimeProvider : IDateTimePorvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}