using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
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

            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }





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


