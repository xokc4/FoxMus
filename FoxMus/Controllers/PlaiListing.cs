using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxMus.Controllers
{
    public class PlaiListing
    {
        public static List<MusicClass> plaiListMy()
        {
            List<MusicClass> list = new List<MusicClass>();
            string pathFull = @"C:\Users\poc18\source\repos\xokc4\FoxMus\FoxMus\MusicFull";
            string[] allfiles = Directory.GetFiles(pathFull);
            int i = 0;
            foreach (string filename in allfiles)
            {
                FileInfo fileInfo = new FileInfo(filename);
                list.Add(new MusicClass(i++, fileInfo.Name, fileInfo.FullName));
                using (FileStream fs = File.OpenRead(filename))
                {
                    if (fs.Length >= 128)
                    {
                        MusicID3Tag tag = new MusicID3Tag();
                        fs.Seek(-128, SeekOrigin.End);
                        fs.Read(tag.TAGID, 0, tag.TAGID.Length);
                        fs.Read(tag.Title, 0, tag.Title.Length);
                        fs.Read(tag.Artist, 0, tag.Artist.Length);
                        fs.Read(tag.Album, 0, tag.Album.Length);
                        fs.Read(tag.Year, 0, tag.Year.Length);
                        fs.Read(tag.Comment, 0, tag.Comment.Length);
                        fs.Read(tag.Genre, 0, tag.Genre.Length);
                        string theTAGID = UTF8Encoding.Default.GetString(tag.TAGID);

                        if (theTAGID.Equals("TAG"))
                        {
                            string Title = UnicodeEncoding.Default.GetString(tag.Title);
                            string Artist = UTF8Encoding.Default.GetString(tag.Artist);
                            string Album = ASCIIEncoding.Default.GetString(tag.Album);
                            string Year = UTF8Encoding.Default.GetString(tag.Year);
                            string Genre = UTF8Encoding.Default.GetString(tag.Genre);
                            string str = Encoding.Default.GetString(tag.Album);
                        }
                    }
                }
            }
            return list;
        }
        public static List<MusicClass> plaiListDay(List<MusicClass> MyMuss)
        {
            List<MusicClass> list = new List<MusicClass>();
            for(int i=0;10>i;i++)
            {
                Random randomMus = new Random();
                int idMus = randomMus.Next(0, MyMuss.Count);
                List<MusicClass> item = MyMuss.Where(x => x.IDmus==idMus).ToList();
                list.Add(item[0]);
            }
            return list;
        }
    }
}
