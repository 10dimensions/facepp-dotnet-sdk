using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cody.FacePP.Core;
using Cody.FacePP.Api;

namespace FMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IWebClient client = new DefaultApiClient(new DefaultProfile("", ""));

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var request = new Cody.FacePP.Api.FaceSet.GetAllFaceSetsRequest();
            var response = await client.GetResponseAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                foreach(var f in response.FaceSets)
                {
                    this.comboBox1.Items.Add(f.FaceSetToken);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrUpdateFaceSetForm cf = new CreateOrUpdateFaceSetForm
            {
                FaceSetToken = this.comboBox1.Text,
                ApiClient = client
            };
            cf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateOrUpdateFaceSetForm cf = new CreateOrUpdateFaceSetForm
            {
                ApiClient = client
            };
            cf.ShowDialog();
        }
    }
}
