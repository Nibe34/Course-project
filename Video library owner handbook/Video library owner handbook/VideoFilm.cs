using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal abstract class VideoFilm
    {
        protected int id {  get; set; }
        protected bool inVideoLibrary { get; set; }
        protected string title { get; set; }
        protected string studio { get; set; }
        protected Genres genre { get; set; }
        protected int releaseYear;
        protected string director { get; set; }
        protected string actors { get; set; }
        protected string summary { get; set; }
        protected double rating;


        public int ReleaseYear
        {
            get
            {
                return releaseYear;
            }
            set
            {
                if (value >= 1900 && value <= DateTime.Now.Year)
                {
                    releaseYear = value;
                }
                else
                {
                    returnMessage("Недопустимий рік. Введіть значення від 1900 до поточного року.");
                }
            }
        }


        public double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    rating = Math.Round(value, 2);
                }
                else
                {
                    returnMessage("Значення рейтингу повинне знаходитись в діапазоні від 1 до 5.");
                }
            }
        }






        public VideoFilm(int id, bool inVideoLibrary, string title, string studio, string genreString, int releaseYear,
                         string director, string actors, string summary, double rating)
        {
            this.id = id;
            this.inVideoLibrary = inVideoLibrary;
            this.title = title;
            this.studio = studio;
            if (Enum.TryParse(genreString, out Genres genre))
            {
                this.genre = genre;
            }
            this.releaseYear = releaseYear;
            this.director = director;
            this.actors = actors;
            this.summary = summary;
            this.rating = rating;
        }



        ~VideoFilm()
        {
            Console.WriteLine("Деструктор для класу \"VideoFilm\" було викликано.");
        }


        public void SerializeToFile(string filePath)
        {
            
        }






        public string returnMessage(string message)
        {
            return message;
        }



        




    }
}
