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
    public partial class yandex_check : Form
    {
        // Assigning the input url on a variable
        string ul;
        public yandex_check()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ul = textBox1.Text;
            richTextBox.Text = Parser(ul);
           
            
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


        public string Parser(string url)
        { try
            {
                Fdmsg.Text = "";
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
            catch (Exception e)
            { Fdmsg.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                return Fdmsg.Text="Please Check The Network Connection or the URL, There is an Error !!"; }
            
        }


       

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void srchbtn_Click(object sender, EventArgs e)
        {
            string textboxValue = textBox2.Text;

            // Retrieve as decimal
            decimal valueDec = decimal.Parse(textboxValue);

            // Retrieve as integer
            int valueInt = Int32.Parse(textboxValue);
            
            //Search procedure starts here
            int index = 0;
            String temp = richTextBox.Text;

            richTextBox.Text = temp;
            while (index < richTextBox.Text.LastIndexOf(textBox2.Text))

            {
                richTextBox.Find(textBox2.Text, index, richTextBox.TextLength, RichTextBoxFinds.None);
                richTextBox.SelectionBackColor = System.Drawing.Color.Red;
                index = richTextBox.Text.IndexOf(textBox2.Text, index) + 1;
                

            }
            if (richTextBox.SelectionBackColor == System.Drawing.Color.Red)
            {    // Gives Message when counter is found
                Fdmsg.ForeColor = System.Drawing.Color.FromArgb(14, 242, 151);
                Fdmsg.Text = "Counter Found";


            }
            else
            {   // Gives Message when counter is not found
                Fdmsg.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                Fdmsg.Text = "Counter Not Found";

            }

        }

        private void pageld_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {    //Search the counter which is only numeric 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            
        }
    }
}