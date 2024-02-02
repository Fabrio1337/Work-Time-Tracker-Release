using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeTracker
{
    internal class Ses
    {
        [Key]
       public int ID_user { get; set; }

        public string Session;

        public string session
        {
            get { return Session; }
            set { Session = value; }
        }

        public Ses() { }

        public Ses(string Sessionn)
        {
            Session = Sessionn;
        }
    }
}
