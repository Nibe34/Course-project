﻿using System;
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
        public static void AddFilms(List<VideoFilm> list)
        {
            VideoFilmLibrary.videoFilms.AddRange(list);
        }

        public static void AddUserCard(UserCard userCard)
        {
            userCards.Add(userCard);
        }


        public static int FindMinUnusedUserID()
        {
            if (VideoFilmLibrary.userCards.Count == 0)
                return 1;

            List<int> sortedIds = VideoFilmLibrary.userCards
                .OrderBy(obj => obj.Id)
                .Select(obj => obj.Id)
                .ToList();

            for (int i = 1; i < sortedIds.Max(); i++)
                if (!sortedIds.Contains(i))
                    return i;

            return sortedIds.Max() + 1;
        }

        
        public static int FindMinUnusedFilmID()
        {
            if (VideoFilmLibrary.videoFilms.Count == 0) 
                return 1;

            List<int> sortedIds = VideoFilmLibrary.videoFilms
                .OrderBy(obj => obj.Id)
                .Select(obj => obj.Id)
                .ToList();

            for (int i = 1;  i < sortedIds.Max(); i++) 
                if (!sortedIds.Contains(i)) 
                    return i;

            return sortedIds.Max() + 1;
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
