
using Elasticsearch.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;

namespace FoxMus.Views
{
    /// <summary>
    /// Логика взаимодействия для MyMusic.xaml
    /// </summary>
    public partial class MyMusic : Window
    {
        public static List<MusicClass> MymuGlopal = new List<MusicClass>();


        int countPley = 0;
        public static List<MusicClass> Mymusics = new List<MusicClass>();
        public string path = @"C:\Users\poc18\source\repos\FoxMus\FoxMus\MusicFull";
        public static MusicClass musisc = new MusicClass();
        public MyMusic()
        {
            InitializeComponent();
            Loaded += MyMusic_Loaded;
        }

        private void MyMusic_Loaded(object sender, RoutedEventArgs e)
        {
            MyMusicList.ItemsSource = Mymusics;
        }
        private void MyMusicList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MusicClass music = MyMusicList.SelectedItem as MusicClass;
            MyMusicMedia.Source = new Uri(music.PathMusic);
            musisc = music;
            MymuGlopal = Mymusics;
            MyMusicMedia.Play();

        }

        private void myPleyMus_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (countPley)
            {
                case 0:
                    myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\iPleybutton.jpg"));
                    countPley++;
                    MyMusicMedia.Pause();
                    break;
                case 1:
                    myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                    countPley--;
                    MyMusicMedia.Play();
                    break;
                default:
                    MessageBox.Show("что то не так :(");
                    break;
            }
        }

        private void myForward_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int IdMus = musisc.IDmus + 1;
           
            if (Mymusics.Count> IdMus)
            {
                List<MusicClass> musicClass = MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MyMusicMedia.Source = new Uri(musicClass[0].PathMusic);
                musisc = musicClass[0];
                MyMusicMedia.Play();
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

        private void mykeyDownPer_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int IdMus = musisc.IDmus - 1;

            if (0 < IdMus)
            {
                List<MusicClass> musicClass = MymuGlopal.Where(x => x.IDmus == IdMus).ToList();
                MyMusicMedia.Source = new Uri(musicClass[0].PathMusic);
                musisc = musicClass[0];
                MyMusicMedia.Play();
                switch (countPley)
                {
                    case 1:
                        myPleyMus.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                        countPley--;
                        MyMusicMedia.Play();
                        break;
                    default:
                        break;
                }

            }
            
        }

        private void myMusicsOne_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MusicOne one = new MusicOne();
            one.Show();
        }
    }
}
