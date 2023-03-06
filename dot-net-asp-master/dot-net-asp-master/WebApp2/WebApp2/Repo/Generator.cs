using System.Security.Cryptography.X509Certificates;

namespace WebApp2.Repo
{
    public class Generator : Igenerator
    {
        Guid guid;
        //generate random IDs each time 
        public Generator()
            //constructor ->  generate new random ID each time
        {
            guid = Guid.NewGuid();
        }

        public string GetID()
        {
            return guid.ToString();
        }
    }
}
