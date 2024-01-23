using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class VideoFilmOnDisc : VideoFilm, IStringConvertible
    {
        private DiscTypes discType;


        public DiscTypes DiscType
        {
            get { return discType; }
            set { discType = value; }
        }


        public VideoFilmOnDisc(int id, bool inVideoLibrary, string title, string studio, string genreString, int releaseYear,
                   string director, string actors, string summary, double rating,
                   string discTypeString)
    : base(id, inVideoLibrary, title, studio, genreString, releaseYear, director, actors, summary, rating)
        {

            if (Enum.TryParse(discTypeString, out DiscTypes discType))
            {
                this.discType = discType;
            }
        }


        ~VideoFilmOnDisc()
        {
            Console.WriteLine("Деструктор для класу \"VideoFilmOnDisc\" було викликано.");
        }


        public string ToStringForFile()
        {
            return
                $"{this.id}~" +
                $"{this.inVideoLibrary}~" +
                $"{this.title}~" +
                $"{this.studio}~" +
                $"{this.genre}~" +
                $"{this.releaseYear}~" +
                $"{this.director}~" +
                $"{this.actors}~" +
                $"{this.summary}~" +
                $"{this.rating}~" +
                $"{this.discType}";
        }

        public string ToStringForWrite()
        {
            return
                $"ID: {this.id}\n" +
                "Фільм записано на диску\n" +
                (this.inVideoLibrary ? "Фільм у відеотеці\n" : "Фільм у користувача\n") +
                $"Назва: {this.title}\n" +
                $"Студія: {this.studio}\n" +
                $"Жанр: {this.genre}\n" +
                $"Рік виходу: {this.releaseYear}\n" +
                $"Режисер: {this.director}\n" +
                $"Актори: {this.actors}\n" +
                $"Опис: {this.summary}\n" +
                $"Рейтинг: {this.rating}\n" +
                $"Тип диску: {this.discType}\n\n";
        }


    }
}
