using System.Security.Cryptography;
using System.Text;

public class PasswordHelper
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        var inputHash = HashPassword(inputPassword);
        return inputHash == storedHash;
    }
}
