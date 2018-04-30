using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            //RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            //byte[] data = new byte[5 * 4096 + 320];
            ////fill data array with arbitrary data
            //rng.GetNonZeroBytes(data);
            ////initialize HashAlgorithm instance
            //SHA1Managed sha = new SHA1Managed();

            //int offset = 0;
            //int blockSize = 64;

            //// reset algorithm internal state
            //sha.Initialize();

            //while (data.Length - offset >= blockSize)
            //{
            //    offset += sha.TransformBlock(data, offset, blockSize, data, offset);                           
            //}

            //sha.TransformFinalBlock(data, offset, data.Length - offset);

            //// get calculated hash value
            //byte[] hash2 = sha.Hash;

            string pattern = @"(\d{3})-(\d{3}-\d{4})";
            string input = "212-555-6666 906-932-1111 415-222-3333 425-888-9999";
            MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(input, pattern);
            var results = (from Match m in matches select m.Groups[2]).ToList();
            
            foreach(var result in results)
                Console.WriteLine(result);
            //foreach (Match match in matches)
            //{
            //    Console.WriteLine("Area Code:        {0}", match.Groups[1].Value);
            //    Console.WriteLine("Telephone number: {0}", match.Groups[2].Value);
            //    Console.WriteLine();
            //}
            

            Console.ReadLine();
        }


        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
                Console.WriteLine("im in between results");
            }
        }
    }

   
}


