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
        private RadioStations _radioStations;
        private Settings _settings;

        public RadioForm()
        {
            _settings = Settings.GetSettingsFromJson();
            InitializeComponent();
            _radioStations = new RadioStations();

#if !DEBUG
            debugToolStripMenuItem.Visible = false;
#endif

            WMP_RadioPlayer.settings.setMode("loop", true);

            if (_settings.SavedStations != null && _settings.SavedStations.Count > 0)
            {
                _radioStations.Stations = _settings.SavedStations;
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
            if (_settings.LastVolume > -1)
            {
                TrB_Volume.Value = _settings.LastVolume;
                WMP_RadioPlayer.settings.volume = _settings.LastVolume;
                LB_Volume.Text = _settings.LastVolume.ToString();
            }
            else
            {
                WMP_RadioPlayer.settings.volume = TrB_Volume.Value;
                _settings.LastVolume = TrB_Volume.Value;
            }
        }
        private void clearStationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopPlaying();
            CbB_Stations.Items.Clear();
            CbB_Stations.Text = string.Empty;
            _radioStations.Stations.Clear();
            _settings.CurrentStation = string.Empty;
            _settings.SavedStations.Clear();
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (_settings.StationsFolder == null || _settings.StationsFolder.Equals(string.Empty))
                {
                    folder.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\";
                }
                else
                {
                    folder.SelectedPath = _settings.StationsFolder;
                }
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    _settings.StationsFolder = folder.SelectedPath;
                    if (_radioStations.AppendOrUpdateStations(folder.SelectedPath) == true)
                    {
                        StopPlaying();
                        PopulateStations();
                        _settings.SavedStations = _radioStations.Stations;
                        CbB_Stations.SelectedIndex = 0;
                    }
                }
            }
            _settings.SaveSettings();
        }

        private void BT_StartPlayback_Click(object sender, EventArgs e)
        {
            if (WMP_RadioPlayer.playState.Equals(WMPPlayState.wmppsPlaying))
            { return; }
            PlayCurrentStation();
            _settings.LastPlayState = true;
        }

        private void BT_StopPlayback_Click(object sender, EventArgs e)
        {
            StopPlaying();
        }



        private void TrB_Volume_Scroll(object sender, EventArgs e)
        {
            WMP_RadioPlayer.settings.volume = TrB_Volume.Value;
            LB_Volume.Text = TrB_Volume.Value.ToString();
            _settings.LastVolume = TrB_Volume.Value;
        }

        private void PlayCurrentStation()
        {
            _currentStation = _radioStations.GetStation((string)CbB_Stations.SelectedItem);
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
                if (duration <= 0)
                { return; }
                if (_currentStation.StartOffset < 0)
                {
                    Random rand = new Random();
                    int index = _radioStations.Stations.IndexOf(_currentStation);
                    _currentStation.StartOffset = rand.NextDouble() * duration;
                    _radioStations.UpdateStationValue(index, _currentStation);
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
            for (int i = 0; i < _radioStations.Stations.Count; i++)
            {
                CbB_Stations.Items.Add(_radioStations.Stations[i].Name);
            }
        }

        private void RadioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.SaveSettings();
        }


        #region debug
        private void showStationTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WMP_RadioPlayer.currentMedia == null)
            { return; }
            MessageBox.Show($"Current Station: {WMP_RadioPlayer.currentMedia.name}\nCurrent Time: {WMP_RadioPlayer.Ctlcontrols.currentPositionString}/{WMP_RadioPlayer.currentMedia.durationString}");
        }

        private void showStationValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_radioStations.Stations == null || _radioStations.Stations.Count <= 0)
            { return; }
            StringBuilder str = new StringBuilder();
            foreach (Station station in _radioStations.Stations)
            {
                str.AppendLine($"{station.Name}| {station.StartTime}| {station.StartOffset}");
            }
            MessageBox.Show(str.ToString());
        }
        #endregion
    }
}

