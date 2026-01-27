using Eto.Drawing;
using Eto.Forms;
using OfflineRadio.Audio;
using OfflineRadio.Stations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OfflineRadio
{
    public partial class RadioForm : Form
    {
        private Station _currentStation;
        private RadioStations _radioStations;
        private Settings _settings;
        private AudioPlayer _player;

        public RadioForm()
        {
            _settings = Settings.GetSettingsFromJson();
            _player = new AudioPlayer();
            InitializeComponent();


            _radioStations = new RadioStations();

            if (_settings.SavedStations != null && _settings.SavedStations.Count > 0)
            {
                _radioStations.Stations = _settings.SavedStations;
                PopulateStations();
            }
            if (_settings.CurrentStation != null && _settings.CurrentStation.Equals(string.Empty) == false)
            {
                CbB_Stations.SelectedKey = _settings.CurrentStation;
            }
            if (_settings.LastPlayState == true)
            {
                PlayCurrentStation();
            }
            if (_settings.LastVolume > -1)
            {
                Sl_Volume.Value = _settings.LastVolume;
                _player.SetVolume(_settings.LastVolume);
                LB_Volume.Text = _settings.LastVolume.ToString();
            }
            else
            {
                _player.SetVolume(Sl_Volume.Value);
                _settings.LastVolume = Sl_Volume.Value;
            }
            topMostToolStripMenuItem.Checked = _settings.LastOnTop;
            this.Topmost = _settings.LastOnTop;

            RefreshRadioStation(_settings.StationsFolder);
            _player.SetLoopMode(true);
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopPlaying();
            _settings.SaveSettings();
        }

        private void BT_StartPlayback_Click(object sender, EventArgs e)
        {
            if (_player.IsPlaying)
            { return; }
            PlayCurrentStation();
            _settings.LastPlayState = true;
#if DEBUG
            Debug.WriteLine($"time at end: {_player.CurrentTime}");
#endif
        }

        private void BT_StopPlayback_Click(object sender, EventArgs e)
        {
            StopPlaying();
            _settings.LastPlayState = false;
        }

        private void Sl_Volume_ValueChanged(object sender, EventArgs e)
        {
            LB_Volume.Text = Sl_Volume.Value.ToString();
            _player.SetVolume(Sl_Volume.Value);
        }

        private void CbB_Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_player.IsPlaying)
            {
                PlayCurrentStation();
            }
            _settings.CurrentStation = CbB_Stations.SelectedValue.ToString();

#if DEBUG
            Debug.WriteLine($"time at end: {_player.CurrentTime}");
#endif
        }

        private void ClearStationsCommand_Executed(object sender, EventArgs e)
        {
            StopPlaying();
            CbB_Stations.Items.Clear();
            CbB_Stations.Text = string.Empty;
            _radioStations.Stations.Clear();
            _settings.CurrentStation = string.Empty;
            _settings.SavedStations.Clear();
        }

        private void RefreshStationsCommand_Executed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_settings.StationsFolder))
            {
                selectFolderCommand.Execute();
                return;
            }
            RefreshRadioStation(_settings.StationsFolder);
        }

        private void SelectFolderCommand_Executed(object sender, EventArgs e)
        {
            using (SelectFolderDialog folder = new SelectFolderDialog())
            {
                if (string.IsNullOrEmpty(_settings.StationsFolder))
                {
                    folder.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\";
                }
                else
                {
                    folder.Directory = _settings.StationsFolder;
                }
                if (folder.ShowDialog(this) == DialogResult.Ok)
                {
                    _settings.StationsFolder = folder.Directory;
                    RefreshRadioStation(_settings.StationsFolder);
                }
            }
            _settings.SaveSettings();
        }

        private void TopMostToolStripMenuItem_Executed(object sender, EventArgs e)
        {
            this.Topmost = topMostToolStripMenuItem.Checked;
            _settings.LastOnTop = this.Topmost;
        }

        private void PlayCurrentStation()
        {
            _currentStation = _radioStations.GetStation(CbB_Stations.SelectedValue.ToString());
            _player.StartPlayback(ref _currentStation);
            _radioStations.UpdateStationValue(CbB_Stations.SelectedIndex, _currentStation);
            BT_StartPlayback.Enabled = false;
            BT_StopPlayback.Enabled = true;
        }

        private void StopPlaying()
        {
            _player.StopPlayback();
            BT_StartPlayback.Enabled = true;
            BT_StopPlayback.Enabled = false;
        }

        private void PopulateStations()
        {
            CbB_Stations.Items.Clear();
            for (int i = 0; i < _radioStations.Stations.Count; i++)
            {
                CbB_Stations.Items.Add(_radioStations.Stations[i].Name);
            }
        }
        private void RefreshRadioStation(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
            {
                return;
            }
            if (_radioStations.AppendOrUpdateStations(folder) == true)
            {
                StopPlaying();
                PopulateStations();
                _settings.SavedStations = _radioStations.Stations;
                CbB_Stations.SelectedIndex = 0;
            }
        }
    }
}
