using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class Record : IStringConvertible
    {
        private int recordId {  get; set; }
        private int videoFilmId { get; set; }
        private DateTime takingDate { get; set; }
        private DateTime returningDate { get; set; }
        private bool wasReturned { get; set; }


        public int RecordId
        {
            get { return recordId; }
            set { recordId = value; }
        }

        public int VideoFilmId
        {
            get { return videoFilmId; }
            set { videoFilmId = value; }
        }

        public DateTime TakingDate
        {
            get { return takingDate; }
            set { takingDate = value; }
        }

        public DateTime ReturningDate
        {
            get { return returningDate; }
            set { returningDate = value; }
        }

        public bool WasReturned
        {
            get { return wasReturned; }
            set { wasReturned = value; }
        }



        public Record(int recordId, int videoFilmId, DateTime takingDate, DateTime returningDate, bool wasReturned)
        {
            this.recordId = recordId;
            this.videoFilmId = videoFilmId;
            this.takingDate = takingDate;
            this.returningDate = returningDate;
            this.wasReturned = wasReturned;
        }

        public Record(int recordId, int videoFilmId, DateTime takingDate, DateTime returningDate)
        {
            this.recordId = recordId;
            this.videoFilmId = videoFilmId;
            this.takingDate = takingDate;
            this.returningDate = returningDate;
            this.wasReturned = false;
        }

        ~Record()
        {
            Console.WriteLine("Деструктор для класу \"Record\" було викликано.");
        }





        


        public string ToStringForFile()
        {
            return "~" +
                $"{this.recordId}~" +
                $"{this.videoFilmId}~" +
                $"{this.takingDate}~" +
                $"{this.returningDate}~" +
                $"{this.wasReturned}";
        }

        public string ToStringForWrite()
        {
            return
                $"ID записа: {this.recordId}\n" +
                $"ID фільму: {this.videoFilmId}\n" +
                $"Дата взяття: {this.takingDate}\n" +
                $"Дата повернення: {this.returningDate}\n" +
                $"Факт повернення: " +
                (this.wasReturned ? "повернено\n" : "не повернено\n");
        }


    }
}
