using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace IP_lock
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // string licenseIp = "117.110.115.128";
            string[] ip = new string[100];
            ip[0] = "117.110.115.128"; // your are ip address 0 ~ 100
            ip[1] = ""; // your are ip address 0 ~ 100
            string serverIp;
            try
            {
                string searchIpFromUrl = new System.Net.WebClient().DownloadString(("http://checkip.dyndns.org"));
                string EtcIpInfo = searchIpFromUrl.Substring(searchIpFromUrl.IndexOf("</body>"), searchIpFromUrl.Length - searchIpFromUrl.IndexOf("</body>"));
                serverIp = searchIpFromUrl.Substring(searchIpFromUrl.IndexOf(":") + 1, searchIpFromUrl.Length - searchIpFromUrl.IndexOf(":") - EtcIpInfo.Length - 1).Trim();
            }
            catch
            {
                throw;
            }
            for (int i = 0; i < ip.Length; i++)
            {


                if (serverIp == ip[i])
                {
                    MessageBox.Show("License for " + ip[i], "Claude-Agnes17");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;
                }
                else
                {
                    MessageBox.Show("아이피가 맞지 않습니다.");
                    Application.Exit();
                }
            }
        }
    }
}