using FFMpegCore;
using FFmpeg.AutoGen;
using NReco.VideoConverter;

namespace VideoAudioConverter
{
    public class VideoToAudioConverter
    {
        public VideoToAudioConverter() { }
        public void ConvertVideoToAudio(string videoPath, string audioPath)
        {
            return FFMpeg.ExtractAudio(videoPath, audioPath);
        }
    }
}
