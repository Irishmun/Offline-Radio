using OfflineRadio.Stations;
using System;
using System.Collections.Generic;
using System.IO;
#if DEBUG
using System.Diagnostics;
#endif

namespace OfflineRadio
{
    internal class RadioStations
    {
        private string[] AcceptedFileTypes = new string[] { ".mp3", ".flac", ".wav", ".aac" };
        private List<Station> _stations;
        public int GetAllStations(string folder)
        {
            string[] possibleStations = Directory.GetFiles(folder);
            if (possibleStations == null || possibleStations.Length <= 0)
            { return -1; }
            _stations = new List<Station>();
            DateTime start = DateTime.Now;
            foreach (string item in possibleStations)
            {
                string extension = Path.GetExtension(item);
                for (int i = 0; i < AcceptedFileTypes.Length; i++)
                {
                    if (extension.ToLower().Equals(AcceptedFileTypes[i].ToLower()))
                    {
                        Station station = new Station(item, start);
                        _stations.Add(station);
#if DEBUG
                        Debug.WriteLine("Added Station: " + station.Name);
#endif
                        break;
                    }
                }
            }
#if DEBUG
            if (_stations.Count > 0)
            {
                Debug.WriteLine("Added " + _stations.Count + " Stations");
            }
#endif
            return _stations.Count;
        }

        public void UpdateStationValue(int index, Station newValues)
        {
#if DEBUG
            Debug.WriteLine($"Changing...\nOld: {_stations[index]}\nNew: {newValues}");
#endif
            _stations[index] = newValues;
        }

        public Station GetStation(string name)
        {
            foreach (Station item in _stations)
            {
                if (item.Name.Equals(name))
                {
                    return item;
                }
            }
            return new Station();
        }
        public List<Station> Stations { get => _stations; set => _stations = value; }
    }
}
