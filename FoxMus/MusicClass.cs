using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxMus
{
    public class MusicClass
    {
        public MusicClass()
        {
        }

        public MusicClass(string nameMus, string pathMusic)
        {
            NameMus = nameMus;
            PathMusic = pathMusic;
        }

        public MusicClass(int iDmus, string nameMus, string pathMusic)
        {
            IDmus = iDmus;
            NameMus = nameMus;
            PathMusic = pathMusic;
        }

        public int IDmus { get; set; }
        public string NameMus { get; set; }
        public string NameExecutor { get; set; }
        public string ImageMus { get; set; }
        public int TimeMus { get; set; }
        public string Album { get; set; }
        public string PathMusic { get; set; }
    }
}
