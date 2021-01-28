using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modern
{
    class Encrypter
    {
        //Encrypt
        //n + l =ns mod (alfa)
        //Decrypt
        //(l + a - n) mod(alfa)
        //l - latter index in alphabet
        //n - random number mod(alfa)
        //alfa - alphabet
        //s - result 
        //a - alphabet lenght
        static Random random;
        public static string alphabetRUS = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя!.,? ";
        public static string alphabetENG = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!.,? ";
        public string Encrypt(string inc)
        {
            if (inc.Split(' ').Length > 0)
            {
                if (!Regex.IsMatch(inc.Split(' ')[0].ToString()[0].ToString(), @"\P{IsCyrillic}"))
                {
                    return Enc(inc, alphabetRUS);
                }
                else if (!Regex.IsMatch(inc.Split(' ')[0].ToString()[0].ToString(), @"\p{IsCyrillic}"))
                {
                    return Enc(inc, alphabetENG);
                }
                else
                    return "";
            }
            else
            {
                if (!Regex.IsMatch(inc, @"\P{IsCyrillic}"))
                {
                    return Enc(inc, alphabetRUS);
                }
                else if (!Regex.IsMatch(inc, @"\p{IsCyrillic}"))
                {
                    return Enc(inc, alphabetENG);
                }
                else
                    return "";
            }

        }
        public string Decrypt(string inc)
        {
            string tt = inc.Split('-')[0].Last().ToString();
            if (!Regex.IsMatch(tt, @"\P{IsCyrillic}"))
            {
                return Dec(inc, alphabetRUS);
            }
            else if (!Regex.IsMatch(tt, @"\p{IsCyrillic}"))
            {
                return Dec(inc, alphabetENG);
            }
            else
                return "";
        }
        string Enc(string str, string alfabet)
        {
            random = new Random();
            string rtrn = "";
            for (int j = 0; j < str.Length; j++)
            {
                int n = random.Next(alfabet.Length);
                int l = alfabet.IndexOf(str[j]);
                int res = n + l;
                if (res >= alfabet.Length)
                {
                    for (; res >= alfabet.Length;)
                    {
                        res -= alfabet.Length;
                    }
                }
                rtrn += $"{n}{alfabet[res]}-";

            }
            rtrn = rtrn.Remove(rtrn.Length - 1);
            return rtrn;
        }
        public string Dec(string str, string alfabet)
        {
            string rtrn = "";
            string[] words = str.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                int l = alfabet.IndexOf(words[i].Last());
                int res = l + alfabet.Length - int.Parse(words[i].Remove(words[i].Length - 1));
                if (res >= alfabet.Length)
                {
                    for (; res >= alfabet.Length;)
                    {
                        res -= alfabet.Length;
                    }
                }
                rtrn += alfabet[res].ToString();
            }
            return rtrn;
        }

    }
}
