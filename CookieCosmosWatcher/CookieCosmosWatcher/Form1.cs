﻿using System;
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

namespace CookieCosmosWatcher
{
    public partial class Form1 : Form
    {
        private int counter = 0;
        private int counter_max = 3600;

        private RootPlayer current_player;
        private RootCookie current_cookie;

        private bool api_key_changed;
        private DateTime last_check;
        private bool need_to_populate_servers = true;
        private string current_server;
        DataGridViewCellStyle style;

        private Color good_colour = Color.FromArgb(128, 255, 128);
        private Color bad_colour = Color.FromArgb(255, 128, 128);
        private Color middle_colour = Color.Yellow;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelSettings.SendToBack();

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

            LoadInfo();
            FormCheck();

            if (tbxApi.Text != "")
                LoadData();

            api_key_changed = false;
        }

        private void LoadInfo()
        {
            // load in local settings
            tbxApi.Text = Properties.Settings.Default.key;
            current_server = Properties.Settings.Default.current_server;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.key = tbxApi.Text;
            Properties.Settings.Default.Save();
        }

        private void FormCheck()
        {
            if (tbxApi.Text != "")
            {
                // do all the things
                lblHelp.Visible = false;
                timer.Start();
                counter = 0;
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
            if (counter >= counter_max)
            {
                counter = 0;
                LoadData();
            }
        }

        private void LoadData()
        {
            string url_player = $"https://api.cookiecosmosbot.com/v1.1/player/?t={tbxApi.Text}";
            string url_cookie = $"https://api.cookiecosmosbot.com/v1.1/cookie/?t={tbxApi.Text}";

            var data_player = "";
            var data_cookie = "";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", ".NET Cookie-Cosmos-Watcher-0.1");
                data_player = client.DownloadString(url_player);
                client.Headers.Add("user-agent", ".NET Cookie-Cosmos-Watcher-0.1");
                data_cookie = client.DownloadString(url_cookie);
            }

            // Grab the api response and deserialize it
            if (data_player != "")
            {
                RootPlayer new_player = JsonConvert.DeserializeObject<RootPlayer>(data_player);
                current_player = new_player;
            }

            if (data_cookie != "")
            {
                RootCookie new_cookie = JsonConvert.DeserializeObject<RootCookie>(data_cookie);
                current_cookie = new_cookie;
            }

            last_check = DateTime.Now;

            if (current_player.result == "Success")
            {
                // server list
                if (need_to_populate_servers)
                {
                    cmbxServerSeleect.Items.Clear();

                    foreach (Server s in current_player.servers)
                    {
                        cmbxServerSeleect.Items.Add(s.guild_name);
                        if (current_server != "")
                        {
                            if (current_server == s.guild_name)
                                cmbxServerSeleect.SelectedItem = current_server;
                        }
                    }

                    if (cmbxServerSeleect.SelectedIndex == -1)
                    {
                        cmbxServerSeleect.SelectedIndex = 0;
                        current_server = cmbxServerSeleect.SelectedItem.ToString();
                        Properties.Settings.Default.current_server = current_server;
                        Properties.Settings.Default.Save();
                    }

                    need_to_populate_servers = false;
                }

                // 
                RefreshData();
            }
            else
            {
                lblServer.Text = current_player.result + " - " + current_player.response;
                lblServer.ForeColor = bad_colour;
            }
        }

        private void cmbxServerSeleect_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_server = cmbxServerSeleect.SelectedItem.ToString();

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

            foreach (JsonData.Cookie c in current_cookie.cookies.Where(x => x.name != "Millionaire Cookie"))
            {
                Cookie_Controls ccc = cookie_controls[c.name];
                ccc.price.Text = c.price.ToString();
            }

            lblServer.Text = current_server;
            lblServer.ForeColor = Color.White;
            
            Server server_stuff = current_player.servers.Find(x => x.guild_name == current_server);
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
                lblDailyTimeValue.Text = server_stuff.daily_time.ToString();
                lblPrestigeValue.Text = server_stuff.prestige.ToString();
                toolTip.SetToolTip(lblPrestigeValue, $"Prestige Rank 3\n- Daily Gain: {Math.Round(server_stuff.prestige * 0.15,2) * 100}%\n- Sale Fee Reduction: {Math.Round(server_stuff.prestige * 0.05, 2) * 100}%");

                current_cookie_value = server_stuff.cookies.Find(x => x.name == "Cookie").amount;

                if (server_stuff.daily_time < DateTime.Now)
                {
                    lblDailyReadyValue.Text = "Not Ready";
                    lblDailyReadyValue.ForeColor = bad_colour;
                }
                else
                {
                    lblDailyReadyValue.Text = "Ready";
                    lblDailyReadyValue.ForeColor = good_colour;
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
                        double sell_for_raw = Math.Round((double)pc.amount * current_cookie.cookies.Find(x => x.name == pc.name).price, 0);
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
                    dataItems.Rows.Add(pi.item_type, pi.name, pi.amount);
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
    }
}