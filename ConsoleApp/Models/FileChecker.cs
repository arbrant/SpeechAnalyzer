using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public static class FileChecker
    {
        public static bool CheckIfFileIsAudioOrVideo(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            // List of common audio file extensions
            string[] audioExtensions = { ".mp3", ".wav", ".aac", ".flac", ".ogg", ".m4a" };

            // List of common video file extensions
            string[] videoExtensions = { ".mp4", ".avi", ".mov", ".wmv", ".flv", ".mkv" };

            // Check if the file extension is in the list of audio or video extensions
            if (Array.IndexOf(audioExtensions, extension) >= 0 || Array.IndexOf(videoExtensions, extension) >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
