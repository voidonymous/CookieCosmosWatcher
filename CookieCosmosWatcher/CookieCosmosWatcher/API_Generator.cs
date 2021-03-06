using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieCosmosWatcher
{
    public partial class API_Generator : Form
    {
        public API_Generator(string form_api_key = "")
        {
            api_key = form_api_key;
            InitializeComponent();
        }

        private string base_url = "https://api.cookiecosmosbot.com/v1.2_dev/data/";
        private string api_key = "";
        private int selected_dataset_binary = 0;
        private TextBox tbxDataSets;

        private int counter = 0;
        private int counter_max = 2;

        private void API_Generator_Load(object sender, EventArgs e)
        {
            tbxApiKey.Text = api_key;
            selected_dataset_binary = 0;
            MakeUrl();
        }

        private void MakeUrl()
        {
            tbxApiUrl.Text = $"{base_url}?t={(api_key != "" ? api_key : "{api_key}")}{(selected_dataset_binary > 0 ? $"&f={selected_dataset_binary}" : "")}";
        }

        private void CalculateDataset(object sender, EventArgs e)
        {
            CheckBox current = (CheckBox)sender;
            int value = Convert.ToInt32(current.Tag);

            if (cbxPlayerCookies.Checked || cbxPlayerItemsConsumables.Checked || cbxPlayerItemsCraftables.Checked || cbxPlayerItemsPermanents.Checked || cbxPlayerRelics.Checked || cbxPlayerTitles.Checked
                || cbxPlayerAchievements.Checked || cbxPlayerStats.Checked)
            {
                cbxPlayerServers.Checked = true;
            }
            else
            {
                cbxPlayerServers.Checked = false;
            }

            if (current.Checked)
                selected_dataset_binary += value;
            else
                selected_dataset_binary -= value;

            MakeUrl();
        }

        private void tbxApiUrl_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxApiUrl.Text);
            lblCopied.Visible = true;
            counter = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= counter_max)
            {
                timer.Stop();
                lblCopied.Visible = false;
            }
        }

        private void tbxApiKey_TextChanged(object sender, EventArgs e)
        {
            api_key = tbxApiKey.Text;
            MakeUrl();
        }

        private void btnCopyToSettings_Click(object sender, EventArgs e)
        {
            tbxDataSets.Text = selected_dataset_binary.ToString();
        }
    }
}
