using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal abstract class VideoFilm
    {
        protected int id;
        protected bool inVideoLibrary;
        protected string title;
        protected string studio;
        protected Genres genre;
        protected int releaseYear;
        protected string director;
        protected string actors;
        protected string summary;
        protected double rating;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool InVideoLibrary
        {
            get { return inVideoLibrary; }
            set { inVideoLibrary = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Studio
        {
            get { return studio; }
            set { studio = value; }
        }

        public Genres Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public string Actors
        {
            get { return actors; }
            set { actors = value; }
        }

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
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
