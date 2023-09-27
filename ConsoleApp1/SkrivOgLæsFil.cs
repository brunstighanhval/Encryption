namespace ConsoleApp1;
using System;
using System.IO;


public class FileStorage
{
    public void Write( string nonce1, string ciphertext1, string tag1)
    {
        // Create a string array with the lines of text
        string[] lines = { nonce1, ciphertext1,tag1};

        
        using (StreamWriter outputFile = new StreamWriter(Path.Combine( "TestFile.txt")))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }
    }


    public String[] ReadFile()
    {
        
        String[] Data = {"","",""};
      
        using(StreamReader file = new StreamReader("TestFile.txt")) {
            int counter = 0;
            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                Data[counter] = ln;
                counter++;
            }
            file.Close();
            
        }

        return Data;
    }
    
    
    
    
    
}