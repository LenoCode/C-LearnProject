using static System.Text.Encoding;

namespace SqlTransfDataAccess.Utilz.Encryption;

public class PasswordEncryption
{
    
    /**
     * <summary>
     *  Encrypt password 
     * </summary>
     */
    public static string EncryptPasswordBase64(string pass)
    {
        var plainTextBytes = UTF8.GetBytes(pass);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    
    /**
     * <summary>
     *  Decrypt password
     * </summary>
     */
    public static string DecryptPasswordBase64(string base64EncodedData)
    {
        var plainTextBytes = System.Convert.FromBase64String(base64EncodedData);
        return UTF8.GetString(plainTextBytes);
    }

}