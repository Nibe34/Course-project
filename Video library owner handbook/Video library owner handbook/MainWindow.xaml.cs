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

            InitialSettings();


            mediaTypeFilter.SelectedIndex = 0;
            genreFilter.SelectedIndex = 0;
            cassetteTypeFilter.SelectedIndex = 0;
            discTypeFilter.SelectedIndex = 0;
            sortType.SelectedIndex = 0;
            sortCriterion.SelectedIndex = 0;


            Closing += MainWindow_Closing;
        }

        // початкові налаштування (завантаження даних)
        private static void InitialSettings()
        {
            FileManager.ReadFilmsFromFile();
            FileManager.ReadUserCardsFromFile();
        }


        // збереження даних
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Всі зміни будуть збережені.", "Збереження змін", MessageBoxButton.OK);

            FileManager.WriteFilmsToFile();
            FileManager.WriteUserCardsToFile();
        }
         


        // вивід повідомлень
        public void PrintMessage(string message)
        {
            outputTextBlock.Text += message + Environment.NewLine;
        }











        // посібник користувача
        private void Help_AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Дана програма представляє собою систему управління базою даних \"Довідник власника відеотеки\"." +
                "Вона розроблена спеціально для власника (адміністратора) відеотеки та дозволяє йому здійснювати базові " +
                "операції, пов'язані із управлінням власною відеотекою, а саме: роботу з базою фільмів, роботу з базою " +
                "клієнтів (користувачів, підписників) відеотеки, видачу та повернення відеофільмів а також деякі додаткові функції.\n");
        }

        private void Help_LoadFromDB_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Завантаження даних із БД відбувається під час запуску програми, тому окремої кнопки для цього " +
                "не передбачено. Прохання не змінювати інформацію в БД шляхом редагування файлів вручну, оскільки це " +
                "може призвести до некоректного зчитування даних та помилок під час роботи програми.\n");
        }

        private void Help_SaveToDB_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Збереження даних в БД відбувається автоматично при закритті програми, тому окремої кнопки для цього " +
                "не передбачено. При цьому користувачу виведеться повідомлення про те, що його дані було збережено. " +
                "Неспоніване завершення роботи програми (перезавантаження комп'ютера, закриття через диспетчер завдань тощо) " +
                "може призвести до втрати даних та повернення БД до стану перед останнім запуском програми.\n");
        }

        private void Help_GiveFilm_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Для видачі користувачу фільму перейдіть до відповідної вкладки меню. Необхідно ввести ідентифікатор " +
                "фільму, який необхідно видати та клієнта, якому видається фільм, а також вказати дату видачі та заплановану " +
                "дату повернення фільму.\n");
        }

        private void Help_ReturnFilm_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Для повернення фільму перейдіть до відповідної вкладки меню. Необхідно ввести ідентифікатор " +
                "фільму, який повертається клієнтом та самого клієнта, а також вказати фактичну дату повернення фільму. " +
                "Якщо фактична дата повернення пізніше запланованої, на екран виведеться повідомлення із проханням ввести " +
                "санкції стосовно клієнта. Розмір ти вид санкцій встановлює адміністратор відеотеки. \nТакож в програмі " +
                "передбачена спеціальна кнопка для виводу списку неповернених клієнтом відеофільмів.\n");
        }

        private void Help_ClientBase_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("В програмі передбачено функціонал для перегляду бази клієнтів, а також додавання та видалення " +
                "клієнтів. Щоб скористатися даним функціоналом перейдіть до відповідної вкладки меню.\n");
        }

        private void Help_FilmsList_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("На вкладці \"Робота з базою фільмів\" передбачена кнопка для виводу всіх фільмів відеотеки.\n");
        }

        private void Help_AddFilm_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("На вкладці \"Робота з базою фільмів\" передбачена кнопка для додавання фільму до відеотеки. " +
                "Для додавання нового фільму необхідно спершу заповнити всі поля з інформацією щодо фільму. " +
                "Також при додаванні фільму необхідно обрати тип носія, на якому записаний цей фільм (диск або відеокасета). " +
                "Для кожного з цих носіїв передбачено унікальні поля (наприклад тип диску чи серійний номер касети). " +
                "Заповнення полів, що не надежать обраному типу носія не має сенсу.\n");
        }

        private void Help_UpdateFilm_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("На вкладці \"Робота з базою фільмів\" передбачена кнопка для редагування (оновлення) фільму. " +
                "Для редагування фільму необхідно заповнити всі поля з оновленою інформацією щодо фільму, а також поле ID.\n");
        }

        private void Help_DeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("На вкладці \"Робота з базою фільмів\" передбачена кнопка для видалення фільму. для видалення необхідно " +
                "ввести ідентифікатор (не)потрібного фільму та натиснути на кнопку.\n");
        }

        private void Help_Search_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Для пошуку фільму перейдіть на відповідну вкладку меню та введіть ключове слово (фрагмент). " +
                "Пошук відбувається за назвою фільму, режисером та назвою студії.\n");
        }

        private void Help_Filter_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Для фільтрації фільмів перейдіть на відповідну вкладку меню та оберіть бажані параметри фільтрації. " +
                "Вибір \"Типу диску\" та \"Типу касети\" має сенс лише якщо ви обрали відповідний тип носія. Жоден фільтр " +
                "не є обов'язковим.\n");
        }

        private void Help_Sort_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Для сортування фільмів перейдіть на відповідну вкладку меню та оберіть тип та критерій сортування.\n");
        }

        private void Help_AdditionalFeatures_Click(object sender, RoutedEventArgs e)
        {
            PrintMessage("Вкладка \"Додатковий функціонал\" містить різні функції, що можуть бути корисними залежно від ситуації, " +
                "а саме: \"Визначити улюблений жанр користувача\", \"Запропонувати випадковий непереглянутий користувачем фільм\", " +
                "\"Вивести топ-3 найпереглядуваніші фільми в відеотеці\", \"Перевірити середній термін повернення фільмів користувачем\", " +
                "\"Пеоеглянути весь список фільмів, які брав користувач\" та \"Запропонувати перелік снеків до фільму\".\n");
        }












        // CRUD
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

                    if (string.IsNullOrWhiteSpace(CRUD_releaseYear.Text) ||
                        int.Parse(CRUD_releaseYear.Text) < 1900)
                    {
                        MessageBox.Show("Рік виходу фільму повинен бути не менше 1900.", "Помилка");
                    }

                    if (string.IsNullOrWhiteSpace(CRUD_cassetteYear.Text) ||
                        int.Parse(CRUD_cassetteYear.Text) < 1900)
                    {
                        MessageBox.Show("Рік виходу касети повинен бути не менше 1900.", "Помилка");
                    }

                    if (string.IsNullOrWhiteSpace(CRUD_cassetteSerialNumber.Text) ||
                        int.Parse(CRUD_cassetteSerialNumber.Text) < 0)
                    {
                        MessageBox.Show("Серійний номер касети повинен бути не менше 0.", "Помилка");
                    }

                    VideoFilmOnCassette videoFilmOnCassette = new VideoFilmOnCassette(
                        VideoFilmLibrary.FindMinUnusedFilmID(),
                        true,
                        CRUD_title.Text,
                        CRUD_studio.Text,
                        (CRUD_genre.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                        int.Parse(CRUD_releaseYear.Text),
                        CRUD_director.Text,
                        CRUD_actors.Text,
                        CRUD_summary.Text,
                        ratingValue,
                        (CRUD_cassetteType.SelectedItem as ComboBoxItem)?.Content?.ToString(),
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

                    if (string.IsNullOrWhiteSpace(CRUD_releaseYear.Text) ||
                        int.Parse(CRUD_releaseYear.Text) < 1900)
                    {
                        MessageBox.Show("Рік виходу фільму повинен бути не менше 1900.", "Помилка");
                    }


                    VideoFilmOnDisc videoFilmOnDisc = new VideoFilmOnDisc(
                        VideoFilmLibrary.FindMinUnusedFilmID(),
                        true,
                        CRUD_title.Text,
                        CRUD_studio.Text,
                        (CRUD_genre.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                        int.Parse(CRUD_releaseYear.Text),
                        CRUD_director.Text,
                        CRUD_actors.Text,
                        CRUD_summary.Text,
                        ratingValue,
                        (CRUD_discType.SelectedItem as ComboBoxItem)?.Content?.ToString());

                    VideoFilmLibrary.AddFilm(videoFilmOnDisc);
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

                if (string.IsNullOrWhiteSpace(CRUD_releaseYear.Text) ||
                        int.Parse(CRUD_releaseYear.Text) < 1900)
                {
                    MessageBox.Show("Рік виходу фільму повинен бути не менше 1900.", "Помилка");
                }

                if (string.IsNullOrWhiteSpace(CRUD_cassetteYear.Text) ||
                    int.Parse(CRUD_cassetteYear.Text) < 1900)
                {
                    MessageBox.Show("Рік виходу касети повинен бути не менше 1900.", "Помилка");
                }

                if (string.IsNullOrWhiteSpace(CRUD_cassetteSerialNumber.Text) ||
                    int.Parse(CRUD_cassetteSerialNumber.Text) < 0)
                {
                    MessageBox.Show("Серійний номер касети повинен бути не менше 0.", "Помилка");
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
                            (CRUD_genre.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                            int.Parse(CRUD_releaseYear.Text),
                            CRUD_director.Text,
                            CRUD_actors.Text,
                            CRUD_summary.Text,
                            ratingValue,
                            (CRUD_cassetteType.SelectedItem as ComboBoxItem)?.Content?.ToString(),
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
                            (CRUD_genre.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                            int.Parse(CRUD_releaseYear.Text),
                            CRUD_director.Text,
                            CRUD_actors.Text,
                            CRUD_summary.Text,
                            ratingValue,
                            (CRUD_discType.SelectedItem as ComboBoxItem)?.Content?.ToString());

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









        // пошук, сортування та фільтрація
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










        // робота з клієнтами, видачею та поверненням фільмів
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
                if (!int.TryParse(deleteClientID.Text, out userId))
                {
                    MessageBox.Show("Некоректний формат введеного ідентифікатора клієнта.", "Помилка");
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

        private void GiveFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmId = int.Parse(getFilmID.Text);
                DateTime takingDate = getTakeDate.SelectedDate ?? DateTime.Now;
                DateTime returnDate = getReturnDate.SelectedDate ?? DateTime.Now;
                int clientId = int.Parse(getClientID.Text);

                VideoFilm film = VideoFilmLibrary.GetFilmById(filmId);
                if (film == null)
                {
                    MessageBox.Show($"Фільм із ID {filmId} не знайдено.", "Помилка");
                    return;
                }

                if (!film.InVideoLibrary)
                {
                    MessageBox.Show($"Фільм із ID {filmId} вже виданий.", "Помилка");
                    return;
                }

                if (returnDate < takingDate)
                {
                    MessageBox.Show("Дата повернення повинна бути пізніше за дату взяття.", "Помилка");
                    return;
                }

                UserCard client = VideoFilmLibrary.GetUserCardById(clientId);
                if (client == null)
                {
                    MessageBox.Show($"Картка користувача із ID {clientId} не знайдена.", "Помилка");
                    return;
                }

                int recordId = client.FindMinUnusedRecordID();

                Record record = new Record(recordId, filmId, takingDate, returnDate, false);
                client.AddRecordToUserCard(record);

                VideoFilmLibrary.GetFilmById(filmId).InVideoLibrary = false;

                PrintMessage($"Фільм був виданий користувачу {client.UserName}. ID запису: {recordId}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }

        private void ReturnFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmId = int.Parse(returnFilmID.Text);
                int clientId = int.Parse(returnClientID.Text);
                DateTime date = factReturnDate.SelectedDate ?? DateTime.Now;

                VideoFilm film = VideoFilmLibrary.GetFilmById(filmId);
                if (film == null)
                {
                    MessageBox.Show($"Фільм із ID {filmId} не знайдено.", "Помилка");
                    return;
                }

                UserCard client = VideoFilmLibrary.GetUserCardById(clientId);
                if (client == null)
                {
                    MessageBox.Show($"Картка користувача із ID {clientId} не знайдена.", "Помилка");
                    return;
                }

                Record recordToReturn = client.Records.FirstOrDefault(record =>
                    record.VideoFilmId == filmId && !record.WasReturned);

                if (recordToReturn == null)
                {
                    MessageBox.Show($"Користувач із ID {clientId} не має не поверненого фільму із ID {filmId}.", "Помилка");
                    return;
                }

                if (date > DateTime.Now)
                {
                    MessageBox.Show("Фактична дата повернення не може бути в майбутньому.", "Помилка");
                    return;
                }

                if (date > recordToReturn.ReturningDate)
                {
                    MessageBox.Show("Фактична дата повернення пізніше запланованої. Введіть санкції стосовно клієнта.", "Попередження");
                }

                film.InVideoLibrary = true;
                recordToReturn.WasReturned = true;
                PrintMessage($"Фільм був успішно повернений. ID фільму: {filmId}, ID користувача: {clientId}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }

        private void GetUnreturnedFilmsByUserId(object sender, RoutedEventArgs e)
        {
            try
            {
                int clientId = int.Parse(returnClientID.Text);

                UserCard client = VideoFilmLibrary.GetUserCardById(clientId);
                if (client == null)
                {
                    MessageBox.Show($"Картка користувача із ID {clientId} не знайдена.", "Помилка");
                    return;
                }

                List<Record> unreturnedRecords = client
                    .Records.Where(record => !record.WasReturned)
                    .ToList();


                if (unreturnedRecords.Count == 0)
                {
                    MessageBox.Show($"У користувача із ID {clientId} немає неповернених фільмів.", "Повідомлення");
                }
                else
                {
                    PrintMessage($"Неповернені фільми користувача із ID {clientId}:");

                    foreach (Record record in unreturnedRecords)
                    {
                        VideoFilm film = VideoFilmLibrary.GetFilmById(record.VideoFilmId);
                        PrintMessage($"- ID фільму: {film.Id}, Назва: {film.Title}, Дата взяття: {record.TakingDate.ToShortDateString()}");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
            }
        }










        // додаткові функції
        private void FavoriteGenreByUserID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(featuresUserID.Text, out int userId))
                {
                    MessageBox.Show("Некоректний формат ID користувача.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserCard user = VideoFilmLibrary.GetUserCardById(userId);

                if (user == null)
                {
                    MessageBox.Show($"Користувача з ID {userId} не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                List<Record> userRecords = user.GetRecords();

                if (userRecords.Count == 0)
                {
                    PrintMessage($"Користувач із ID {userId} ще не дивився жодного фільму.");
                    return;
                }

                var genreCounts = userRecords
                    .GroupBy(record => VideoFilmLibrary.GetFilmById(record.VideoFilmId)?.Genre)
                    .Where(group => group.Key != null)
                    .Select(group => new { Genre = group.Key, Count = group.Count() })
                    .OrderByDescending(item => item.Count)
                    .ToList();

                if (genreCounts.Count == 0)
                {
                    PrintMessage($"Користувач із ID {userId} ще не дивився фільми з визначеними жанрами.");
                    return;
                }

                int maxCount = genreCounts.First().Count;

                var favoriteGenres = genreCounts
                    .Where(item => item.Count == maxCount)
                    .Select(item => item.Genre.ToString())
                    .ToList();

                PrintMessage($"Улюблені жанри користувача із ID {userId}: {string.Join(", ", favoriteGenres)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void RandomNotViewedFilmByUserID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(featuresUserID.Text, out int userId))
                {
                    MessageBox.Show("Некоректний формат ID користувача.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserCard user = VideoFilmLibrary.GetUserCardById(userId);

                if (user == null)
                {
                    MessageBox.Show($"Користувача з ID {userId} не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                List<VideoFilm> notViewedFilms = VideoFilmLibrary.GetVideoFilms()
                    .Where(film => !user.GetRecords().Any(record => record.VideoFilmId == film.Id))
                    .ToList();

                if (notViewedFilms.Count == 0)
                {
                    PrintMessage($"Користувач із ID {userId} переглянув всі фільми.");
                    return;
                }

                Random random = new Random();
                VideoFilm randomFilm = notViewedFilms[random.Next(notViewedFilms.Count)];

                if (randomFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    PrintMessage($"Випадковий фільм для користувача із ID {userId}: \n{videoFilmOnCassette.ToStringForWrite()}");
                }
                else if (randomFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    PrintMessage($"Випадковий фільм для користувача із ID {userId}: \n{videoFilmOnDisc.ToStringForWrite()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Top3MostWatchedFilmsInLibrary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<VideoFilm> allFilms = VideoFilmLibrary.GetVideoFilms();

                if (allFilms.Count == 0)
                {
                    PrintMessage("Відеотека порожня.");
                    return;
                }

                Dictionary<VideoFilm, int> filmViewsCount = new Dictionary<VideoFilm, int>();

                foreach (UserCard userCard in VideoFilmLibrary.GetUserCards())
                {
                    foreach (Record record in userCard.GetRecords())
                    {
                        VideoFilm film = allFilms.FirstOrDefault(f => f.Id == record.VideoFilmId);

                        if (film != null)
                        {
                            if (!filmViewsCount.ContainsKey(film))
                            {
                                filmViewsCount[film] = 1;
                            }
                            else
                            {
                                filmViewsCount[film]++;
                            }
                        }
                    }
                }

                if (filmViewsCount.Count == 0)
                {
                    PrintMessage("Немає переглядів фільмів відеотеки.");
                    return;
                }

                List<VideoFilm> top3Films = filmViewsCount.OrderByDescending(kv => kv.Value).Take(3).Select(kv => kv.Key).ToList();

                PrintMessage("Трійка найбільш перегляданих фільмів:");

                foreach (VideoFilm film in top3Films)
                {
                    PrintMessage($"ID: {film.Id}, Назва: {film.Title}, Кількість переглядів: {filmViewsCount[film]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AverageFilmReturningTimeByUserID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId = int.Parse(featuresUserID.Text);

                UserCard userCard = VideoFilmLibrary.GetUserCardById(userId);

                if (userCard == null)
                {
                    MessageBox.Show($"Картка користувача із ID {userId} не знайдена.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                List<Record> userRecords = userCard.GetRecords();

                if (userRecords.Count == 0)
                {
                    MessageBox.Show($"Користувач із ID {userId} ще не переглядав фільми.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                List<TimeSpan> returningTimes = new List<TimeSpan>();

                foreach (Record record in userRecords)
                {
                    if (record.WasReturned)
                    {
                        TimeSpan returningTime = record.ReturningDate - record.TakingDate;
                        returningTimes.Add(returningTime);
                    }
                }

                if (returningTimes.Count == 0)
                {
                    MessageBox.Show($"Користувач із ID {userId} ще не повертав фільми.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                double averageReturningTime = returningTimes.Average(time => time.TotalDays);

                PrintMessage($"Середній час повернення фільмів для користувача із ID {userId}: {averageReturningTime:F2} дні(в).");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AllWatchedFilmsByUserID(object sender, RoutedEventArgs e)
        {
            try
            {
                int userId = int.Parse(featuresUserID.Text);

                UserCard userCard = VideoFilmLibrary.GetUserCardById(userId);

                if (userCard == null)
                {
                    MessageBox.Show($"Картка користувача із ID {userId} не знайдена.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                List<Record> userRecords = userCard.GetRecords();

                if (userRecords.Count == 0)
                {
                    MessageBox.Show($"Користувач із ID {userId} ще не переглядав фільми.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                List<VideoFilm> watchedFilms = new List<VideoFilm>();

                foreach (Record record in userRecords)
                {
                    VideoFilm film = VideoFilmLibrary.GetFilmById(record.VideoFilmId);
                    if (film != null)
                    {
                        watchedFilms.Add(film);
                    }
                }

                if (watchedFilms.Count == 0)
                {
                    MessageBox.Show($"Користувач із ID {userId} ще не переглядав фільми.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                PrintMessage("Фільми, які переглядав користувач:");

                foreach (VideoFilm film in watchedFilms)
                {
                    if (film is VideoFilmOnCassette videoFilmOnCassette)
                    {
                        PrintMessage(videoFilmOnCassette.ToStringForWrite());
                    }
                    else if (film is VideoFilmOnDisc videoFilmOnDisc)
                    {
                        PrintMessage(videoFilmOnDisc.ToStringForWrite());
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void OfferListOfSnacksByFilmID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int filmId = int.Parse(featuresFilmID.Text);

                VideoFilm film = VideoFilmLibrary.GetFilmById(filmId);

                if (film == null)
                {
                    MessageBox.Show($"Фільм із ID {filmId} не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                List<string> snacksList = GetSnacksForGenre(film.Genre);

                if (snacksList.Count == 0)
                {
                    MessageBox.Show($"Для жанру {film.Genre} не знайдено варіантів снеків.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Random random = new Random();

                List<string> selectedSnacks = snacksList.OrderBy(_ => random.Next()).Take(2).ToList();

                PrintMessage($"Для фільму '{film.Title}' підходять наступні снеки:");

                foreach (string snack in selectedSnacks)
                {
                    PrintMessage(snack);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некоректний формат введених даних.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private List<string> GetSnacksForGenre(Genres genre)
        {
            List<string> snacksList = new List<string>();

            switch (genre)
            {
                case Genres.Action:
                    snacksList.AddRange(new List<string>{
                        "Попкорн з карамеллю або солоний.",
                        "Спайсі чіпси.",
                        "Курятина або свинина в гострій паніровці.",
                        "Гострі крильця.",
                        "Газовані напої."});
                    break;
                case Genres.Drama:
                    snacksList.AddRange(new List<string>{
                        "Сир і виноград.",
                        "Фруктовий салат.",
                        "Горішки.",
                        "Сирні палички.",
                        "Темний шоколад."});
                    break;
                case Genres.Comedy:
                    snacksList.AddRange(new List<string>{
                        "Попкорн з смаковими порошками (сир, бекон, сіль).",
                        "Газовані напої.",
                        "Кольорові желейні цукерки.",
                        "Мафіни або кекси.",
                        "Зефірки."});
                    break;
                case Genres.Thriller:
                    snacksList.AddRange(new List<string>{
                        "Сухарики.",
                        "Крекери з кетчупом.",
                        "Оливки.",
                        "Гострі сирні шарики.",
                        "Темний шоколад."});
                    break;
                case Genres.Fantasy:
                    snacksList.AddRange(new List<string>{
                        "Маршмеллоу, драже, желе.",
                        "Кекси.",
                        "Фруктові коктейлі.",
                        "Морозиво з феєричними топінгами.",
                        "Кольорові напої."});
                    break;
                case Genres.Romance:
                    snacksList.AddRange(new List<string>{
                        "Фруктові шашлики.",
                        "Шоколадні фонтани з фруктами.",
                        "Малиновий чи трюфельний мус.",
                        "Пудроване печиво.",
                        "Рожеві коктейлі."});
                    break;
                case Genres.Animation:
                    snacksList.AddRange(new List<string>{
                        "Кольорові фруктові палички.",
                        "Мармуровані мафіни або кейкпопси.",
                        "Масляний попкорн.",
                        "Кольорові желейні цукерки.",
                        "Морозиво з веселими топінгами."});
                    break;
                case Genres.Documentary:
                    snacksList.AddRange(new List<string>{
                        "Сухофрукти та горішки.",
                        "Сир.",
                        "Крекери з тунцем або лососем.",
                        "Солоний попкорн.",
                        "Нежирні йогурти."});
                    break;
                default:
                    break;
            }

            return snacksList;
        }








    }
}
