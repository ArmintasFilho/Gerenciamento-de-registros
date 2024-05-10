using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciamento_de_registros
{
    public static class Conexao
    {
        public static readonly string Server = "mongodb://localhost:27017";
        public static readonly string Db = "cadastro";
        public static readonly string ColletionPessoas = "pessoas";

        public static IMongoCollection<Pessoas> AbrirColecaoPessoas() {
            var client = new MongoClient(Server);
            var db = client.GetDatabase(Db);
            return db.GetCollection<Pessoas>(ColletionPessoas);
        }
    }
}
