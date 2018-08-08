using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialisee
{
    [DataContract]
    class Datavalue
    {
        [DataMember]
        public string Datatype { get; set; }

        [DataMember]
        public string Hostname { get; set; }

        [DataMember]
        public string Listener { get; set; }

        [DataMember]
        public string Timestamp { get; set; }

        [DataMember]
        public decimal Duration { get; set; }

    }
}
