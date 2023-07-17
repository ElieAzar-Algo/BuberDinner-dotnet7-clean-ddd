using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
   // Guid Id,
   // string FirstName,
   // string LastName,
   // string Email,
   User user,
   string Token
);