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
using System.IO;
using FoxMus.Views;
using FoxMus.Controllers;

namespace FoxMus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<MusicClass> PlaylistDay = new List<MusicClass>();
        public static MusicClass musiscMy = new MusicClass();

        int countPley = 0;
        public static List<MusicClass> musics = new List<MusicClass>();
        public MainWindow()
        {
            
            InitializeComponent();
            MediaMusic.Source = new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\MusicFull\ATL_-_Astronavt_47828864.mp3");
            Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MyMusic.Mymusics = PlaiListing.plaiListMy();
            PlaylistDay = PlaiListing.plaiListDay(MyMusic.Mymusics);
            Views.MyMusic.MymuGlopal = PlaylistDay;
        }

        private void IPleyList_Click(object sender, RoutedEventArgs e)
        {
            Views.MyMusic my = new Views.MyMusic();
            my.Show();
            this.Close();
        }
        private void MusicsOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Views.MusicOne Mus = new Views.MusicOne(musiscMy.PathMusic, MediaMusic.Position, PlaylistDay);
            Mus.Show();
        }
        private void PleyMus_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            switch (countPley)
            {
                case 0:
                    PleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\xokc4\FoxMus\FoxMus\ImageForm\iPleybutton.jpg"));
                    countPley++;
                    MediaMusic.Pause();
                    break;
                case 1:
                    PleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\xokc4\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                    countPley--;
                    MediaMusic.Play();
                    break;
                default:
                    MessageBox.Show("что то не так :(");
                    break;
            }
        }

        private void Forward_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int IdMus = musiscMy.IDmus + 1;
            if (Views.MyMusic.MymuGlopal.Count > IdMus)
            {
                List<MusicClass> musicClass = Views.MyMusic.MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MediaMusic.Source = new Uri(musicClass[0].PathMusic);
                musiscMy = musicClass[0];
                MediaMusic.Play();
                switch (countPley)
                {
                    case 1:
                        PleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                        countPley--;
                        MediaMusic.Play();
                        break;
                    default:
                        break;
                }
            }
        }
        private void keyDownPer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int IdMus = musiscMy.IDmus - 1;
            if (0 < IdMus)
            {
                List<MusicClass> musicClass = Views.MyMusic.MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MediaMusic.Source = new Uri(musicClass[0].PathMusic);
                musiscMy = musicClass[0];
                MediaMusic.Play();
                switch (countPley)
                {
                    case 1:
                        PleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                        countPley--;
                        break;
                    default:
                        break;
                }
            }
        }
        private void PlayDay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListingMusic listing = new ListingMusic();
            listing.Show();
        }
    }
}
