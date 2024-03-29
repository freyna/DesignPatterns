﻿namespace Tools
{
    public sealed class Log
    {
        private static Log instance = null;
        private string Path;
        private static object protect = new object();
        public static Log GetInstance (string path)
        {
            lock (protect)
            {
                if (instance == null)
                {
                    instance = new Log(path);
                }

                return instance;
            }
        }

        private Log(string path)
        {
            Path = path;
        }

        public async Task Save(string message)
        {
            await File.AppendAllTextAsync(Path, message + Environment.NewLine);
        }
    }
}
