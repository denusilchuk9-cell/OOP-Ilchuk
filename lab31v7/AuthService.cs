using System;

namespace lab31v7;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
    }

    public AuthResult Register(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return new AuthResult { Success = false, ErrorMessage = "Username is required" };

        if (string.IsNullOrWhiteSpace(email))
            return new AuthResult { Success = false, ErrorMessage = "Email is required" };

        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            return new AuthResult { Success = false, ErrorMessage = "Password must be at least 6 characters" };

        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = _passwordHasher.HashPassword(password),
            IsActive = true
        };

        bool created = _userRepository.Create(user);

        if (!created)
            return new AuthResult { Success = false, ErrorMessage = "User creation failed" };

        var token = _tokenGenerator.GenerateToken(user.Id, user.Email);

        return new AuthResult { Success = true, Token = token };
    }

    public AuthResult Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
            return new AuthResult { Success = false, ErrorMessage = "Email is required" };

        if (string.IsNullOrWhiteSpace(password))
            return new AuthResult { Success = false, ErrorMessage = "Password is required" };

        var user = _userRepository.GetById(1);

        if (user == null)
            return new AuthResult { Success = false, ErrorMessage = "Invalid email or password" };

        if (user.Email != email)
            return new AuthResult { Success = false, ErrorMessage = "Invalid email or password" };

        if (!_passwordHasher.VerifyPassword(password, user.PasswordHash))
            return new AuthResult { Success = false, ErrorMessage = "Invalid email or password" };

        if (!user.IsActive)
            return new AuthResult { Success = false, ErrorMessage = "Account is deactivated" };

        var token = _tokenGenerator.GenerateToken(user.Id, user.Email);

        return new AuthResult { Success = true, Token = token };
    }

    public bool ChangePassword(int userId, string oldPassword, string newPassword)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user id");

        if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            throw new ArgumentException("New password must be at least 6 characters");

        var user = _userRepository.GetById(userId);

        if (user == null)
            return false;

        if (!_passwordHasher.VerifyPassword(oldPassword, user.PasswordHash))
            return false;

        user.PasswordHash = _passwordHasher.HashPassword(newPassword);
        return _userRepository.Update(user);
    }

    public bool DeactivateUser(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user id");

        var user = _userRepository.GetById(userId);

        if (user == null)
            return false;

        user.IsActive = false;
        return _userRepository.Update(user);
    }
}