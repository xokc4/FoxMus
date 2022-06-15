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
using System.Windows.Shapes;

namespace FoxMus.Views
{
    /// <summary>
    /// Логика взаимодействия для ListingMusic.xaml
    /// </summary>
    public partial class ListingMusic : Window
    {
        int countPley = 0;
        public ListingMusic()
        {
            InitializeComponent();
            Loaded += ListingMusic_Loaded;
        }

        private void ListingMusic_Loaded(object sender, RoutedEventArgs e)
        {
            ListMus.ItemsSource = Views.MyMusic.MymuGlopal;
        }

        private void myPleyMus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (countPley)
            {
                case 0:
                    myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\iPleybutton.jpg"));
                    countPley++;
                    MediaMusic.Pause();
                    break;
                case 1:
                    myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                    countPley--;
                    MediaMusic.Play();
                    break;
                default:
                    MessageBox.Show("что то не так :(");
                    break;
            }
        }

        private void myForward_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int IdMus = Views.MyMusic.musisc.IDmus + 1;

            if (Views.MyMusic.Mymusics.Count > IdMus)
            {
                List<MusicClass> musicClass = Views.MyMusic.MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MediaMusic.Source = new Uri(musicClass[0].PathMusic);
                Views.MyMusic.musisc = musicClass[0];
                MediaMusic.Play();
                switch (countPley)
                {
                    case 1:
                        myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                        countPley--;

                        break;
                    default:
                        break;
                }
            }
        }

        private void mykeyDownPer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int IdMus = Views.MyMusic.musisc.IDmus - 1;
            if (0 < IdMus)
            {
                List<MusicClass> musicClass = Views.MyMusic.MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MediaMusic.Source = new Uri(musicClass[0].PathMusic);
                Views.MyMusic.musisc = musicClass[0];
                MediaMusic.Play();
                switch (countPley)
                {
                    case 1:
                        myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                        countPley--;
                        break;
                    default:
                        break;
                }
            }
        }

        private void myMusicsOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MusicOne one = new MusicOne();
            one.Show();
        }
        private void ListMus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MusicClass music = ListMus.SelectedItem as MusicClass;
            MediaMusic.Source = new Uri(music.PathMusic);
            Views.MyMusic.musisc = music;
            MediaMusic.Play();
        }
    }
}
