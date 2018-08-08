using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialisee
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\c.adedeji\\Documents\\Visual Studio 2017\\Projects\\Algorithms\\Serialisee\\datatypes.txt";

            List<Datavalue> coord = new List<Datavalue>();

            using (var streamReader = File.OpenText(path))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var cust = DeserailiseJson(line);

                    coord.Add(cust);
                }
            }


            Console.ReadLine();
        }

        static Datavalue DeserailiseJson(string json)
        {
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Datavalue));
                Datavalue response = (Datavalue)jsonSerializer.ReadObject(stream);

                return response;
            }
        }
    }
   
}
