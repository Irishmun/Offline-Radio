using System;
using System.IO;
using System.Text;

namespace InDepthRadio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commercialsBetweenEpisodes = 2;
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Random rng = new Random();
            string episodesPath = "H:\\MM\\GTA\\OpenIV-Extracts\\Radio\\GTAIV\\LIBERTY\\SONG", commercialsPath = "H:\\MM\\GTA\\OpenIV-Extracts\\Radio\\GTAIV\\ADVERTS";
            StringBuilder playlistStr = new StringBuilder();
            string[] episodeFiles = Directory.GetFiles(episodesPath);//have these use video file filters
            string[] commercialFiles = Directory.GetFiles(commercialsPath);

            //shuffle episodes and commercials
            Shuffle(rng, episodeFiles);
            Shuffle(rng, commercialFiles);

            int currentEpisode = 0, currentCommercial = 0;


            for (int i = 0; i < episodeFiles.Length; i++)
            {
                //add commercials to playlist string
                for (int c = 0; c < commercialsBetweenEpisodes; c++)
                {
                    playlistStr.AppendLine(GetCommercialString());
                }
                playlistStr.AppendLine(episodeFiles[i]);
            }

            File.WriteAllText(workingDirectory + "\\playlist.m3u", playlistStr.ToString());

            Console.WriteLine($"Wrote to {workingDirectory}\\playlist.m3u");


            string GetCommercialString()
            {
                currentCommercial += 1;
                if (currentCommercial >= commercialFiles.Length)
                {//rescramble commercials and reset counter if out of commercials
                    currentCommercial = 0;
                    Shuffle(rng, commercialFiles);
                }
                return commercialFiles[currentCommercial];
            }


            void Shuffle(Random rng, string[] array)
            {//Knuth Shuffle
                int n = array.Length;
                while (n > 1)
                {
                    int k = rng.Next(n--);
                    string temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }
        }
    }
}
