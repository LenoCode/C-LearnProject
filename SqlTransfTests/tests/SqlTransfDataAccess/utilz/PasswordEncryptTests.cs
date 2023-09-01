using SqlTransfTests.dataGenerators.SqlTransfDataAccess;
using SqlTransfDataAccess.Utilz.Encryption;

namespace SqlTransfTests.tests.SqlTransfDataAccess.utilz;

public class PasswordEncryptTests
{

    [Theory(DisplayName = "Primitive testing of password encryption")]
    [ClassData(typeof(PasswordData))]
    public void Test_basic_password_encryption(string password)
    {
        string hidden = PasswordEncryption.EncryptPasswordBase64(password);
        string revealed = PasswordEncryption.DecryptPasswordBase64(hidden);
        
        Assert.Equal(password,revealed);
    }
}