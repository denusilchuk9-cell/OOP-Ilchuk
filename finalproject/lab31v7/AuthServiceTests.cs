using lab31v7;
using Moq;
using Xunit;

namespace lab31v7.Tests;

public class AuthServiceTests
{
    [Fact]
    public void Register_ValidData_ReturnsSuccessWithToken()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        mockPasswordHasher.Setup(x => x.HashPassword("password123")).Returns("hashedPassword123");
        mockUserRepo.Setup(x => x.Create(It.IsAny<User>())).Returns(true);
        mockTokenGenerator.Setup(x => x.GenerateToken(It.IsAny<int>(), "test@email.com")).Returns("generatedToken123");

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Register("testuser", "test@email.com", "password123");

        Assert.True(result.Success);
        Assert.Equal("generatedToken123", result.Token);
        mockUserRepo.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        mockTokenGenerator.Verify(x => x.GenerateToken(It.IsAny<int>(), "test@email.com"), Times.Once);
    }

    [Fact]
    public void Register_EmptyUsername_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Register("", "test@email.com", "password123");

        Assert.False(result.Success);
        Assert.Equal("Username is required", result.ErrorMessage);
        mockUserRepo.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public void Register_ShortPassword_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Register("testuser", "test@email.com", "123");

        Assert.False(result.Success);
        Assert.Equal("Password must be at least 6 characters", result.ErrorMessage);
        mockUserRepo.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
    }

    [Fact]
    public void Register_UserCreationFailed_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        mockPasswordHasher.Setup(x => x.HashPassword("password123")).Returns("hashedPassword123");
        mockUserRepo.Setup(x => x.Create(It.IsAny<User>())).Returns(false);

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Register("testuser", "test@email.com", "password123");

        Assert.False(result.Success);
        Assert.Equal("User creation failed", result.ErrorMessage);
        mockUserRepo.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        mockTokenGenerator.Verify(x => x.GenerateToken(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void Login_ValidCredentials_ReturnsSuccessWithToken()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var user = new User { Id = 1, Email = "test@email.com", PasswordHash = "hashedPassword123", IsActive = true };

        mockUserRepo.Setup(x => x.GetById(1)).Returns(user);
        mockPasswordHasher.Setup(x => x.VerifyPassword("password123", "hashedPassword123")).Returns(true);
        mockTokenGenerator.Setup(x => x.GenerateToken(1, "test@email.com")).Returns("generatedToken456");

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Login("test@email.com", "password123");

        Assert.True(result.Success);
        Assert.Equal("generatedToken456", result.Token);
        mockUserRepo.Verify(x => x.GetById(1), Times.AtLeastOnce);
        mockTokenGenerator.Verify(x => x.GenerateToken(1, "test@email.com"), Times.Once);
    }

    [Fact]
    public void Login_InvalidPassword_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var user = new User { Id = 1, Email = "test@email.com", PasswordHash = "hashedPassword123", IsActive = true };

        mockUserRepo.Setup(x => x.GetById(1)).Returns(user);
        mockPasswordHasher.Setup(x => x.VerifyPassword("wrongpassword", "hashedPassword123")).Returns(false);

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Login("test@email.com", "wrongpassword");

        Assert.False(result.Success);
        Assert.Equal("Invalid email or password", result.ErrorMessage);
        mockTokenGenerator.Verify(x => x.GenerateToken(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void Login_DeactivatedAccount_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var user = new User { Id = 1, Email = "test@email.com", PasswordHash = "hashedPassword123", IsActive = false };

        mockUserRepo.Setup(x => x.GetById(1)).Returns(user);
        mockPasswordHasher.Setup(x => x.VerifyPassword("password123", "hashedPassword123")).Returns(true);

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Login("test@email.com", "password123");

        Assert.False(result.Success);
        Assert.Equal("Account is deactivated", result.ErrorMessage);
        mockTokenGenerator.Verify(x => x.GenerateToken(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void Login_EmptyEmail_ReturnsError()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.Login("", "password123");

        Assert.False(result.Success);
        Assert.Equal("Email is required", result.ErrorMessage);
        mockUserRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        mockTokenGenerator.Verify(x => x.GenerateToken(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ChangePassword_ValidData_ReturnsTrue()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var user = new User { Id = 1, PasswordHash = "oldHashedPassword" };

        mockUserRepo.Setup(x => x.GetById(1)).Returns(user);
        mockPasswordHasher.Setup(x => x.VerifyPassword("oldPass", "oldHashedPassword")).Returns(true);
        mockPasswordHasher.Setup(x => x.HashPassword("newPass123")).Returns("newHashedPassword");
        mockUserRepo.Setup(x => x.Update(user)).Returns(true);

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.ChangePassword(1, "oldPass", "newPass123");

        Assert.True(result);
        mockUserRepo.Verify(x => x.GetById(1), Times.Once);
        mockUserRepo.Verify(x => x.Update(user), Times.Once);
    }

    [Fact]
    public void DeactivateUser_ValidUser_ReturnsTrue()
    {
        var mockUserRepo = new Mock<IUserRepository>();
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        var mockTokenGenerator = new Mock<ITokenGenerator>();

        var user = new User { Id = 1, IsActive = true };

        mockUserRepo.Setup(x => x.GetById(1)).Returns(user);
        mockUserRepo.Setup(x => x.Update(user)).Returns(true);

        var authService = new AuthService(mockUserRepo.Object, mockPasswordHasher.Object, mockTokenGenerator.Object);
        var result = authService.DeactivateUser(1);

        Assert.True(result);
        Assert.False(user.IsActive);
        mockUserRepo.Verify(x => x.GetById(1), Times.Once);
        mockUserRepo.Verify(x => x.Update(user), Times.Once);
    }
}