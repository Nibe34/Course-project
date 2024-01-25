using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class UserCard : IStringConvertible
    {
        private int id;
        private string userName;
        private List<Record> records { get; set; }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public List<Record> Records
        {
            get { return records; }
            set { records = value; }
        }



        public UserCard(int id, string userName)
        {
            this.id = id;
            this.userName = userName;
            this.records = new List<Record>();
        }


        public int FindMinUnusedRecordID()
        {
            if (records.Count == 0)
                return 1;

            List<int> sortedIds = records
                .OrderBy(obj => obj.RecordId)
                .Select(obj => obj.RecordId)
                .ToList();

            for (int i = 1; i < sortedIds.Max(); i++)
                if (!sortedIds.Contains(i))
                    return i;

            return sortedIds.Max() + 1;
        }




        public void AddRecordToUserCard(Record record)
        {
            records.Add(record);
        }


        ~UserCard()
        {
            Console.WriteLine("Деструктор для класу \"UserCard\" було викликано.");
        }



        public List<Record> GetRecords() 
        { 
            return records;
        }





        public string ToStringForFile()
        {
            string result = $"{this.id}~" +
                            $"{this.userName}";

            foreach (Record record in records)
            {
                result += record.ToStringForFile();
            }

            return result;
        }

        public string ToStringForWrite()
        {
            return
                $"ID: {this.id}\n" +
                $"Ім'я клієнта: {this.userName}\n";
        }




    }
}
