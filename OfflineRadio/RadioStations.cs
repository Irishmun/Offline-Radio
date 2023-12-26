using OfflineRadio.Stations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
#if DEBUG
using System.Diagnostics;
#endif

namespace OfflineRadio
{
    internal class RadioStations
    {
        private string[] AcceptedFileTypes = new string[] { ".mp3", ".flac", ".wav", ".aac" };
        private List<Station> _stations;
        /// <summary>Gets all the stations in the given folder. Will overwrite existing stations</summary>
        /// <param name="folder">folder to search in</param>
        /// <returns>the amount of stations added</returns>
        public int GetAllStations(string folder)
        {
            List<Station> foundStations = GetStationsList(folder);
            if (foundStations != null && foundStations.Count > 0)
            {
                _stations = foundStations;
#if DEBUG
                Debug.WriteLine("Added " + _stations.Count + " Stations");
#endif
            }
            return _stations.Count;
        }

        /// <summary>Gets all stations in folder, and appends any new ones if they aren't in the folder yet. Existing ones will be updated</summary>
        /// <param name="folder">folder to search through</param>
        /// <returns>whether any new stations were appended or updated</returns>
        public bool AppendOrUpdateStations(string folder)
        {
            if (_stations == null || _stations.Count == 0)
            {//create a new list for it
                GetAllStations(folder);
                return true;
            }
            List<Station> foundStations = GetStationsList(folder);
            int index = -1;
            bool altered = false;
            for (int i = 0; i < foundStations.Count; i++)
            {
                //check for any with a matching name, folder might have changed
                Station existing = _stations.FirstOrDefault(s => s.Name.Equals(foundStations[i].Name));
                if (string.IsNullOrWhiteSpace(existing.Name))
                {
                    //add new station if not present yet
                    _stations.Add(foundStations[i]);
                    altered = true;
                }
                else
                {
                    //update existing stations
                    if (foundStations[i].AudioFile.Equals(existing.AudioFile) == true)//no difference, no change
                    { continue; }
                    index = _stations.IndexOf(existing);
                    existing.AudioFile = foundStations[i].AudioFile;//update file in folder, the rest stays the same.
                    UpdateStationValue(index, existing);
                    altered = true;
                }
            }
            return altered;
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

        private List<Station> GetStationsList(string path)
        {
            string[] possibleStations = Directory.GetFiles(path);
            if (possibleStations == null || possibleStations.Length <= 0)
            { return null; }

            List<Station> foundStations = new List<Station>();
            DateTime start = DateTime.Now;
            foreach (string item in possibleStations)
            {
                string extension = Path.GetExtension(item);
                for (int i = 0; i < AcceptedFileTypes.Length; i++)
                {
                    if (extension.ToLower().Equals(AcceptedFileTypes[i].ToLower()))
                    {
                        Station station = new Station(item, start);
                        foundStations.Add(station);
#if DEBUG
                        Debug.WriteLine("Added Station: " + station.Name);
#endif
                        break;
                    }
                }
            }

            return foundStations;
        }
        public List<Station> Stations { get => _stations; set => _stations = value; }
    }
}
