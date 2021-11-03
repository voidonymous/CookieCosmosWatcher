using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Json.Net;
using CookieCosmosWatcher.JsonData;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CookieCosmosWatcher
{
    public partial class CookieCosmos : Form
    {
        private int counter = 0;
        private int counter_max = 3600;

        private RootData current_data;

        private bool api_key_changed;
        private DateTime last_check;
        private bool need_to_populate_servers = true;
        private string current_server;
        private DateTime current_server_daily;
        private bool daily_check = false;
        DataGridViewCellStyle style;
        private bool settings_updated = false;

        private Color good_colour = Color.FromArgb(128, 255, 128);
        private Color bad_colour = Color.FromArgb(255, 128, 128);
        private Color middle_colour = Color.Yellow;

        // settings timer
        private bool init = true;
        private int settings_being_saved = 0;
        private int settings_counter = 0;


        struct Cookie_Controls
        {
            public Label price;
            public Label holding;
            public Label paid;
            public Label sell;
            public Label net;
            public Label inflator;
        }

        Dictionary<string, Cookie_Controls> cookie_controls;

        public CookieCosmos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelSettings.SendToBack();
            Properties.Settings.Default.Save();

            FormCheck();
        }

        private void pbxSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = true;
            panelSettings.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelSettings.SendToBack();
            lblHelp.Location = new Point(7, 15);

            // Set up controls ====================================================================================================
            cookie_controls = new Dictionary<string, Cookie_Controls>();
            Cookie_Controls ccCookie = new Cookie_Controls() {      price = null,            holding = lblCookieHolding,        paid = null,            sell = null,            net = null,                 inflator = null };
            Cookie_Controls ccSlime = new Cookie_Controls() {       price = lblSlimePrice,   holding = lblSlimeHolding,         paid = lblSlimePaid,    sell = lblSlimeSell,    net = lblSlimeNet,          inflator = lblSlimeInflator };
            Cookie_Controls ccFire = new Cookie_Controls() {        price = lblFirePrice,    holding = lblFireHolding,          paid = lblFirePaid,     sell = lblFireSell,     net = lblFireNet,           inflator = lblFireInflator };
            Cookie_Controls ccMecha = new Cookie_Controls() {       price = lblMechaPrice,   holding = lblMechaHolding,         paid = lblMechaPaid,    sell = lblMechaSell,    net = lblMechaNet,          inflator = lblMechaInflator };
            Cookie_Controls ccNitro = new Cookie_Controls() {       price = lblNitroPrice,   holding = lblNitroHolding,         paid = lblNitroPaid,    sell = lblNitroSell,    net = lblNitroNet,          inflator = lblNitroInflator };
            Cookie_Controls ccDragon = new Cookie_Controls() {      price = lblDragonPrice,  holding = lblDragonHolding,        paid = lblDragonPaid,   sell = lblDragonSell,   net = lblDragonNet,         inflator = lblDragonInflator };
            Cookie_Controls ccMillionaire = new Cookie_Controls() { price = null,            holding = lblMillionaireHolding,   paid = null,            sell = lblMillionaireSell, net = lblMillionaireNet, inflator = null };
            Cookie_Controls ccVirus = new Cookie_Controls() {       price = null,            holding = lblVirusHolding,         paid = null,            sell = null,            net = null,                 inflator = null };
            Cookie_Controls ccHearts = new Cookie_Controls() {      price = null,            holding = lblHeartsHolding,        paid = null,            sell = null,            net = null,                 inflator = null };
            Cookie_Controls ccGolden = new Cookie_Controls() {      price = null,            holding = lblGoldenHolding,        paid = null,            sell = null,            net = null,                 inflator = null };
            Cookie_Controls ccEternal = new Cookie_Controls() {     price = null,            holding = lblEternalHolding,       paid = null,            sell = null,            net = null,                 inflator = null };

            cookie_controls.Add("Cookie", ccCookie);
            cookie_controls.Add("Slime Cookie", ccSlime);
            cookie_controls.Add("Fire Cookie", ccFire);
            cookie_controls.Add("Mecha Cookie", ccMecha);
            cookie_controls.Add("Nitro Cookie", ccNitro);
            cookie_controls.Add("Dragon Cookie", ccDragon);
            cookie_controls.Add("Millionaire Cookie", ccMillionaire);
            cookie_controls.Add("Heart Cookie", ccHearts);
            cookie_controls.Add("Virus Cookie", ccVirus);
            cookie_controls.Add("Golden Cookie", ccGolden);
            cookie_controls.Add("Eternal Cookie", ccEternal);
            // =====================================================================================================================

            style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(41, 41, 41);
            style.ForeColor = Color.Silver;
            style.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            style.SelectionBackColor = Color.FromArgb(41,41,41);
            style.SelectionForeColor = Color.Yellow;
            dataItems.DefaultCellStyle = style;

            dataItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51,51,51);
            dataItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataItems.EnableHeadersVisualStyles = false;

            cmbxPolling.SelectedIndex = 4;
            cmbxPrioritize.SelectedIndex = 0;

            LoadInfo();
            FormCheck();

            if (tbxApiKey.Text != "")
                LoadData();

            api_key_changed = false;
            init = false;
        }

        private void LoadInfo()
        {
            // load in local settings
            tbxApiKey.Text = Properties.Settings.Default.key;
            current_server = Properties.Settings.Default.current_server;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.key = tbxApiKey.Text;
            Properties.Settings.Default.Save();
        }

        private void FormCheck()
        {
            if (tbxApiKey.Text != "")
            {
                lblHelp.Visible = false;
                panelMain.Visible = true;
                timer.Start();
            }
            else
            {
                lblHelp.Visible = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            lblServerTimeValue.Text = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time")).ToString();

            // checks daily
            if (daily_check)
            {
                if (current_server_daily != null)
                {
                    if (current_server_daily < DateTime.Now)
                    {
                        lblDailyReadyValue.Text = "Ready";
                        lblDailyReadyValue.ForeColor = good_colour;
                        lbxRecommendations.Items.Add("+daily");
                        daily_check = false;
                    }
                }
            }

            if (current_data != null)
            {
                TimeSpan ts = new TimeSpan(0, 0, 0, counter_max - counter);
                toolTip.SetToolTip(pbxRefresh, $"Usage: {current_data.usage}\nLast Called: {current_data.called}\nNext Update: {ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
            }

            // checks if a refresh is needed
            if (counter >= counter_max)
            {
                counter = 0;
                LoadData();
            }
        }

        private void LoadData()
        {
            string url_data = $"https://api.cookiecosmosbot.com/v1.2_dev/data/?t={tbxApiKey.Text}&f=543";

            var data = "";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", ".NET Cookie-Cosmos-Watcher-0.1");
                data = client.DownloadString(url_data);
            }

            // Grab the api response and deserialize it
            if (data != "")
            {
                RootData json_data = JsonConvert.DeserializeObject<RootData>(data);
                current_data = json_data;
            }

            last_check = DateTime.Now;

            if (current_data.result == "Success")
            {
                // server list
                if (need_to_populate_servers)
                {
                    cmbxServerSelect.Items.Clear();

                    foreach (Player s in current_data.player)
                    {
                        cmbxServerSelect.Items.Add(s.guild_name);
                        if (current_server != "")
                        {
                            if (current_server == s.guild_name)
                                cmbxServerSelect.SelectedItem = current_server;
                        }
                    }

                    if (cmbxServerSelect.SelectedIndex == -1)
                    {
                        cmbxServerSelect.SelectedIndex = 0;
                        current_server = cmbxServerSelect.SelectedItem.ToString();
                        Properties.Settings.Default.current_server = current_server;
                        Properties.Settings.Default.Save();
                    }

                    need_to_populate_servers = false;
                }

                RefreshData();
            }
            else
            {
                lblServer.Text = current_data.result + " - " + current_data.response;
                lblServer.ForeColor = bad_colour;
            }
        }

        private void cmbxServerSeleect_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_server = cmbxServerSelect.SelectedItem.ToString();

            if (current_server != "")
            {
                RefreshData();
            }
        }

        private void RefreshData()
        {
            foreach (KeyValuePair<string, Cookie_Controls> kvp in cookie_controls)
            {
                if (kvp.Value.price != null)
                    kvp.Value.price.Text = "0";

                if (kvp.Value.holding != null)
                    kvp.Value.holding.Text = "0";

                if (kvp.Value.paid != null)
                    kvp.Value.paid.Text = "0";
            }

            foreach (EconomyCookie c in current_data.cookies.Where(x => x.name != "Millionaire Cookie"))
            {
                Cookie_Controls ccc = cookie_controls[c.name];
                ccc.price.Text = c.price.ToString();
            }

            lblServer.Text = current_server;
            lblServer.ForeColor = Color.White;
            
            Player server_stuff = current_data.player.Find(x => x.guild_name == current_server);
            double fee_reduction = Math.Round(server_stuff.prestige * 0.05,2);
            long current_cookie_market_value = 0;
            long current_cookie_value = 0;

            if (server_stuff != null)
            {
                lblLotteryTicketsValue.Text = server_stuff.lottery_tickets + "/20";

                bool cj = Convert.ToBoolean(Convert.ToInt32(server_stuff.in_cookie_jar));
                lblCookieJarValue.Text = cj.ToString();
                lblCookieJarValue.ForeColor = cj ? good_colour : bad_colour;

                lblDailyStreakValue.Text = server_stuff.daily_streak.ToString();
                server_stuff.daily_time = server_stuff.daily_time.AddDays(1);
                lblDailyTimeValue.Text = server_stuff.daily_time.ToString();
                current_server_daily = server_stuff.daily_time;
                lblPrestigeValue.Text = server_stuff.prestige.ToString();
                toolTip.SetToolTip(lblPrestigeValue, $"Prestige Rank 3\n- Daily Gain: {Math.Round(server_stuff.prestige * 0.15,2) * 100}%\n- Sale Fee Reduction: {Math.Round(server_stuff.prestige * 0.05, 2) * 100}%");

                current_cookie_value = server_stuff.cookies.Find(x => x.name == "Cookie").amount;

                if (server_stuff.daily_time > DateTime.Now)
                {
                    lblDailyReadyValue.Text = "Not Ready";
                    lblDailyReadyValue.ForeColor = bad_colour;
                    daily_check = true;
                }
                else
                {
                    lblDailyReadyValue.Text = "Ready";
                    lblDailyReadyValue.ForeColor = good_colour;
                    daily_check = false;
                }

                foreach (PlayerCookie pc in server_stuff.cookies)
                {
                    Cookie_Controls ccpc = cookie_controls[pc.name];
                    if (pc.name == "Eternal Cookie")
                        ccpc.holding.Text = Math.Round((double)pc.amount / 10000, 4).ToString();
                    else
                        ccpc.holding.Text = pc.amount.ToString();

                    if (pc.price != -1 && ccpc.paid != null)
                        ccpc.paid.Text = pc.price.ToString();

                    if (pc.amount > 0 && ccpc.net != null)
                    {
                        double bought_for = Math.Round((double)pc.amount * pc.price, 0);
                        double sell_for_raw = Math.Round((double)pc.amount * current_data.cookies.Find(x => x.name == pc.name).price, 0);
                        double sell_for_sale_fee = Math.Floor(sell_for_raw * (0.9 + (fee_reduction / 10)));
                        double sell_for_net = sell_for_sale_fee - bought_for;
                        ccpc.sell.Text = sell_for_sale_fee.ToString();
                        ccpc.net.Text = sell_for_net.ToString();
                        ccpc.net.ForeColor = ccpc.net.Text.Contains("-") ? bad_colour : good_colour;

                        current_cookie_market_value += (long)sell_for_sale_fee;

                        if (ccpc.inflator != null)
                        {
                            double from = Math.Floor(sell_for_sale_fee * 1.35) - 25000;
                            double to = Math.Floor(sell_for_sale_fee * 1.50) - 25000;
                            string inflate = from + " / " + to;
                            ccpc.inflator.Text = inflate;
                            ccpc.inflator.ForeColor = (from.ToString().Contains("-") || to.ToString().Contains("-")) ? bad_colour : good_colour;
                        }

                        // recommendations
                        double rate_base = (sell_for_sale_fee / bought_for);
                        double rate_inflate = ((sell_for_sale_fee * 1.35) / bought_for);
                        if (rate_inflate > 2)
                        {
                            lbxRecommendations.Items.Add("+items use inflator");
                            lbxRecommendations.Items.Add("+cookie sell max " + pc.name);
                        }
                        else if (rate_base > 1.5)
                        {
                            lbxRecommendations.Items.Add("+cookie sell max " + pc.name);
                        }
                    }
                }

                current_cookie_market_value += current_cookie_value;
                lblCookieValueValue.Text = current_cookie_market_value.ToString();
                int prestige_needed = 1000000 + (server_stuff.prestige * 250000);
                if (current_cookie_value >= prestige_needed)
                {
                    lblCanPrestigeValue.Text = "Yes";
                    lblCanPrestigeValue.ForeColor = good_colour;
                    toolTip.SetToolTip(lblCanPrestigeValue, $"Required = {prestige_needed}\nCurrent = {current_cookie_value}");
                }
                else if (current_cookie_market_value >= prestige_needed)
                {
                    lblCanPrestigeValue.Text = "Yes (with sales)";
                    lblCanPrestigeValue.ForeColor = middle_colour;
                    toolTip.SetToolTip(lblCanPrestigeValue, $"Required: {prestige_needed}\nCurrent: {current_cookie_value}\nAfter Sales: {current_cookie_market_value}");
                }
                else
                {
                    lblCanPrestigeValue.Text = "No";
                    lblCanPrestigeValue.ForeColor = bad_colour;
                    toolTip.SetToolTip(lblCanPrestigeValue, $"Required: {prestige_needed}\nCurrent: {current_cookie_value}\nAfter Sales: {current_cookie_market_value}");
                }

                dataItems.Rows.Clear();
                foreach (PlayerItem pi in server_stuff.items)
                {
                    dataItems.Rows.Add(pi.item_type, (pi.item_type == "Consumable" ? pi.name : pi.name + $" ({pi.description})"), pi.amount);
                }

                dataItems.ClearSelection();
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            TextFormatFlags sf = TextFormatFlags.VerticalCenter |
                                 TextFormatFlags.NoFullWidthCharacterBreak;

            e.Graphics.Clear(Color.FromArgb(150, 132, 136, 138));
            toolTip.BackColor = Color.FromArgb(150, 132, 136, 138);
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText(sf);
        }

        private void pbxRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbxKeepTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = cbxKeepTop.Checked ? true : false;
        }

        private void cbxShowRecommendations_CheckedChanged(object sender, EventArgs e)
        {
            lblProfitThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            lblInflatorThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            lblPrioritize.Enabled = cbxShowRecommendations.Checked ? true : false;
            numProfitThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            numInflatorThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            cmbxPrioritize.Enabled = cbxShowRecommendations.Checked ? true : false;
        }

        private void lblExtraApiGen_Click(object sender, EventArgs e)
        {
            API_Generator apgen = new API_Generator(tbxApiKey.Text);
            apgen.Show();
        }

        private void lblGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/voidonymous/CookieCosmosWatcher");
        }

        private void SaveSettings()
        {
            if (!init)
            {
                settings_being_saved = 1;
                lblSettingsSaved.Visible = true;
                timerSettingsSaved.Start();
            }
        }

        private void timerSettingsSaved_Tick(object sender, EventArgs e)
        {
            if (settings_being_saved == 1)
            {
                if (lblSettingsSaved.Top >= 6)
                {
                    settings_being_saved = 2;
                    settings_counter = 0;
                }
                else
                    lblSettingsSaved.Location = new Point(lblSettingsSaved.Left, lblSettingsSaved.Top + 1);
            }
            else if (settings_being_saved == 2)
            {
                settings_counter++;
                if (settings_counter >= 100)
                    settings_being_saved = 3;
            }
            else if (settings_being_saved == 3)
            {
                if (lblSettingsSaved.Top + lblSettingsSaved.Height <= -2)
                {
                    settings_being_saved = 0;
                    lblSettingsSaved.Visible = false;
                }
                else
                    lblSettingsSaved.Location = new Point(lblSettingsSaved.Left, lblSettingsSaved.Top - 1);
            }

            Application.DoEvents();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void cmbxPolling_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
