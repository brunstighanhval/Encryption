namespace ConsoleApp1;

public class ProgramVælger
{
    private int input=0;
    Kryptering _kryptering = new Kryptering();
    

    public void Valg()
    {

        while (input != 3)
        {

            GivMulighederne();
            input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=========================");
            HåndterValg(input);
           
        } 

        
    }


    private void GivMulighederne()
    {
        Console.WriteLine("=========================");
        Console.WriteLine("Takst 1: Enkrypter tekst");
        Console.WriteLine("Takst 2: Dekrypter tekst");
        Console.WriteLine("Takst 3: Slut");
        Console.WriteLine("=========================");
    }
    
    
    

    private void HåndterValg(int input)
    {
        switch (input)
        {
            case 1:
                Console.WriteLine("Skriv teksten der skal krypteres");
                string krypteretTekst = Console.ReadLine();
                _kryptering.Encrypt(krypteretTekst);
                break;
            case 2:
                Console.WriteLine("Dekrypterer tekst");
                _kryptering.Decrypt();
                break;
            case 3:
                Console.WriteLine("Afslutter");
                break;
        } 
    }
    
    
}

