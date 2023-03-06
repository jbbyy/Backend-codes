using System.ComponentModel.DataAnnotations.Schema;

namespace AuthPractice.Model
{
    public class Users
    {
        
        public int UsersId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string  email { get; set; }
        public string dob { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

        public string gender { get; set; }

    }
}
