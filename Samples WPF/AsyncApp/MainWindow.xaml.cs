using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncApp
{

    // http://msdn.microsoft.com/de-de/library/vstudio/hh556530.aspx

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Debug.WriteLine(String.Format("Start, Aktueller Thread: {0}", Thread.CurrentThread.ManagedThreadId));
        }

        private List<string> BeginFindAvailableServers()
        {
            var dm = new DirectoryEntry(String.Format("WinNT://{0}", Environment.UserDomainName));

            dm.Children.SchemaFilter.Add("Computer");

            return (from DirectoryEntry d in dm.Children select d.Name).ToList();
        }

        // The following async method returns a Task<T>.
        // A typical call awaits the byte array result: 
        //      byte[] result = await GetURLContentsAsync("http://msdn.com");
        private async Task<byte[]> GetURLContentsAsync(string url)
        {
            // The download will end up in variable content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                // Get the data stream that is associated with the specified url.
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }

            // Return the result as a byte array.
            return content.ToArray();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResult.Clear();

            long nValue = await ProcessAsync(50000000);
             
            // long nValue = Process(50000000);
            
            txtResult.Text = nValue.ToString();

        }

        public Task<long> ProcessAsync(long rounds)
        {
            return Task.Run<long>(() => Process(rounds));
        }

        public long Process(long rounds)
        { 
            Thread.Sleep(2000);

            Debug.WriteLine(String.Format("Hauptthread: {0}, Aktueller Thread: {1}", this.Dispatcher.Thread.ManagedThreadId, Thread.CurrentThread.ManagedThreadId));

            long number = 0;

            for (var i = 0; i < rounds; i++)
                number += i;

            return number;
        }
    }
}
