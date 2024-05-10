using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_de_registros
{
    public class Pessoas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Data_Nasc { get; set; }
        public string Telefone { get; set; }

    }
}
