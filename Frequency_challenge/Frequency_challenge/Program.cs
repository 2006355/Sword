using System;
using static System.Net.Mime.MediaTypeNames;

namespace Frequency_challenge;
public class Program
{
    public static void Main(String[] arrgs)
    {
        Console.Write("case sensitive true or false:");
         String file = Console.ReadLine();
        bool cs;
        if(bool.TryParse(file, out cs))
        {
            MyReader reader = new MyReader("/Users/jonathanadams/Desktop/test.rtf", cs);
            reader.Reader();
            Console.WriteLine(reader);

        }
        //Console.WriteLine("file is  {0}" + file);
    
    }
}


