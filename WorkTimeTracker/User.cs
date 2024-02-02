using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeTracker
{
    class User
    {
        [Key]
        public int ID_user { get; set; }

        private string NameUser, PasswordUser;
        public string nameUser
        {
            get { return NameUser; }
            set { NameUser = value; }
        }
        public string passwordUser
        {
            get { return PasswordUser; }
            set { PasswordUser = value; }
        }


        public User() { }
        public User (string Name, string Password)
        {
            NameUser = Name;
            PasswordUser = Password;

        }
    }
}
