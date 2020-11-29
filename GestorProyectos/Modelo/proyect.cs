using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GestorProyectos.Modelo
{
    [DataContract]
    public class proyect
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        [DataMember]
        public string Precio { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}