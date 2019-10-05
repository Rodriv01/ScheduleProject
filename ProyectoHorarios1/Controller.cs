using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ProyectoHorarios1
{
    public class Controller
    {
        private MongoClient connection;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public Controller()
        {
            connection = new MongoClient("mongodb://localhost:27017");
            database = connection.GetDatabase("ProjectSchedule");
            collection = database.GetCollection<BsonDocument>("Signature");
        }

        public void Insert(Signature signature)
        {
            var document = new BsonDocument
                {
                    { "id", signature.Id },
                    { "name", signature.Name },
                    { "group", signature.Group },
                    { "schedule", new BsonDocument{ 
                        { "day", signature.Day }, { "startHour", signature.StartHour }, { "endHour", signature.EndHour }, { "classroom", signature.Clasroom } 
                    } },
                    { "professor", signature.Professor },
                };
            collection.InsertOne(document);
        }

        public void Clean()
        {
            database.DropCollection("Signature");
        }

        public List<Signature> getAll()
        {
            var documents = collection.Find(new BsonDocument()).ToList();

            List<Signature> signatures = new List<Signature>();

            foreach (var document in documents)
            {
                Signature signature = new Signature();
                signature.Id = Convert.ToInt32(document[1]);
                signature.Name = Convert.ToString(document[2]);
                signature.Group = Convert.ToString(document[3]);
                signature.Day = Convert.ToString(document[4][0]);
                signature.StartHour = int.Parse(Convert.ToString(document[4][1]));
                signature.EndHour = int.Parse(Convert.ToString(document[4][2]));
                signature.Clasroom = Convert.ToString(document[4][3]);
                signature.Professor = Convert.ToString(document[5]);
                signatures.Add(signature);
            }

            return signatures;
        }
    }
}
