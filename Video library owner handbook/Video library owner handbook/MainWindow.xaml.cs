using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Video_library_owner_handbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mediaTypeFilter.SelectedIndex = 0;
            genreFilter.SelectedIndex = 0;
            cassetteTypeFilter.SelectedIndex = 0;
            discTypeFilter.SelectedIndex = 0;
            sortType.SelectedIndex = 0;
            sortCriterion.SelectedIndex = 0;

            FileManager.ReadFilmsFromFile();

            //Closing += MainWindow_Closing;



        }

        /*
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Всі зміни будуть збережені.", "Збереження змін", MessageBoxButton.OK);

            // Викликати метод для збереження змін або виконання іншої логіки
            
        }
         */





        public void PrintMessage(string message)
        {
            outputTextBlock.Text += message + Environment.NewLine;
        }





        private void WriteAllFilms_Click(object sender, RoutedEventArgs e)
        {
            foreach (var videoFilm in VideoFilmLibrary.GetVideoFilms())
            {
                if (videoFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    PrintMessage(videoFilmOnCassette.ToStringForWrite());
                }
                else if (videoFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    PrintMessage(videoFilmOnDisc.ToStringForWrite());
                }
            }
        }


        //test
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileManager.WriteFilmsToFile();
        }




        private void AddNewFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CRUD_isCassette.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(CRUD_title.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_studio.Text) ||
                        CRUD_genre.SelectedItem == null ||
                        string.IsNullOrWhiteSpace(CRUD_director.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_actors.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_summary.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_cassetteType.SelectedItem?.ToString()) ||
                        string.IsNullOrWhiteSpace(CRUD_cassetteYear.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_cassetteSerialNumber.Text))
                    {
                        MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля.", "Помилка");
                        return;
                    }

                    double ratingValue;
                    if (!double.TryParse(CRUD_rating.Text, out ratingValue) || ratingValue < 1 || ratingValue > 5)
                    {
                        MessageBox.Show("Поле 'Rating' повинно містити значення від 1 до 5.", "Помилка");
                        return;
                    }

                    VideoFilmOnCassette videoFilmOnCassette = new VideoFilmOnCassette(
                        VideoFilmLibrary.FindMinUnusedFilmID(),
                        true,
                        CRUD_title.Text,
                        CRUD_studio.Text,
                        CRUD_genre.SelectedItem.ToString(),
                        int.Parse(CRUD_releaseYear.Text),
                        CRUD_director.Text,
                        CRUD_actors.Text,
                        CRUD_summary.Text,
                        ratingValue,
                        CRUD_cassetteType.SelectedItem.ToString(),
                        int.Parse(CRUD_cassetteYear.Text),
                        int.Parse(CRUD_cassetteSerialNumber.Text));

                    VideoFilmLibrary.AddFilm(videoFilmOnCassette);
                }
                if (CRUD_isDisc.IsChecked == true)
                {
                    if (string.IsNullOrWhiteSpace(CRUD_title.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_studio.Text) ||
                        CRUD_genre.SelectedItem == null ||
                        string.IsNullOrWhiteSpace(CRUD_director.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_actors.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_summary.Text) ||
                        string.IsNullOrWhiteSpace(CRUD_discType.SelectedItem?.ToString()))
                    {
                        MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля.", "Помилка");
                        return;
                    }

                    double ratingValue;
                    if (!double.TryParse(CRUD_rating.Text, out ratingValue) || ratingValue < 1 || ratingValue > 5)
                    {
                        MessageBox.Show("Поле 'Rating' повинно містити значення від 1 до 5.", "Помилка");
                        return;
                    }

                    VideoFilmOnDisc videoFilmOnDisc = new VideoFilmOnDisc(
                        VideoFilmLibrary.FindMinUnusedFilmID(),
                        true,
                        CRUD_title.Text,
                        CRUD_studio.Text,
                        CRUD_genre.SelectedItem.ToString(),
                        int.Parse(CRUD_releaseYear.Text),
                        CRUD_director.Text,
                        CRUD_actors.Text,
                        CRUD_summary.Text,
                        ratingValue,
                        CRUD_discType.SelectedItem.ToString());
                }
                PrintMessage("Фільм успішно додано до відеотеки\n\n");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних. Будь ласка, перевірте правильність введення числових значень.", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }


        private void DeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmId;
                if (!int.TryParse(CRUD_filmID.Text, out filmId))
                {
                    MessageBox.Show("Некоректний формат введеного ідентифікатора фільму.", "Помилка");
                    return;
                }

                string removalResult = VideoFilmLibrary.RemoveFilmById(filmId);

                PrintMessage(removalResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }



        
        private void UpdateFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmId;
                if (!int.TryParse(CRUD_filmID.Text, out filmId))
                {
                    MessageBox.Show("Некоректний формат введеного ідентифікатора фільму.", "Помилка");
                    return;
                }

                if (string.IsNullOrWhiteSpace(CRUD_title.Text) ||
                    string.IsNullOrWhiteSpace(CRUD_studio.Text) ||
                    CRUD_genre.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(CRUD_director.Text) ||
                    string.IsNullOrWhiteSpace(CRUD_actors.Text) ||
                    string.IsNullOrWhiteSpace(CRUD_summary.Text) ||
                    string.IsNullOrWhiteSpace(CRUD_cassetteType.SelectedItem?.ToString()) ||
                    string.IsNullOrWhiteSpace(CRUD_cassetteYear.Text) ||
                    string.IsNullOrWhiteSpace(CRUD_cassetteSerialNumber.Text))
                {
                    MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля.", "Помилка");
                    return;
                }

                double ratingValue;
                if (!double.TryParse(CRUD_rating.Text, out ratingValue) || ratingValue < 1 || ratingValue > 5)
                {
                    MessageBox.Show("Поле 'Rating' повинно містити значення від 1 до 5.", "Помилка");
                    return;
                }

                string removalResult = VideoFilmLibrary.RemoveFilmById(filmId);

                PrintMessage(removalResult);

                if (removalResult.StartsWith("Фільм з ідентифікатором"))
                {
                    if (CRUD_isCassette.IsChecked == true)
                    {
                        VideoFilmOnCassette videoFilmOnCassette = new VideoFilmOnCassette(
                            filmId,
                            true,
                            CRUD_title.Text,
                            CRUD_studio.Text,
                            CRUD_genre.Text,
                            int.Parse(CRUD_releaseYear.Text),
                            CRUD_director.Text,
                            CRUD_actors.Text,
                            CRUD_summary.Text,
                            ratingValue,
                            CRUD_cassetteType.Text,
                            int.Parse(CRUD_cassetteYear.Text),
                            int.Parse(CRUD_cassetteSerialNumber.Text));

                        VideoFilmLibrary.AddFilm(videoFilmOnCassette);
                    }
                    else if (CRUD_isDisc.IsChecked == true)
                    {
                        VideoFilmOnDisc videoFilmOnDisc = new VideoFilmOnDisc(
                            filmId,
                            true,
                            CRUD_title.Text,
                            CRUD_studio.Text,
                            CRUD_genre.Text,
                            int.Parse(CRUD_releaseYear.Text),
                            CRUD_director.Text,
                            CRUD_actors.Text,
                            CRUD_summary.Text,
                            ratingValue,
                            CRUD_discType.Text);

                        VideoFilmLibrary.AddFilm(videoFilmOnDisc);
                    }

                    PrintMessage("Фільм успішно оновлено.\n\n");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних. Будь ласка, перевірте правильність введення числових значень.", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<VideoFilm> foundVideoFilms = VideoFilmLibrary.GetVideoFilms()
                .Where(obj => obj.Title.Contains(searchField.Text) || obj.Director.Contains(searchField.Text) || obj.Studio.Contains(searchField.Text))
                .ToList();

            if (foundVideoFilms.Count == 0)
            {
                PrintMessage("Фільми за заданим запитом не знайдено.");
            }
            else
            {
                PrintMessage("Фільми за заданим запитом:");
            }

            foreach(var videoFilm in foundVideoFilms)
            {
                if (videoFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    PrintMessage(videoFilmOnCassette.ToStringForWrite());
                }
                else if (videoFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    PrintMessage(videoFilmOnDisc.ToStringForWrite());
                }
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (mediaTypeFilter.SelectedIndex == 0 &&
               discTypeFilter.SelectedIndex == 0 &&
                cassetteTypeFilter.SelectedIndex == 0 &&
                genreFilter.SelectedIndex == 0 &&
                string.IsNullOrWhiteSpace(yearFilter.Text))
            {
                MessageBox.Show("Oберіть принаймні один фільтр.", "Помилка");
                return;
            }


            List<VideoFilm> filteredFilms = VideoFilmLibrary.GetVideoFilms();

            if (!string.IsNullOrEmpty(yearFilter.Text))
            {
                if (int.TryParse(mediaTypeFilter.Text, out int value))
                {
                    MessageBox.Show("Поле \"рік\" може містити лише цілі числа.", "Помилка");
                    return;
                }

                filteredFilms = filteredFilms
                    .Where(film => film.ReleaseYear == int.Parse(yearFilter.Text))
                    .ToList();
            }


            if (genreFilter.SelectedIndex != 0)
            {
                filteredFilms = filteredFilms
                    .Where(film => film.Genre == (Genres)Enum.Parse(typeof(Genres), ((ComboBoxItem)genreFilter.SelectedItem).Content.ToString()))
                    .ToList();
            }

            if (mediaTypeFilter.SelectedIndex == 1)
            {
                List<VideoFilmOnCassette> cassetteVideoFilms = filteredFilms
                    .OfType<VideoFilmOnCassette>()
                    .ToList();

                if (cassetteTypeFilter.SelectedIndex != 0)
                {
                    cassetteVideoFilms = cassetteVideoFilms
                        .Where(film => film.CassetteType == (CassetteTypes)Enum.Parse(typeof(CassetteTypes), ((ComboBoxItem)cassetteTypeFilter.SelectedItem).Content.ToString()))
                        .ToList();
                }

                foreach (var videoFilm in cassetteVideoFilms)
                {
                    PrintMessage(videoFilm.ToStringForWrite());
                }
                return;
            }

            if (mediaTypeFilter.SelectedIndex == 2)
            {
                List<VideoFilmOnDisc> discVideoFilms = filteredFilms
                    .OfType<VideoFilmOnDisc>()
                    .ToList();

                if (discTypeFilter.SelectedIndex != 0)
                {
                    discVideoFilms = discVideoFilms
                        .Where(film => film.DiscType == (DiscTypes)Enum.Parse(typeof(DiscTypes), ((ComboBoxItem)discTypeFilter.SelectedItem).Content.ToString()))
                        .ToList();
                }

                foreach (var videoFilm in discVideoFilms)
                {
                    PrintMessage(videoFilm.ToStringForWrite());
                }
                return;
            }


            foreach (var videoFilm in filteredFilms)
            {
                if (videoFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    PrintMessage(videoFilmOnCassette.ToStringForWrite());
                }
                else if (videoFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    PrintMessage(videoFilmOnDisc.ToStringForWrite());
                }
            }


        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (sortType.SelectedIndex == 0)
            {
                MessageBox.Show("Oберіть тип сортування.", "Помилка");
                return;
            }

            List<VideoFilm> sortedVideoFilms = new List<VideoFilm>();

            if (sortCriterion.SelectedIndex == 0)
            {
                sortedVideoFilms = sortType.SelectedIndex == 1
                    ? VideoFilmLibrary.GetVideoFilms().OrderBy(film => film.Id).ToList()
                    : VideoFilmLibrary.GetVideoFilms().OrderByDescending(film => film.Id).ToList();
            }
            else if (sortCriterion.SelectedIndex == 1)
            {
                sortedVideoFilms = sortType.SelectedIndex == 1
                    ? VideoFilmLibrary.GetVideoFilms().OrderBy(film => film.Title).ToList()
                    : VideoFilmLibrary.GetVideoFilms().OrderByDescending(film => film.Title).ToList();
            }
            else if (sortCriterion.SelectedIndex == 2)
            {
                sortedVideoFilms = sortType.SelectedIndex == 1
                    ? VideoFilmLibrary.GetVideoFilms().OrderBy(film => film.ReleaseYear).ToList()
                    : VideoFilmLibrary.GetVideoFilms().OrderByDescending(film => film.ReleaseYear).ToList();
            }
            else if (sortCriterion.SelectedIndex == 3)
            {
                sortedVideoFilms = sortType.SelectedIndex == 1
                    ? VideoFilmLibrary.GetVideoFilms().OrderBy(film => film.Rating).ToList()
                    : VideoFilmLibrary.GetVideoFilms().OrderByDescending(film => film.Rating).ToList();
            }


            foreach (var videoFilm in sortedVideoFilms)
            {
                if (videoFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    PrintMessage(videoFilmOnCassette.ToStringForWrite());
                }
                else if (videoFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    PrintMessage(videoFilmOnDisc.ToStringForWrite());
                }
            }

        }

        private void PrintAllClients_Click(object sender, RoutedEventArgs e)
        {
            foreach (var client in VideoFilmLibrary.GetUserCards())
            {
                PrintMessage(client.ToStringForWrite());
            }
        }

        private void AddNewClient_Click(object sender, RoutedEventArgs e)
        {
            VideoFilmLibrary.AddUserCard(new UserCard(VideoFilmLibrary.FindMinUnusedUserID(), addClientName.Text));
            PrintMessage("Клієнта успішно додано.");
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId;
                if (!int.TryParse(CRUD_filmID.Text, out userId))
                {
                    MessageBox.Show("Некоректний формат введеного ідентифікатора фільму.", "Помилка");
                    return;
                }

                string removalResult = VideoFilmLibrary.RemoveUserCardById(userId);

                PrintMessage(removalResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }
    }
}
