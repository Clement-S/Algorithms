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

            MyClass1 myc = new MyClass1();
            myc.MyMethod(5);
            //Type type = typeof(MyClass1);

            MethodInfo mInfo = myc.GetType().GetMethod("MyMethod");
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(mInfo, typeof(MyAttribute));
            foreach (System.Attribute attr in attrs)
            {
                Console.WriteLine();
            }
            Console.ReadLine();


        }

    }

    
    public class MyClass1
    {
        [My("This is an example attribute.")]
        public void MyMethod(int i)
        {
            return;
        }
    }

    // Define a custom attribute with one named parameter.
    [AttributeUsage(AttributeTargets.All)]
    public class MyAttribute : Attribute
    {
        private string myName;
        public MyAttribute(string name)
        {
            myName = name;
            Console.WriteLine(myName);
        }
        public string Name
        {
            get
            {
                return myName;
            }
        }


    }

}
