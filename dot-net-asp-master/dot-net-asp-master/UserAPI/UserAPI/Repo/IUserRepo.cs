using UserAPI.Model;
namespace UserAPI.Repo
{
    public interface IUserRepo
    {
        // List<Users> GetUsers();
        // //get entire list of users
        //Users GetUser(int id);
        // //get object user based on ID

        //int Updateusers(int id, Users x);
        //int Deleteusers(int id);

        int Addusers(Users x);
        //taking in Users model

        bool Login(string username, string password);

    }
}
