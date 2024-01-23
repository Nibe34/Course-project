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
                        VideoFilmLibrary.FindMinUnusedId(),
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
                        VideoFilmLibrary.FindMinUnusedId(),
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

        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
