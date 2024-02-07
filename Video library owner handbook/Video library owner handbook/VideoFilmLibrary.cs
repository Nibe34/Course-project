using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Video_library_owner_handbook
{
    internal class VideoFilmLibrary
    {
        private static List<VideoFilm> videoFilms = new List<VideoFilm>();
        private static List<UserCard> userCards = new List<UserCard>();

        private static int nextFilmID;
        private static int nextUserID;


        public static int NextFilmID
        {
            get { return nextFilmID; }
            set { nextFilmID = value; }
        }

        public static int NextUserID
        {
            get { return nextUserID; }
            set { nextUserID = value; }
        }


        public VideoFilmLibrary()
        {
            videoFilms = new List<VideoFilm>();
            userCards = new List<UserCard>();
        }


        ~VideoFilmLibrary()
        {
            Console.WriteLine("Деструктор для класу \"VideoFilmLibrary\" було викликано.");
        }



        public static List<VideoFilm> GetVideoFilms()
        {
            return videoFilms;
        }

        public static List<UserCard> GetUserCards()
        {
            return userCards;
        }

        public static void AddFilm(VideoFilm videoFilm)
        {
            VideoFilmLibrary.videoFilms.Add(videoFilm);
        }

        public static void AddUserCard(UserCard userCard)
        {
            userCards.Add(userCard);
        }


        public static int GetNextUserID()
        {
            return nextUserID++;
        }

        
        public static int GetNextFilmID()
        {
            return nextFilmID++;
        }


        public static string RemoveFilmById(int filmId)
        {
            VideoFilm filmToRemove = videoFilms.FirstOrDefault(film => film.Id == filmId);

            if (filmToRemove != null)
            {
                videoFilms.Remove(filmToRemove);
                return ($"Фільм з ідентифікатором {filmId} був успішно видалений.\n\n");
            }
            else
            {
                return ($"Ідентифікатор {filmId} не знайдено в бібліотеці.\n\n");
            }
        }


        public static string RemoveUserCardById(int userId)
        {
            UserCard userCardToRemove = userCards.FirstOrDefault(user => user.Id == userId);

            if (userCardToRemove != null)
            {
                userCards.Remove(userCardToRemove);
                return ($"Користувач з ідентифікатором {userId} був успішно видалений.\n\n");
            }
            else
            {
                return ($"Ідентифікатор {userId} не знайдено в бібліотеці.\n\n");
            }
        }


        public static VideoFilm GetFilmById(int filmId)
        {
            return videoFilms.FirstOrDefault(film => film.Id == filmId);
        }


        public static UserCard GetUserCardById(int userId)
        {
            return userCards.FirstOrDefault(userCard => userCard.Id == userId);
        }


    }
}
