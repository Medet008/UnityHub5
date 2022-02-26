using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnityHub5
{
    class IsValid
    {
        // с использованием регулярных выражений.
        public static bool IsValidLogin(string login)
        {
            bool result;
            Regex login_regex = new Regex("^[a-zA-Z][a-zA-Z0-9]{2,9}$");
            if (login_regex.Match(login).Success && login.Length >= 2 && login.Length <= 10) // если совпадение удачно
            {
                Console.WriteLine("валидация успешно");
                result = true;
            }
            else
            {
                Console.WriteLine("вы ввели не корректно или есть буквы кроме латински");
                result = false;
            }
            return result;
        }
    }

    // bez использованием регулярных выражений.

    class isValid2
    {
        public static bool IsValidLogin2(string login)
        {
            bool result;
            
            if (login !=null && login.Length >= 2 && login.Length <= 10 && !Char.IsDigit(login[0]))
            {
                Console.WriteLine("валидация успешно");
                return login.All(char.IsLetterOrDigit);
               
            }
            else
            {
                Console.WriteLine("вы ввели не корректно");
                result = false;   
            }
            return result; 
        }
    }



    class Message
    {
        public static void PrintsWord(string mess, int n, char[] splitsymb)
        {
            string[]words = mess.Split(splitsymb);
            foreach (var word in words)
            {
                if(word.Length == n)
                {
                    Console.WriteLine(words);
                }
            }
        }

        public static void PrintWords(string mess, char s , char[] splitsymb)
        {
            string[]words = mess.Split(' ');
            foreach(var word in words)
            {
                Console.WriteLine(word);
            }
        }


        public static string DeletWords(string mess, char s, char[] splitsymb)
        {
            string[] words = mess.Split(splitsymb);
            StringBuilder stringBuilder = new StringBuilder(mess.Length);
            foreach (var word in words)
            {
                if (word[word.Length - 1] == s)
                {
                    Console.WriteLine($"udaleno {word}");
                }
                else
                {
                    stringBuilder.Append(word);
                }
            }
            return stringBuilder.ToString();
        }

        public static string GetLongWorld(string mess, char [] splitSymb)
        {
            string [] world = mess.Split(' ');
            int index = 0;
            for (int i = 0; i < world.Length; i++)
            {
                if (world[index].Length < world[i].Length)
                {
                    index = i; 
                }
            }
            return world[index];
        }
    }


    internal class Program
    {
        static void Main(string[] args)       
        {
            Console.WriteLine("wedite vash login.Mojet soderjat tolko bukvi i cifire ot 2 do 10 simvolo"); 
            string login = Console.ReadLine();
            IsValid.IsValidLogin(login);

            Console.WriteLine("wedite vash login.Mojet soderjat tolko bukvi i cifire ot 2 do 10 simvolo");
            string login2 = Console.ReadLine();
            isValid2.IsValidLogin2(login2);

            string mess;
            int n;
            char s;
            char[] splitSymb = {' '};
            Console.WriteLine("vvedtie simbol razdelaya slova probelom");
            mess = Console.ReadLine();
            Console.WriteLine("vvedite kolichestvo simvolov, dlia ogranichania vvoda slov");
            int.TryParse(Console.ReadLine(), out n);
            Message.PrintsWord(mess, n , splitSymb);

            Console.WriteLine("vvedite simvol dlia iskluchenia slov, katoroe zakanchivatisa na nego");
            s = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Message.PrintsWord(Message.DeletWords(mess, s, splitSymb),s, splitSymb);
            Console.WriteLine($"samoe dlinnoe slova {Message.GetLongWorld(mess, splitSymb)}"); 


        }
    }
}
