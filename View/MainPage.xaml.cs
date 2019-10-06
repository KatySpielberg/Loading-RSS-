using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPRSSapp.Model;
using UWPRSSapp.ViewModel;
using Windows.Storage;
using Windows.Storage.Pickers;
using System.Xml.Serialization;
using System.Net;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPRSSapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new MainViewModel();
            this.DataContext = this.ViewModel;
        }

        private async void BtnLoadRss_Click(object sender, RoutedEventArgs e)
        {
            string url = txtURL.Text;

            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.BeginGetResponse(new AsyncCallback(ReadRss), request);
         }

        private void ReadRss(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;


            using (Stream stream = response.GetResponseStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                Rss rss = (Rss)serializer.Deserialize(stream);
                Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                    this.ViewModel.CurrentRss = rss;
                });
            }

        }
    }
}
