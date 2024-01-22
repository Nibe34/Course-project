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

            

            FileManager.ReadFilms();



            //outputTextBlock.Text = outputTextBlock.Text + VideoFilmLibrary.GetVideoFilms().
            //outputTextBlock.Text = "";
        }


        private void WriteAllFilms_Click(object sender, RoutedEventArgs e)
        {
            foreach (var videoFilm in VideoFilmLibrary.GetVideoFilms())
            {
                if (videoFilm is VideoFilmOnCassette videoFilmOnCassette)
                {
                    outputTextBlock.Text += videoFilmOnCassette.ToStringForWrite();
                }
                else if (videoFilm is VideoFilmOnDisc videoFilmOnDisc)
                {
                    outputTextBlock.Text += videoFilmOnDisc.ToStringForWrite();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileManager.WriteFilms();
        }
    }
}
