// See https://aka.ms/new-console-template for more information

using RSAEncryption;
var rsa = new RsaEncryption();
Console.WriteLine("Ender text to encrypt");
var plain = Console.ReadLine();
var cypher = RsaEncryption.Encrypt(plain);
Console.WriteLine($"Encrypted data :{cypher}");
Console.WriteLine($"Decrypted value:{rsa.Decrypt(cypher)}");

