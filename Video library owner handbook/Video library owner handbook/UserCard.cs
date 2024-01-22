using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class UserCard
    {
        private uint id { get; set; }
        private string userName { get; set; }
        private List<Record> records { get; set; }




        public UserCard(uint id, string userName)
        {
            this.id = id;
            this.userName = userName;
            records = new List<Record>();
        }


        ~UserCard()
        {
            Console.WriteLine("Деструктор для класу \"UserCard\" було викликано.");
        }









    }
}
