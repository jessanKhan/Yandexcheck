using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.PhantomJS;



namespace Parser
{
    public partial class Form1 : Form
    {
        string ul;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ul = textBox1.Text;
            txtLog.Text = Parser(ul);
        }



        public string GetHtml(string url)
        {
            string html = null;
            try
            {
                var driverService = PhantomJSDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                var Driver = new PhantomJSDriver(driverService);
                Driver.Navigate().GoToUrl(url);
                while (Driver.PageSource.Contains("setTimeout(function()"))
                    Thread.Sleep(1000);
                html = Driver.PageSource;
                Driver.Close();
                Driver.Quit();
                return html;
            }
            catch { }
            return null;
        }


        public static string Parser(string url)
        {
            HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();
            return output.ToString();
        }

        
        

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}