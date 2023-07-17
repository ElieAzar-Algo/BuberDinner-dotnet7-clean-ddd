using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //1. validate the user doesn't exist
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        //2. Create new user (generate unique ID) & persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //.3 create JWT token 
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            // user.Id,
            // firstName,
            // lastName,
            // email,
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {

        //1. validate if user exists
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid Credentials, Message_2: (dev debugging: user does not exist)"); //remove message 2 for security purposes
        }

        //2. Validate password is matched
        if(user.Password !=password)
        {
            throw new Exception("Invalid Credentials, Message_2: (dev debugging: password is wrong) ");//remove message 2 for security purposes
        }

        //3. Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            // user.Id,
            // user.FirstName!,
            // user.LastName!,
            user,
            token);
    }
}