using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace RSAEncryption;
public class RsaEncryption
{
    private static readonly RSACryptoServiceProvider Csp = new(2048);
    private RSAParameters _privateKey;
    private readonly RSAParameters _publicKey;

    public RsaEncryption()
    {
        _privateKey = Csp.ExportParameters(true);
        _publicKey = Csp.ExportParameters(false);
    }
    public string GetPublicKey()
    {
        var sw = new StringWriter();
        var xs = new XmlSerializer(typeof(RSAParameters));
        xs.Serialize(sw, _publicKey);
        return sw.ToString();
    }

    public static string Encrypt(string? plainText)
    {
        if (plainText == null) return string.Empty;
        var data = Encoding.Unicode.GetBytes(plainText);
        var cypher = Csp.Encrypt(data,false);
        return Convert.ToBase64String(cypher);

    }

    public string Decrypt(string cypher)
    {
        var dataInBytes = Convert.FromBase64String(cypher);
        var plainText = Csp.Decrypt(dataInBytes, false);
        return Encoding.Unicode.GetString(plainText);
    }

}