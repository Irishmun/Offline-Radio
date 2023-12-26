using OfflineRadio.Stations;
using System;
#if DEBUG
using System.Diagnostics;
using System.IO;
#endif
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace OfflineRadio
{
    public partial class RadioForm : Form
    {
        private Station _currentStation;
        private RadioStations _stations;
        private Settings _settings;

        public RadioForm()
        {
            _settings = Settings.GetSettingsFromJson();
            InitializeComponent();
            _stations = new RadioStations();
            WMP_RadioPlayer.settings.volume = TrB_Volume.Value;
            WMP_RadioPlayer.settings.setMode("loop", true);

            if (_settings.SavedStations != null && _settings.SavedStations.Count > 0)
            {
                _stations.Stations = _settings.SavedStations;
                PopulateStations();
            }
            if (_settings.CurrentStation != null && _settings.CurrentStation.Equals(string.Empty) == false)
            {
                CbB_Stations.SelectedIndex = CbB_Stations.Items.IndexOf(_settings.CurrentStation);
            }
            if (_settings.LastPlayState == true)
            {
                PlayCurrentStation();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (_settings.StationsFolder == null || _settings.StationsFolder.Equals(string.Empty))
                {
                    folder.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                }
                else
                {
                    folder.SelectedPath = _settings.StationsFolder;
                }
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    _settings.StationsFolder = folder.SelectedPath;
                    if (_stations.AppendOrUpdateStations(folder.SelectedPath) == true)
                    {
                        StopPlaying();
                        PopulateStations();
                        _settings.SavedStations = _stations.Stations;
                        CbB_Stations.SelectedIndex = 0;
                    }
                }
            }
            _settings.SaveSettings();
        }

        private void BT_StartPlayback_Click(object sender, EventArgs e)
        {
            PlayCurrentStation();
            _settings.LastPlayState = true;
        }

        private void BT_StopPlayback_Click(object sender, EventArgs e)
        {
            StopPlaying();
        }

        #region debug
        private void showStationTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WMP_RadioPlayer.currentMedia == null)
            { return; }
            MessageBox.Show("Current Station: " + WMP_RadioPlayer.currentMedia.name +
                "\nCurrent Time: " + WMP_RadioPlayer.Ctlcontrols.currentPositionString);
        }

        private void showStationValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_stations.Stations == null || _stations.Stations.Count <= 0)
            { return; }
            StringBuilder str = new StringBuilder();
            foreach (Station station in _stations.Stations)
            {
                str.AppendLine($"{station.Name}| {station.StartTime}| {station.StartOffset}");
            }
            MessageBox.Show(str.ToString());
        }
        #endregion

        private void TrB_Volume_Scroll(object sender, EventArgs e)
        {
            WMP_RadioPlayer.settings.volume = TrB_Volume.Value;
            LB_Volume.Text = TrB_Volume.Value.ToString();
        }

        private void PlayCurrentStation()
        {
            _currentStation = _stations.GetStation((string)CbB_Stations.SelectedItem);
            WMP_RadioPlayer.URL = _currentStation.AudioFile;
        }

        private void StopPlaying()
        {
            WMP_RadioPlayer.Ctlcontrols.stop();
            _settings.LastPlayState = false;
        }

        private void WMP_RadioPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState.Equals((int)WMPPlayState.wmppsPlaying))
            {
                double duration = WMP_RadioPlayer.currentMedia.duration;
                if (_currentStation.StartOffset < 0)
                {
                    Random rand = new Random();
                    int index = _stations.Stations.IndexOf(_currentStation);
                    _currentStation.StartOffset = rand.NextDouble() * duration;
                    _stations.UpdateStationValue(index, _currentStation);
                }
                DateTime currentTime = DateTime.Now;
                double offset = ((currentTime - _currentStation.StartTime).TotalSeconds + _currentStation.StartOffset) % duration;
                WMP_RadioPlayer.Ctlcontrols.currentPosition = offset;
#if DEBUG
                Debug.WriteLine($"(offset: {offset}){WMP_RadioPlayer.Ctlcontrols.currentPosition}");
#endif
            }
        }

        private void CbB_Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WMP_RadioPlayer.playState.Equals(WMPPlayState.wmppsPlaying))
            {
                PlayCurrentStation();
            }
            _settings.CurrentStation = (string)CbB_Stations.SelectedItem;
        }

        private void PopulateStations()
        {
            CbB_Stations.Items.Clear();
            for (int i = 0; i < _stations.Stations.Count; i++)
            {
                CbB_Stations.Items.Add(_stations.Stations[i].Name);
            }
        }

        private void RadioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.SaveSettings();
        }

    }
}

