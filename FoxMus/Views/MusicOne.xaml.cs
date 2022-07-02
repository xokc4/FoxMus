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
    /// Логика взаимодействия для MusicOne.xaml
    /// </summary>
    /// 
    
    public partial class MusicOne : Window
    {
        int countPley = 0;
        public static List<MusicClass> musics = new List<MusicClass>();
        public MusicOne(string PathMus, TimeSpan position, List<MusicClass> music)
        {
            InitializeComponent();
            musics = music;
            MediaMus.Source = new Uri(PathMus);
            MediaMus.Position = position;
            MediaMus.Play();
        }
        private void Forward_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //++
        }

        private void keyDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //--
        }

        private void Pause_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (countPley)
            {
                case 0:
                    Pause.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\xokc4\FoxMus\FoxMus\ImageForm\iPleybutton.jpg"));
                    countPley++;
                    MediaMus.Pause();
                    break;
                case 1:
                    Pause.Source = new BitmapImage(new Uri(@"C:\Users\poc18\source\repos\xokc4\FoxMus\FoxMus\ImageForm\ipause.jpg"));
                    countPley--;
                    MediaMus.Play();
                    break;
                default:
                    MessageBox.Show("что то не так :(");
                    break;
            }
        }
        private void Volume_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MediaMus.Volume += 1;
        }
    }
}
