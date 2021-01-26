using Nancy.Json;
using Newtonsoft.Json;
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

namespace catsdogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dogImage = GetDogImageUrl();

            pictureBox1.ImageLocation = dogImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public static string GetDogImageUrl()
        {
            string url = "https://dog.ceo/api/breeds/image/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            string imageUrl;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Dog dog = JsonConvert.DeserializeObject<Dog>(response);

                imageUrl = dog.message;

            }

            return imageUrl;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string catImage = GetCatImage();
            pictureBox2.ImageLocation = catImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public static string GetCatImage()
        {
            string url = "https://api.thecatapi.com/v1/images/search";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string catimage;

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Cat> catList = ser.Deserialize<List<Cat>>(response);
                catimage = catList[0].url;
            }
            return catimage;
        }

    }
}
        
    

