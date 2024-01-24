using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Video_library_owner_handbook
{
    internal class FileManager
    {
        public static void WriteFilmsToFile()
        {
            File.WriteAllText("FilmsOnCassette.txt", string.Empty);
            File.WriteAllText("FilmsOnDisc.txt", string.Empty);

            foreach (var item in VideoFilmLibrary.GetVideoFilms())
            {
                if (item is VideoFilmOnCassette)
                {
                    VideoFilmOnCassette videoFilm = (VideoFilmOnCassette)item;
                    File.AppendAllText("FilmsOnCassette.txt", videoFilm.ToStringForFile() + Environment.NewLine);
                }
                else if (item is VideoFilmOnDisc)
                {
                    VideoFilmOnDisc videoFilm = (VideoFilmOnDisc)item;
                    File.AppendAllText("FilmsOnDisc.txt", videoFilm.ToStringForFile() + Environment.NewLine);
                }
            }
        }





        public static void ReadFilmsFromFile()
        {
            string[] lines = File.ReadAllLines("FilmsOnCassette.txt");

            foreach (string line in lines)
            {
                string[] elements = line.Split('~');

                VideoFilmOnCassette film = new VideoFilmOnCassette(int.Parse(elements[0]),
                                                                   bool.Parse(elements[1]),
                                                                   elements[2],
                                                                   elements[3],
                                                                   elements[4],
                                                                   int.Parse(elements[5]),
                                                                   elements[6],
                                                                   elements[7],
                                                                   elements[8],
                                                                   double.Parse(elements[9]),
                                                                   elements[10],
                                                                   int.Parse(elements[11]),
                                                                   int.Parse(elements[12]));
                VideoFilmLibrary.AddFilm(film);
            }

            string[] lines1 = File.ReadAllLines("FilmsOnDisc.txt");

            foreach (string line in lines1)
            {
                string[] elements = line.Split('~');

                VideoFilmOnDisc film = new VideoFilmOnDisc(int.Parse(elements[0]),
                                                           bool.Parse(elements[1]),
                                                           elements[2],
                                                           elements[3],
                                                           elements[4],
                                                           int.Parse(elements[5]),
                                                           elements[6],
                                                           elements[7],
                                                           elements[8],
                                                           double.Parse(elements[9]),
                                                           elements[10]);
                VideoFilmLibrary.AddFilm(film);
            }
        }





        public static void WriteUserCardsToFile()
        {
            File.WriteAllText("UserCards.txt", string.Empty);

            foreach (var userCard in VideoFilmLibrary.GetUserCards())
            {
                File.AppendAllText("UserCards.txt", userCard.ToStringForFile() + Environment.NewLine);
            }
        }




        
        public static void ReadUserCardsFromFile()
        {
            string[] lines = File.ReadAllLines("UserCards.txt");

            foreach (string line in lines)
            {
                string[] elements = line.Split('~');

                UserCard userCard = new UserCard(int.Parse(elements[0]), elements[1]);

                if (elements.Length > 2)
                    for (int i = 2; i < elements.Length; i += 5)
                    {
                        userCard.AddRecordToUserCard(new Record(int.Parse(elements[i]),
                                                                int.Parse(elements[i + 1]),
                                                                DateTime.Parse(elements[i + 2]),
                                                                DateTime.Parse(elements[i + 3]),
                                                                bool.Parse(elements[i + 4])));
                    }

                VideoFilmLibrary.AddUserCard(userCard);
            }
        }
    }
}
