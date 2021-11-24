using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GDNative_Project_Creator
{
    internal class DataAndFilesDownloader
    {
        WebClient Client;
        public string Url;
        public string Name;
        public DataAndFilesDownloader(string url, string name)
        {
            Client = new WebClient();
            Url = url;
            Name = name;
        }

        public string DownloadString()
        {
            Console.Clear();
            Console.WriteLine($"Iniciando descarga de: {Name}...");

            Client.DownloadProgressChanged += DownloadProgressChanged;

            byte[] DownloadedData = Client.DownloadData(Url);

            return System.Text.Encoding.UTF8.GetString(DownloadedData);
        }

        public void DownloadFile(string Path)
        {
            Console.Clear();
            Console.WriteLine($"Iniciando descarga de: {Name}...");

            Client.DownloadProgressChanged += DownloadProgressChanged;

            Client.DownloadFile(Url, Path);
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Descargando: " + Name + " --------- " + e.ProgressPercentage + "%");
        }
    }
}
