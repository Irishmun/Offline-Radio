using NAudio.Wave;
using OfflineRadio.Stations;
using System;
using System.Diagnostics;

namespace OfflineRadio.Audio
{
    public class AudioPlayer
    {

        private WaveOutEvent _output;
        private AudioFileReader _audioFile;

        private bool shouldLoop = false;

        public AudioPlayer()
        {
            _output = new WaveOutEvent();
        }

        public void SetVolume(int volume)
        {
            _output.Volume = (float)volume * 0.01f;
        }

        public void StartPlayback(ref Station currentStation)
        {

            if (_audioFile?.FileName != currentStation.AudioFile)
            {
                _audioFile?.Dispose();
                _audioFile = null;
                if (_output != null)
                {
                    _output.PlaybackStopped -= _audio_PlaybackStopped;
                    _output.Dispose();
                    _output = null;
                }
            }

            _output ??= new WaveOutEvent();

            if (_audioFile == null)
            {
                _audioFile = new AudioFileReader(currentStation.AudioFile);
                _output.Init(_audioFile);
                SetPlaybackPosition(ref currentStation);
            }

            _output.Play();

            if (shouldLoop)
            {
                _output.PlaybackStopped += _audio_PlaybackStopped;
            }

#if DEBUG
            Debug.WriteLine($"current time: {_audioFile.CurrentTime}");
#endif
        }

        public void StopPlayback()
        {
            if (_output == null)
            { return; }
            _output.PlaybackStopped -= _audio_PlaybackStopped;
            _output.Stop();
        }


        public void SetLoopMode(bool loop)
        {
            shouldLoop = loop;
        }

        private void _audio_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            _audioFile.CurrentTime = TimeSpan.Zero;
        }

        private void SetPlaybackPosition(ref Station station)
        {
            double duration = _audioFile.TotalTime.TotalSeconds;

            if (duration <= 0)
            { return; }

            if (station.StartOffset < 0)
            {
                Random rand = new Random();
                station.StartOffset = rand.NextDouble() * duration;
            }
            DateTime currentTime = DateTime.Now;
            TimeSpan offset = TimeSpan.FromSeconds(((currentTime - station.StartTime).TotalSeconds + station.StartOffset) % duration);

            _audioFile.CurrentTime = offset;

#if DEBUG
            Debug.WriteLine($"(offset: {offset}){_audioFile.CurrentTime}");
#endif
        }

        public bool IsPlaying => _output.PlaybackState == PlaybackState.Playing;

        public TimeSpan? CurrentTime => _audioFile?.CurrentTime;
    }
}