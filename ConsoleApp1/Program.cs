
using ConsoleApp1;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

Console.WriteLine("Skriv kodeord");
string kodeord = Console.ReadLine();


Kodeord hashed = new Kodeord();
string hashedkaffepuntch = "3HJW6w6rPitEv+wg+8svqkkQ2JgSAjBSoLA0jgWyDgE="; //Kontrol hash

if (hashedkaffepuntch.Equals(hashed.Hashing(kodeord)))
{
    ProgramVælger programVælger = new ProgramVælger();
    programVælger.Valg();
}

else
{
    Console.WriteLine("Forkert kodeord -- slutter");
}















