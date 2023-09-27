using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ConsoleApp1;

public class Kodeord
{

  public String Hashing(String kodeord)
  {
      
      byte[] salt = Convert.FromBase64String("zfm/rD5FIAfjiAKqPPdT0A=="); //Salt til kaffepuntch til kontrol hashed
      //Da saltet ikke ændres er det gemt her i stedet
      //  for i filen.
      
// derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
      password: kodeord!,
      salt: salt,
      prf: KeyDerivationPrf.HMACSHA256,
      iterationCount: 100000,
      numBytesRequested: 256 / 8));

    return hashed;
  }
    
}