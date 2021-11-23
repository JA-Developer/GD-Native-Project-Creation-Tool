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

        public async Task<string> DownloadString()
        {
            Console.Clear();
            Console.WriteLine("Iniciando descarga...");

            Client.DownloadProgressChanged += DownloadProgressChanged;
            Client.DownloadDataCompleted += Client_DownloadDataCompleted; ;


            byte[] DownloadedData = await Client.DownloadDataTaskAsync(Url);

            return System.Text.Encoding.UTF8.GetString(DownloadedData);
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Console.Clear();
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Descargando: " + Name + " --------- " + e.ProgressPercentage + "%");
        }
    }
}
