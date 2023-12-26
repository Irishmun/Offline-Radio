using System;
using System.IO;

namespace OfflineRadio.Stations
{
    public struct Station
    {
        /// <summary>Offset from start of track to not always start at beginning</summary>
        public double StartOffset { get; set; }
        /// <summary>Time when the Station started playing</summary>
        public DateTime StartTime { get; set; }
        /// <summary>Name of the station that is playing</summary>
        public string Name { get; set; } //just the filename
        /// <summary>File that is played by that station</summary>
        public string AudioFile { get; set; }

        public Station(double StartOffset, DateTime StartTime, string Name, string AudioFile)
        {
            this.StartOffset = StartOffset;
            this.StartTime = StartTime;
            this.Name = Name;
            this.AudioFile = AudioFile;
        }

        public Station(string fileName, DateTime startTime)
        {
            AudioFile = fileName;
            StartOffset = -1;
            StartTime = startTime;
            Name = Path.GetFileNameWithoutExtension(fileName);
        }

        public override string ToString()
        {
            return $"{Name}, startTime: {StartTime}, Offset: {StartOffset}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Station == false)
            { return false; }
            Station compare = (Station)obj;

            if (compare.Name.Equals(this.Name) && compare.AudioFile.Equals(this.AudioFile) && compare.StartOffset.Equals(this.StartOffset))
            {
                return true;
            }
            return false;
        }
    }
}
