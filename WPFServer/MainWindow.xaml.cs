using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;

namespace WPFServer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                // Verifica se existe conectividade de rede
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show("Verifique a conectividade de rede...");

                    this.Close();
                }

                // Recupera o endereço IPv4 em uso
                string[] ipAddress = null;

                var host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipAddress = ip.ToString().Split('.');
                    }
                }

                maskedTextBoxIp.FirstBox.Text = ipAddress[0];
                maskedTextBoxIp.SecondBox.Text = ipAddress[1];
                maskedTextBoxIp.ThirdBox.Text = ipAddress[2];
                maskedTextBoxIp.FourthBox.Text = ipAddress[3];

                textBoxPorta.Text = "11000";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
