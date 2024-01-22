using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class Record
    {
        private int recordId {  get; set; }
        private int videoFilmId { get; set; }
        private DateTime takingDate { get; set; }
        private DateTime returningDate { get; set; }
        private bool wasReturned { get; set; }



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







    }
}
