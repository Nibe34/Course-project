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

        public static void AddFilm(VideoFilm videoFilm)
        {
            VideoFilmLibrary.videoFilms.Add(videoFilm);
        }
        public static void AddFilms(List<VideoFilm> list)
        {
            VideoFilmLibrary.videoFilms.AddRange(list);
        }

        /*
        public void ReadFilms(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] elements = line.Split('~');

                VideoFilmOnCassette film = new VideoFilmOnCassette(int.Parse(elements[0]), bool.Parse(elements[1]),
                    elements[2], elements[3], elements[4], int.Parse(elements[5]), elements[6], elements[7],
                    elements[8], double.Parse(elements[9]), elements[10], int.Parse(elements[11]), int.Parse(elements[12]));
                videoFilms.Add(film);
            }

        }*/

    }
}
