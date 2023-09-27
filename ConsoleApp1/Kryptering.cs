using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1;

public class Kryptering
{
    private String[] data = { "", "", "" };
    
    public void Encrypt(string text)
    {
       
        var nonce = new byte[AesGcm.NonceByteSizes.MaxSize]; // MaxSize = 12
        RandomNumberGenerator.Fill(nonce);

        var plaintextBytes = Encoding.UTF8.GetBytes(text);
        var ciphertext = new byte[plaintextBytes.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize]; // MaxSize = 16

        using var aes = new AesGcm(key());
        aes.Encrypt(nonce, plaintextBytes, ciphertext, tag);
        
       KonsolTekst(nonce,ciphertext,tag);
       
    }
   
    
    private void KonsolTekst(byte[] nonce,byte[] ciphertext,byte[] tag)
    {
        string nonce1 = Convert.ToBase64String(nonce);
        string ciphertext1 = Convert.ToBase64String(ciphertext);
        string tag1 = Convert.ToBase64String(tag);
        
        
        Console.WriteLine("-----Gemmer følgende data--------- ");
        Console.WriteLine("nonce          :"+nonce1);
        Console.WriteLine("ciphertext     :"+ciphertext1);
        Console.WriteLine("tag            :"+tag1);
        Console.WriteLine("---------------------------------- ");
        
       filSkrivning(nonce1,ciphertext1,tag1);
        
    }
    
    private void filSkrivning(string nonce1,string ciphertext1, string tag1)
    {
        FileStorage fileStorage = new FileStorage();
        fileStorage.Write(nonce1,  ciphertext1, tag1);
        
    }


    private byte[] key()
    {
        return Convert.FromBase64String("0Ub3TAXMyGhHXjXYeB4tdSXOQxsNPUDqgZAu2gNSUjg="); //Fastlåst nøgle kun skrevet her.
    }
    
    
    
    public void Decrypt()
        {
    
            FileStorage fileStorage = new FileStorage();
            data=fileStorage.ReadFile();
            byte[] nonce = Convert.FromBase64String(data[0]);
            byte[] ciphertext = Convert.FromBase64String(data[1]);
            byte[] tag = Convert.FromBase64String(data[2]);
            
            
            using (var aes = new AesGcm(key()))
             {
            var plaintextBytes = new byte[ciphertext.Length];

                      aes.Decrypt(nonce, ciphertext, tag, plaintextBytes);

                     Console.WriteLine("=========================");
                     Console.WriteLine(Encoding.UTF8.GetString(plaintextBytes));
             }
        
        }
    
}