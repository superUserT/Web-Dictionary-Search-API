using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace OxfordDictionary_RNTTHA006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            //Create new HttpClient. 
            var client = new HttpClient();

            //Set the HTTP base address.
            client.BaseAddress = new Uri("https://od-api.oxforddictionaries.com/api/v2/");

            //Set the headers that include the type of request and your app_id and app-key
            client.DefaultRequestHeaders.Accept.Clear();


            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("app_id", txtAppID.Text);
            client.DefaultRequestHeaders.Add("app_key", txtAppKey.Text);


            //create the request string from the parameters in your form
            var requestString = "entries/en-gb/" + txtWord.Text + "?fields=" + txtFields.Text + "&strictMatch=" + txtMatch.Text;

            //display your URL request for debugging purposes
            txtAPI.Text = client.BaseAddress.ToString() + requestString;

            //Send the HTTP GET request Asynchronously
            HttpResponseMessage response = await client.GetAsync(requestString);

            //Wait for the server response and read it into the result string
            string result = await response.Content.ReadAsStringAsync();

            //Display the server response code and response
            txtCode.Text = response.StatusCode.ToString();
            txtResponse.Text = result;








        }
    }
}
