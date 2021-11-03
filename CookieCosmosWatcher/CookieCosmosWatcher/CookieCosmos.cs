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
using Microsoft.Win32;

namespace CookieCosmosWatcher
{
    public partial class CookieCosmos : Form
    {
        private const int BUILDNUM = 4;
        private const string PROGRAMNAME = "Cookie Cosmos Watcher";
        private int counter = 0;
        private int counter_max = 3600;

        private RootData current_data;
        private Updates update_data;

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
        private int update_counter = 0;
        private int update_counter_timeout = 3600;

        // context menus
        private ContextMenu cm_consumable = new ContextMenu();
        private ContextMenu cm_craftable = new ContextMenu();

        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

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

            MenuItem cm_buy = new MenuItem();
            cm_buy.Text = "Copy Buy Command";
            cm_buy.Click += new System.EventHandler(cm_buy_do);

            MenuItem cm_sell = new MenuItem();
            cm_sell.Text = "Copy Sell Command";
            cm_sell.Click += new System.EventHandler(cm_sell_do);

            MenuItem cm_use = new MenuItem();
            cm_use.Text = "Copy Use Command";
            cm_use.Click += new System.EventHandler(cm_use_do);

            cm_consumable.MenuItems.Add(cm_use);
            cm_consumable.MenuItems.Add(cm_buy);
            cm_consumable.MenuItems.Add(cm_sell);

            cm_craftable.MenuItems.Add(cm_buy);
            cm_craftable.MenuItems.Add(cm_sell);

            if (registryKey.GetValue(PROGRAMNAME) == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                cbxStartWindows.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                cbxStartWindows.Checked = true;
            }

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
            string url_data = $"https://api.cookiecosmosbot.com/v1.2_dev/data/?t={tbxApiKey.Text}&f=1567";

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

                if (kvp.Value.sell != null)
                    kvp.Value.sell.Text = "0";

                if (kvp.Value.net != null)
                    kvp.Value.net.Text = "0";

                if (kvp.Value.inflator != null)
                    kvp.Value.inflator.Text = "0";
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
                    dataItems.Rows.Add(pi.name, pi.item_type, (pi.item_type == "Consumable" ? pi.name : pi.name + $" ({pi.description})"), pi.amount);
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

        private void cbxShowRecommendations_CheckedChanged(object sender, EventArgs e)
        {
            lblProfitThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            lblInflatorThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            lblPrioritize.Enabled = cbxShowRecommendations.Checked ? true : false;
            numProfitThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            numInflatorThreshold.Enabled = cbxShowRecommendations.Checked ? true : false;
            cmbxPrioritize.Enabled = cbxShowRecommendations.Checked ? true : false;
            panelRecommendations.Visible = cbxShowRecommendations.Checked ? true : false;

            Properties.Settings.Default.show_rec = cbxShowRecommendations.Checked ? true : false;
            SaveSettings();
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

        private void cmbxPolling_SelectedIndexChanged(object sender, EventArgs e)
        {
            int poll_rate = Convert.ToInt16(cmbxPolling.SelectedItem.ToString());
            Properties.Settings.Default.polling = poll_rate;
            counter_max = poll_rate * 60;
            if (counter > counter_max)
                counter = counter_max;

            SaveSettings();
        }

        private void cmbxServerSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_server = cmbxServerSelect.SelectedItem.ToString();

            if (current_server != "")
            {
                RefreshData();
            }
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            btnCheckUpdate.Enabled = false;
            lblCheckingUpdate.Visible = true;
            update_counter = 0;
            timerUpdate.Start();
            lblCheckingUpdate.Text = $"Checking...";
            Application.DoEvents();

            CheckForUpdate();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            update_counter++;

            if (update_counter >= update_counter_timeout)
            {
                btnCheckUpdate.Enabled = true;
                lblCheckingUpdate.Visible = false;
                timerUpdate.Stop();
            }
        }

        private void CheckForUpdate()
        {
            string url_data = $"https://cookiecosmosbot.com/tools/versions/?c=000-000";

            var data = "";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", ".NET Cookie-Cosmos-Watcher-0.1-updater");
                data = client.DownloadString(url_data);
            }

            // Grab the api response and deserialize it
            if (data != "")
            {
                Updates json_data = JsonConvert.DeserializeObject<Updates>(data);
                update_data = json_data;

                if (json_data.name == "cookie_cosmos_watcher")
                {
                    string version = json_data.version;
                    int build = json_data.build;
                    if (build > BUILDNUM)
                    {
                        lblCheckingUpdate.Text = $"Version {version} available.\nClick here to download.";
                    }
                    else
                    {
                        lblCheckingUpdate.Text = $"No update available.";
                    }
                }

            }
        }

        private void lblCheckingUpdate_Click(object sender, EventArgs e)
        {
            if (lblCheckingUpdate.Text.Contains("download"))
            {
                Process.Start(update_data.download);
            }    
        }

        private void cbxStartWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxStartWindows.Checked)
            {
                registryKey.SetValue(PROGRAMNAME, Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue(PROGRAMNAME);
            }

            SaveSettings();
        }

        private void numProfitThreshold_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rec_threshold = numProfitThreshold.Value;
            SaveSettings();
        }

        private void numInflatorThreshold_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rec_inflator = numInflatorThreshold.Value;
            SaveSettings();
        }

        private void cmbxPrioritize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.rec_prioritize = cmbxPrioritize.SelectedItem.ToString();
            SaveSettings();
        }

        private void cbxEnableNotifications_CheckedChanged(object sender, EventArgs e)
        {
            lblFlashTaskbar.Enabled = cbxEnableNotifications.Checked ? true : false;
            lblAudible.Enabled = cbxEnableNotifications.Checked ? true : false;
            lblFocus.Enabled = cbxEnableNotifications.Checked ? true : false;
            cbxFlashTaskbar.Enabled = cbxEnableNotifications.Checked ? true : false;
            cbxAudible.Enabled = cbxEnableNotifications.Checked ? true : false;
            cbxFocus.Enabled = cbxEnableNotifications.Checked ? true : false;

            Properties.Settings.Default.notification = cbxEnableNotifications.Checked ? true : false;
            SaveSettings();
        }

        private void cbxFlashTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.noti_flash = cbxFlashTaskbar.Checked ? true : false;
            SaveSettings();
        }

        private void cbxAudible_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.noti_tone = cbxAudible.Checked ? true : false;
            SaveSettings();
        }

        private void cbxFocus_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.noti_focus = cbxFocus.Checked ? true : false;
            SaveSettings();
        }

        private void cbxKeepTop_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = cbxKeepTop.Checked ? true : false;
            Properties.Settings.Default.top_most = cbxKeepTop.Checked ? true : false;
            SaveSettings();
        }

        private void dataItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataItems.HitTest(e.X, e.Y).RowIndex;

                //dataItems.ClearSelection();

                if (currentMouseOverRow >= 0)
                {
                    dataItems.Rows[currentMouseOverRow].Selected = true;
                    string type = dataItems.Rows[currentMouseOverRow].Cells[1].Value.ToString();

                    if (type == "Consumable")
                    {
                        cm_consumable.Show(dataItems, new Point(e.X, e.Y));
                    }
                    else if (type == "Craftable")
                    {
                        cm_craftable.Show(dataItems, new Point(e.X, e.Y));
                    }
                }
            }
        }

        // Right click menu item
        private void cm_buy_do(object sender, System.EventArgs e)
        {
            DoContextMenuTask(0);
        }

        // Right click menu item
        private void cm_sell_do(object sender, System.EventArgs e)
        {
            DoContextMenuTask(1);
        }

        // Right click menu item
        private void cm_use_do(object sender, System.EventArgs e)
        {
            DoContextMenuTask(2);
        }

        private void DoContextMenuTask(int type)
        {
            // Gets the selected column
            int selectedrowindex = dataItems.SelectedCells[0].RowIndex;
            if (selectedrowindex != -1)
            {
                // Gets the selected row
                DataGridViewRow selectedRow = dataItems.Rows[selectedrowindex];
                // Gets the venuekey as a string from the selected row and column
                string item_name = Convert.ToString(selectedRow.Cells["ID"].Value);

                EconomyItem item = current_data.items.Find(x => x.name == item_name);
                if (item != null)
                {
                    switch (type)
                    {
                        case 0:
                            Clipboard.SetText("+shop buy " + item.name);
                            break;
                        case 1:
                            Clipboard.SetText("+shop sell " + item.name);
                            break;
                        case 2:
                            Clipboard.SetText("+item use " + item.name);
                            break;
                    }
                }
            }
        }
    }
}
