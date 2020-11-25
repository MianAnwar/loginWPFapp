using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DataAccessLayer;
using WpfApp1.Model;

namespace WpfApp1.BusniessLogic
{
    class LogicLayer
    {
        DataLayer dl = new DataLayer();

        public int login(string uname, string upwd)
        {
            return dl.verifyCredentials(uname, upwd);
        }

        public int register(User u)
        {
            // CreateUser to a DB
            return dl.insertToUsersDB(u);
        }

        public List<User> getUsers()
        {
            List<User> allUsers = new List<User>();
            allUsers = dl.getAllUsersFromDB();
            //allUsers.Add(new User("M", "Ali", "mail", "123"));
            //allUsers.Add(new User("Zahid", "Akram", "mail2", "5233"));
            //allUsers.Add(new User("Ahsan", "Azeem", "mail3", "2323"));
            return allUsers;
        }
    }
}
