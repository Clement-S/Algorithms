using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class DataStructuresExtensions
    {
        public static void OutputMe(this string name, string nameagain, int times)
        {
            Console.WriteLine($"{name}  {nameagain} ---{times}");         
        }
    }
}
