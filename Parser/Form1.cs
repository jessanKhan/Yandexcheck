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
        //int t = 0;
        string ul;
         string res;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ul = textBox1.Text;
            richTextBox.Text = Parser(ul);
           
            
        }


        private void search_Click(object sender, EventArgs e)
        {
            //int index = 0;
            //String temp = richTextBox.Text;

            //richTextBox.Text = temp;
            //while (index < richTextBox.Text.LastIndexOf(textBox2.Text))

            //{
            //    richTextBox.Find(textBox2.Text, index, richTextBox.TextLength, RichTextBoxFinds.None);
            //    richTextBox.SelectionBackColor = System.Drawing.Color.Red;
            //    index = richTextBox.Text.IndexOf(textBox2.Text, index) + 1;
            //}

        }


        //private void search_Click(object sender, EventArgs e)
        //{
        //    for (int i = t; i < richTextBox.TextLength - textBox2.TextLength; i++)
        //    {
        //        string x = "";
        //        for (int j = 0; j < textBox2.TextLength; j++)
        //        {
        //            if (textBox2.Text[j] == richTextBox.Text[i + j])
        //            {
        //                x += richTextBox.Text[i + j] + "";

        //            }

        //            else x = "";
        //        }
        //        if (x == textBox2.Text)
        //        {

        //            t = i + 1;
        //            richTextBox.SelectAll();
        //            richTextBox.SelectionBackColor = System.Drawing.Color.Green;
        //            richTextBox.Select(i, textBox2.TextLength);
        //            richTextBox.SelectionBackColor = System.Drawing.Color.Blue;
        //            break;

        //        }
        //    }


        //}



        //private void button2_Click(object sender, EventArgs e)
        //{
        //    string[] counter = textBox2.Text.Split(',');
        //    foreach (string word in counter)
        //    {
        //        int startIndex = 0;
        //        while (startIndex < richTextBox.TextLength)
        //        {
        //            int wordStartIndex = richTextBox.Find(word, startIndex, RichTextBoxFinds.None);
        //            if (wordStartIndex != -1)
        //            {
        //                richTextBox.SelectionStart = wordStartIndex;
        //                richTextBox.SelectionLength = word.Length;
        //                richTextBox.SelectionBackColor = System.Drawing.Color.Yellow;


        //            }
        //            else
        //                break;
        //            startIndex += wordStartIndex + word.Length;
        //        }
        //    }
        //}

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
            { return Fdmsg.Text = "Please Check The Network Connection or the URL There is an Error !!"; }
            
        }


        //private void richTextBox_TextChanged(object sender, EventArgs e)
        //{

        //}

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void srchbtn_Click(object sender, EventArgs e)
        {
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
            {
                Fdmsg.ForeColor = System.Drawing.Color.Green;
                Fdmsg.Text = "Counter Found";


            }
            else
            {
                Fdmsg.ForeColor = System.Drawing.Color.Red;
                Fdmsg.Text = "Counter Not Found";

            }

        }

        private void pageld_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}