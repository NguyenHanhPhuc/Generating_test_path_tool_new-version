using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demotestq1
{
    public partial class formPath : Form
    {
        public List<string> lsts3 = new List<string>();
        public List<string> lsts4 = new List<string>();
        public formPath(List<string> lst, List<string> lstt1)
        {

            InitializeComponent();

            //richtxbout1.Clear();
            for (int i = 0; i < lst.Count; i++)
            {
                lsts3.Add(lst[i]);
                //richtest.Text += lsts2[i];
            }
            for (int i = 0; i < lstt1.Count; i++)
            {
                
                lsts4.Add(lstt1[i]);
                //richtest.Text += lsts2[i];
            }
            //lsts3 = lsts3.Distinct().ToList();

          
            //richtxbout1.Text = "Total Path :" + lsts4.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lsts3[0] == "")
            {
                MessageBox.Show("Fill in the link in the box");
            }
            string Url = lsts3[0];
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            //dataGridView1.DataSource = result;

            string fileLPath = txtPATH.Text;




            System.IO.File.WriteAllText(fileLPath, result);
            //Console.WriteLine(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fileLPath = txtPATH.Text;



                //System.IO.File.WriteAllText(fileLPath, conttran);
                System.IO.File.WriteAllLines(fileLPath, lsts3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formPath_Load(object sender, EventArgs e)
        {
            richtxbout1.Clear();

            for(int i=0;i<lsts4.Count;i++)
            {
                richtxbout1.Text += lsts4[i] + "\n";
            }
            //richtxbout1.Text += "Total Path :" + lsts4.Count();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //formPath f = new formPath(lsts2, lstrids);
            string fileLPath = txtPATH.Text;

            //f.Show();

            //System.IO.File.WriteAllText(fileLPath, conttran);
             System.IO.File.WriteAllLines(fileLPath, lsts4);
        }

        private void richtxbout_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
