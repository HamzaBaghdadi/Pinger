using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Pinger
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            StartPinging();
        }

        private void StartPinging()
        {
            Task.Run(async () =>
            {
                Ping ping = new Ping();
                while (true)
                {
                    try
                    {
                        PingReply pingReply = await ping.SendPingAsync("google.com");
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            if (pingReply.Status == IPStatus.Success)
                            {
                                pingView.Text = $"{pingReply.RoundtripTime} ms";
                            }
                            else
                            {
                                pingView.Text = "No connection";
                            }
                        });
                    }
                    catch (Exception)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            pingView.Text = "Wrong IP";
                        });
                    }
                }
            });
        }
    }
}
