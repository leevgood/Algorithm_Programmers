using System;

class Program
{
    static void Main(string[] args)
    {
        string s = " Hello-World-yes" ;
        string [] s1 = s.Split('-');
        
        char[] chars = s.ToCharArray();
    
        foreach (char c in chars)
        {
            Console.WriteLine(c);
        }
    }
}   
