using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рыбалка.Classes
{
    public class Users
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }


        public Users(int _id, string _surname, string _name, string _otch, string _login, string _password, string _role)
        {
            id = _id;
            surname = _surname;
            name = _name;
            patronymic = _otch;
            login = _login;
            password = _password;
            role = _role;

        }
    }
}
