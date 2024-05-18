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
                                string newImageSource;
                                if (pingReply.RoundtripTime < 250)
                                {
                                    newImageSource = "green.png";
                                }
                                else if (pingReply.RoundtripTime < 450)
                                {
                                    newImageSource = "orange.png";
                                }
                                else
                                {
                                    newImageSource = "red.png";
                                }
                                if (pingUI.Source.ToString() != $"File: {newImageSource}")
                                {
                                    pingUI.Source = newImageSource;
                                }
                            }
                            else
                            {
                                if (pingUI.Source.ToString() != "File: normal.png")
                                {
                                    pingUI.Source = "normal.png";
                                }
                                pingView.Text = "No connection";
                            }
                        });
                    }
                    catch (Exception)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {

                            if (pingUI.Source.ToString() != "File: normal.png")
                            {
                                pingUI.Source = "normal.png";
                            }
                            pingView.Text = "No connection";
                        });
                    }
                }
            });
        }
    }
}
