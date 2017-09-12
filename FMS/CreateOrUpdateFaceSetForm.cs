using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMS
{
    public partial class CreateOrUpdateFaceSetForm : Form
    {
        public CreateOrUpdateFaceSetForm()
        {
            InitializeComponent();
        }

        public Cody.FacePP.Core.IWebClient ApiClient { get; set; }

        public string FaceSetToken { get; set; }

        public string DisplayName
        {
            get
            {
                return this.textBox_DisplayName.Text;
            }
            set
            {
                this.textBox_DisplayName.Text = value;
            }
        }

        public string OuterId
        {
            get
            {
                return this.textBox_OuterId.Text;
            }
            set
            {
                this.textBox_OuterId.Text = value;
            }
        }

        public List<string> Tags
        {
            get
            {
                var text = this.textBox_Tags.Text;
                if (!string.IsNullOrWhiteSpace(text))
                    return text.Split(',').ToList();
                return null;
            }
            set
            {
                if (value != null && value.Count > 0)
                    this.textBox_Tags.Text = string.Join(",", value);
                else
                    this.textBox_Tags.Text = "";
            }
        }

        public List<string> FaceTokens
        {
            get
            {
                var text = this.textBox_FaceTokens.Text;
                if (!string.IsNullOrWhiteSpace(text))
                    return text.Split(',').ToList();
                return null;
            }
            set
            {
                if (value != null && value.Count > 0)
                    this.textBox_FaceTokens.Text = string.Join(",", value);
                else
                    this.textBox_FaceTokens.Text = "";
            }
        }

        public string UserData
        {
            get
            {
                return this.textBox_UserData.Text;
            }
            set
            {
                this.textBox_UserData.Text = value;
            }
        }

        private async Task<bool> LoadFaceSetInfo()
        {
            var request = new Cody.FacePP.Api.FaceSet.GetFaceSetDetailRequest
            {
                FaceSetToken = this.FaceSetToken,
            };
            var response = await this.ApiClient.GetResponseAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.DisplayName = response.DisplayName;
                this.OuterId = response.OuterId;
                this.Tags = response.Tags;
                this.FaceTokens = response.FaceTokens.ToList();
                this.UserData = response.UserData;
                this.button1.Text = "Update";
            }

            return true;
        }

        private async void CreateOrUpdateFaceSetForm_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.FaceSetToken))
                await LoadFaceSetInfo();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.FaceSetToken))
            {
                //update
                var request = new Cody.FacePP.Api.FaceSet.UpdateFaceSetRequest
                {
                    FaceSetToken = this.FaceSetToken,
                    DisplayName = this.DisplayName,
                    NewOuterId = this.OuterId,
                    UserData = this.UserData,
                    Tags = this.Tags
                };
                var response = await this.ApiClient.GetResponseAsync(request);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //success
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                //create
                var request = new Cody.FacePP.Api.FaceSet.CreateFaceSetRequest
                {
                    OuterId = this.OuterId,
                    DisplayName = this.DisplayName,
                    Tags = this.Tags,
                    FaceTokens = this.FaceTokens,
                    UserData = this.UserData,
                    IsForceMerge = false
                };
                var response = await this.ApiClient.GetResponseAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //success
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
