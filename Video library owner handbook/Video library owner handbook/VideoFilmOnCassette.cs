using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_library_owner_handbook
{
    internal class VideoFilmOnCassette : VideoFilm, IStringConvertible
    {
        private CassetteTypes cassetteType { get; set; }
        private int cassetteSeriesReleaseYear { get; set; }
        private int cassetteNumberInSeries { get; set; }




        public VideoFilmOnCassette(int id, bool inVideoLibrary, string title, string studio, string genreString, int releaseYear,
                           string director, string actors, string summary, double rating,
                           string cassetteTypeString, int cassetteSeriesReleaseYear,
                           int cassetteNumberInSeries)
    : base(id, inVideoLibrary, title, studio, genreString, releaseYear, director, actors, summary, rating)
        {
            if (Enum.TryParse(cassetteTypeString, out CassetteTypes cassetteType))
            {
                this.cassetteType = cassetteType;
            }
            this.cassetteSeriesReleaseYear = cassetteSeriesReleaseYear;
            this.cassetteNumberInSeries = cassetteNumberInSeries;
        }


        ~VideoFilmOnCassette()
        {
            Console.WriteLine("Деструктор для класу \"VideoFilmOnCassette\" було викликано.");
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
                $"{this.cassetteType}~" +
                $"{this.cassetteSeriesReleaseYear}~" +
                $"{this.cassetteNumberInSeries}";
        }

        public string ToStringForWrite()
        {
            return
                $"ID: {this.id}\n" +
                "Фільм записано на касеті\n" +
                (this.inVideoLibrary ? "Фільм у відеотеці\n" : "Фільм у користувача\n") +
                $"Назва: {this.title}\n" +
                $"Студія: {this.studio}\n" +
                $"Жанр: {this.genre}\n" +
                $"Рік виходу: {this.releaseYear}\n" +
                $"Режисер: {this.director}\n" +
                $"Актори: {this.actors}\n" +
                $"Опис: {this.summary}\n" +
                $"Рейтинг: {this.rating}\n" +
                $"Тип касети: {this.cassetteType}\n" +
                $"Рік виходу серії касети: {this.cassetteSeriesReleaseYear}\n" +
                $"Номер касети в серії: {this.cassetteNumberInSeries}\n\n";
        }




    }
}
