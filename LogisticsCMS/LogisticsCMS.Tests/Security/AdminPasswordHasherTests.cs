using LogisticsCMS.Services.Security;

namespace LogisticsCMS.Tests.Security;

public class AdminPasswordHasherTests
{
    private readonly AdminPasswordHasher _hasher = new();

    [Fact]
    public void HashPassword_Should_Return_Verifiable_Hash()
    {
        var hash = _hasher.HashPassword("Admin123!");

        Assert.NotEmpty(hash);
        Assert.True(_hasher.VerifyPassword("Admin123!", hash));
    }

    [Fact]
    public void VerifyPassword_Should_Return_False_For_Wrong_Password()
    {
        var hash = _hasher.HashPassword("Admin123!");

        Assert.False(_hasher.VerifyPassword("WrongPassword!", hash));
    }

    [Fact]
    public void VerifyPassword_Should_Return_False_For_Invalid_Hash_Format()
    {
        Assert.False(_hasher.VerifyPassword("Admin123!", "invalid-hash"));
    }
}
