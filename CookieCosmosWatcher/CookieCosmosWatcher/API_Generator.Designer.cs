namespace CookieCosmosWatcher
{
    partial class API_Generator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(API_Generator));
            this.lblOverview = new System.Windows.Forms.Label();
            this.lblSelectDataset = new System.Windows.Forms.Label();
            this.tbxApiUrl = new System.Windows.Forms.TextBox();
            this.lblApiUrl = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKeyInfo = new System.Windows.Forms.Label();
            this.lblApiUrlInfo = new System.Windows.Forms.Label();
            this.lblCopied = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cbxDataItems = new System.Windows.Forms.CheckBox();
            this.cbxDataCookies = new System.Windows.Forms.CheckBox();
            this.cbxDataAchievements = new System.Windows.Forms.CheckBox();
            this.cbxDataTitles = new System.Windows.Forms.CheckBox();
            this.cbxDataRelics = new System.Windows.Forms.CheckBox();
            this.cbxPlayerStats = new System.Windows.Forms.CheckBox();
            this.cbxPlayerServers = new System.Windows.Forms.CheckBox();
            this.cbxPlayerAchievements = new System.Windows.Forms.CheckBox();
            this.cbxPlayerTitles = new System.Windows.Forms.CheckBox();
            this.cbxPlayerRelics = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsPermanents = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsConsumables = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsCraftables = new System.Windows.Forms.CheckBox();
            this.cbxPlayerCookies = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblOverview
            // 
            this.lblOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverview.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.ForeColor = System.Drawing.Color.Silver;
            this.lblOverview.Location = new System.Drawing.Point(12, 9);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(591, 86);
            this.lblOverview.TabIndex = 54;
            this.lblOverview.Text = resources.GetString("lblOverview.Text");
            // 
            // lblSelectDataset
            // 
            this.lblSelectDataset.AutoSize = true;
            this.lblSelectDataset.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelectDataset.Location = new System.Drawing.Point(12, 95);
            this.lblSelectDataset.Name = "lblSelectDataset";
            this.lblSelectDataset.Size = new System.Drawing.Size(106, 17);
            this.lblSelectDataset.TabIndex = 59;
            this.lblSelectDataset.Text = "Select Datasets";
            // 
            // tbxApiUrl
            // 
            this.tbxApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxApiUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tbxApiUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxApiUrl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxApiUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbxApiUrl.Location = new System.Drawing.Point(29, 537);
            this.tbxApiUrl.Name = "tbxApiUrl";
            this.tbxApiUrl.ReadOnly = true;
            this.tbxApiUrl.Size = new System.Drawing.Size(553, 21);
            this.tbxApiUrl.TabIndex = 60;
            this.tbxApiUrl.Text = "https://api.cookiecosmosbot.com/v1.2/";
            this.tbxApiUrl.Click += new System.EventHandler(this.tbxApiUrl_Click);
            // 
            // lblApiUrl
            // 
            this.lblApiUrl.AutoSize = true;
            this.lblApiUrl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblApiUrl.Location = new System.Drawing.Point(12, 490);
            this.lblApiUrl.Name = "lblApiUrl";
            this.lblApiUrl.Size = new System.Drawing.Size(47, 17);
            this.lblApiUrl.TabIndex = 61;
            this.lblApiUrl.Text = "API Url";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblApiKey.Location = new System.Drawing.Point(12, 388);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(54, 17);
            this.lblApiKey.TabIndex = 63;
            this.lblApiKey.Text = "API Key";
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tbxApiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxApiKey.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxApiKey.ForeColor = System.Drawing.Color.Silver;
            this.tbxApiKey.Location = new System.Drawing.Point(29, 433);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.Size = new System.Drawing.Size(553, 21);
            this.tbxApiKey.TabIndex = 62;
            this.tbxApiKey.TextChanged += new System.EventHandler(this.tbxApiKey_TextChanged);
            // 
            // lblApiKeyInfo
            // 
            this.lblApiKeyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApiKeyInfo.AutoSize = true;
            this.lblApiKeyInfo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiKeyInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblApiKeyInfo.Location = new System.Drawing.Point(26, 413);
            this.lblApiKeyInfo.Name = "lblApiKeyInfo";
            this.lblApiKeyInfo.Size = new System.Drawing.Size(485, 17);
            this.lblApiKeyInfo.TabIndex = 64;
            this.lblApiKeyInfo.Text = "Insert your API Key here. You can leave it blank and fill it in the URL manually " +
    "later.";
            // 
            // lblApiUrlInfo
            // 
            this.lblApiUrlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApiUrlInfo.AutoSize = true;
            this.lblApiUrlInfo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiUrlInfo.ForeColor = System.Drawing.Color.Silver;
            this.lblApiUrlInfo.Location = new System.Drawing.Point(26, 517);
            this.lblApiUrlInfo.Name = "lblApiUrlInfo";
            this.lblApiUrlInfo.Size = new System.Drawing.Size(292, 17);
            this.lblApiUrlInfo.TabIndex = 65;
            this.lblApiUrlInfo.Text = "This is your output Url. Click or select it to copy it.";
            // 
            // lblCopied
            // 
            this.lblCopied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblCopied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCopied.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopied.ForeColor = System.Drawing.Color.Black;
            this.lblCopied.Location = new System.Drawing.Point(400, 527);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Padding = new System.Windows.Forms.Padding(10);
            this.lblCopied.Size = new System.Drawing.Size(182, 38);
            this.lblCopied.TabIndex = 66;
            this.lblCopied.Text = "Link Copied to Clipboard";
            this.lblCopied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopied.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 800;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cbxDataItems
            // 
            this.cbxDataItems.AutoSize = true;
            this.cbxDataItems.Location = new System.Drawing.Point(318, 154);
            this.cbxDataItems.Name = "cbxDataItems";
            this.cbxDataItems.Size = new System.Drawing.Size(134, 21);
            this.cbxDataItems.TabIndex = 73;
            this.cbxDataItems.Tag = "1024";
            this.cbxDataItems.Text = "economy - items";
            this.cbxDataItems.UseVisualStyleBackColor = true;
            this.cbxDataItems.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataCookies
            // 
            this.cbxDataCookies.AutoSize = true;
            this.cbxDataCookies.Location = new System.Drawing.Point(318, 127);
            this.cbxDataCookies.Name = "cbxDataCookies";
            this.cbxDataCookies.Size = new System.Drawing.Size(149, 21);
            this.cbxDataCookies.TabIndex = 72;
            this.cbxDataCookies.Tag = "512";
            this.cbxDataCookies.Text = "economy - cookies";
            this.cbxDataCookies.UseVisualStyleBackColor = true;
            this.cbxDataCookies.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataAchievements
            // 
            this.cbxDataAchievements.AutoSize = true;
            this.cbxDataAchievements.Enabled = false;
            this.cbxDataAchievements.Location = new System.Drawing.Point(318, 235);
            this.cbxDataAchievements.Name = "cbxDataAchievements";
            this.cbxDataAchievements.Size = new System.Drawing.Size(289, 21);
            this.cbxDataAchievements.TabIndex = 71;
            this.cbxDataAchievements.Tag = "8192";
            this.cbxDataAchievements.Text = "economy - achievements (coming soon)";
            this.cbxDataAchievements.UseVisualStyleBackColor = true;
            this.cbxDataAchievements.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataTitles
            // 
            this.cbxDataTitles.AutoSize = true;
            this.cbxDataTitles.Enabled = false;
            this.cbxDataTitles.Location = new System.Drawing.Point(318, 208);
            this.cbxDataTitles.Name = "cbxDataTitles";
            this.cbxDataTitles.Size = new System.Drawing.Size(227, 21);
            this.cbxDataTitles.TabIndex = 70;
            this.cbxDataTitles.Tag = "4096";
            this.cbxDataTitles.Text = "economy - titles (coming soon)";
            this.cbxDataTitles.UseVisualStyleBackColor = true;
            this.cbxDataTitles.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataRelics
            // 
            this.cbxDataRelics.AutoSize = true;
            this.cbxDataRelics.Location = new System.Drawing.Point(318, 181);
            this.cbxDataRelics.Name = "cbxDataRelics";
            this.cbxDataRelics.Size = new System.Drawing.Size(131, 21);
            this.cbxDataRelics.TabIndex = 68;
            this.cbxDataRelics.Tag = "2048";
            this.cbxDataRelics.Text = "economy - relics";
            this.cbxDataRelics.UseVisualStyleBackColor = true;
            this.cbxDataRelics.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerStats
            // 
            this.cbxPlayerStats.AutoSize = true;
            this.cbxPlayerStats.Enabled = false;
            this.cbxPlayerStats.Location = new System.Drawing.Point(26, 343);
            this.cbxPlayerStats.Name = "cbxPlayerStats";
            this.cbxPlayerStats.Size = new System.Drawing.Size(205, 21);
            this.cbxPlayerStats.TabIndex = 82;
            this.cbxPlayerStats.Tag = "256";
            this.cbxPlayerStats.Text = "player - stats (coming soon)";
            this.cbxPlayerStats.UseVisualStyleBackColor = true;
            this.cbxPlayerStats.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerServers
            // 
            this.cbxPlayerServers.AutoSize = true;
            this.cbxPlayerServers.Enabled = false;
            this.cbxPlayerServers.Location = new System.Drawing.Point(26, 127);
            this.cbxPlayerServers.Name = "cbxPlayerServers";
            this.cbxPlayerServers.Size = new System.Drawing.Size(115, 21);
            this.cbxPlayerServers.TabIndex = 81;
            this.cbxPlayerServers.Tag = "1";
            this.cbxPlayerServers.Text = "player - server";
            this.cbxPlayerServers.UseVisualStyleBackColor = true;
            this.cbxPlayerServers.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerAchievements
            // 
            this.cbxPlayerAchievements.AutoSize = true;
            this.cbxPlayerAchievements.Location = new System.Drawing.Point(26, 316);
            this.cbxPlayerAchievements.Name = "cbxPlayerAchievements";
            this.cbxPlayerAchievements.Size = new System.Drawing.Size(169, 21);
            this.cbxPlayerAchievements.TabIndex = 80;
            this.cbxPlayerAchievements.Tag = "128";
            this.cbxPlayerAchievements.Text = "player - achievements";
            this.cbxPlayerAchievements.UseVisualStyleBackColor = true;
            this.cbxPlayerAchievements.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerTitles
            // 
            this.cbxPlayerTitles.AutoSize = true;
            this.cbxPlayerTitles.Location = new System.Drawing.Point(26, 289);
            this.cbxPlayerTitles.Name = "cbxPlayerTitles";
            this.cbxPlayerTitles.Size = new System.Drawing.Size(107, 21);
            this.cbxPlayerTitles.TabIndex = 79;
            this.cbxPlayerTitles.Tag = "64";
            this.cbxPlayerTitles.Text = "player - titles";
            this.cbxPlayerTitles.UseVisualStyleBackColor = true;
            this.cbxPlayerTitles.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerRelics
            // 
            this.cbxPlayerRelics.AutoSize = true;
            this.cbxPlayerRelics.Location = new System.Drawing.Point(26, 262);
            this.cbxPlayerRelics.Name = "cbxPlayerRelics";
            this.cbxPlayerRelics.Size = new System.Drawing.Size(109, 21);
            this.cbxPlayerRelics.TabIndex = 78;
            this.cbxPlayerRelics.Tag = "32";
            this.cbxPlayerRelics.Text = "player - relics";
            this.cbxPlayerRelics.UseVisualStyleBackColor = true;
            this.cbxPlayerRelics.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsPermanents
            // 
            this.cbxPlayerItemsPermanents.AutoSize = true;
            this.cbxPlayerItemsPermanents.Location = new System.Drawing.Point(26, 235);
            this.cbxPlayerItemsPermanents.Name = "cbxPlayerItemsPermanents";
            this.cbxPlayerItemsPermanents.Size = new System.Drawing.Size(200, 21);
            this.cbxPlayerItemsPermanents.TabIndex = 77;
            this.cbxPlayerItemsPermanents.Tag = "16";
            this.cbxPlayerItemsPermanents.Text = "player - items - Permanents";
            this.cbxPlayerItemsPermanents.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsPermanents.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsConsumables
            // 
            this.cbxPlayerItemsConsumables.AutoSize = true;
            this.cbxPlayerItemsConsumables.Location = new System.Drawing.Point(26, 208);
            this.cbxPlayerItemsConsumables.Name = "cbxPlayerItemsConsumables";
            this.cbxPlayerItemsConsumables.Size = new System.Drawing.Size(212, 21);
            this.cbxPlayerItemsConsumables.TabIndex = 76;
            this.cbxPlayerItemsConsumables.Tag = "8";
            this.cbxPlayerItemsConsumables.Text = "player - items - Consumables";
            this.cbxPlayerItemsConsumables.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsConsumables.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsCraftables
            // 
            this.cbxPlayerItemsCraftables.AutoSize = true;
            this.cbxPlayerItemsCraftables.Location = new System.Drawing.Point(26, 181);
            this.cbxPlayerItemsCraftables.Name = "cbxPlayerItemsCraftables";
            this.cbxPlayerItemsCraftables.Size = new System.Drawing.Size(191, 21);
            this.cbxPlayerItemsCraftables.TabIndex = 75;
            this.cbxPlayerItemsCraftables.Tag = "4";
            this.cbxPlayerItemsCraftables.Text = "player - items - Craftables";
            this.cbxPlayerItemsCraftables.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsCraftables.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerCookies
            // 
            this.cbxPlayerCookies.AutoSize = true;
            this.cbxPlayerCookies.Location = new System.Drawing.Point(26, 154);
            this.cbxPlayerCookies.Name = "cbxPlayerCookies";
            this.cbxPlayerCookies.Size = new System.Drawing.Size(127, 21);
            this.cbxPlayerCookies.TabIndex = 74;
            this.cbxPlayerCookies.Tag = "2";
            this.cbxPlayerCookies.Text = "player - cookies";
            this.cbxPlayerCookies.UseVisualStyleBackColor = true;
            this.cbxPlayerCookies.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // API_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(615, 593);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.cbxPlayerStats);
            this.Controls.Add(this.cbxPlayerServers);
            this.Controls.Add(this.cbxPlayerAchievements);
            this.Controls.Add(this.cbxPlayerTitles);
            this.Controls.Add(this.cbxPlayerRelics);
            this.Controls.Add(this.cbxPlayerItemsPermanents);
            this.Controls.Add(this.cbxPlayerItemsConsumables);
            this.Controls.Add(this.cbxPlayerItemsCraftables);
            this.Controls.Add(this.cbxPlayerCookies);
            this.Controls.Add(this.cbxDataItems);
            this.Controls.Add(this.cbxDataCookies);
            this.Controls.Add(this.cbxDataAchievements);
            this.Controls.Add(this.cbxDataTitles);
            this.Controls.Add(this.cbxDataRelics);
            this.Controls.Add(this.lblApiUrlInfo);
            this.Controls.Add(this.lblApiKeyInfo);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.lblApiUrl);
            this.Controls.Add(this.tbxApiUrl);
            this.Controls.Add(this.lblSelectDataset);
            this.Controls.Add(this.lblOverview);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "API_Generator";
            this.Text = "API_Generator";
            this.Load += new System.EventHandler(this.API_Generator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblSelectDataset;
        private System.Windows.Forms.TextBox tbxApiUrl;
        private System.Windows.Forms.Label lblApiUrl;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox tbxApiKey;
        private System.Windows.Forms.Label lblApiKeyInfo;
        private System.Windows.Forms.Label lblApiUrlInfo;
        private System.Windows.Forms.Label lblCopied;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbxDataItems;
        private System.Windows.Forms.CheckBox cbxDataCookies;
        private System.Windows.Forms.CheckBox cbxDataAchievements;
        private System.Windows.Forms.CheckBox cbxDataTitles;
        private System.Windows.Forms.CheckBox cbxDataRelics;
        private System.Windows.Forms.CheckBox cbxPlayerStats;
        private System.Windows.Forms.CheckBox cbxPlayerServers;
        private System.Windows.Forms.CheckBox cbxPlayerAchievements;
        private System.Windows.Forms.CheckBox cbxPlayerTitles;
        private System.Windows.Forms.CheckBox cbxPlayerRelics;
        private System.Windows.Forms.CheckBox cbxPlayerItemsPermanents;
        private System.Windows.Forms.CheckBox cbxPlayerItemsConsumables;
        private System.Windows.Forms.CheckBox cbxPlayerItemsCraftables;
        private System.Windows.Forms.CheckBox cbxPlayerCookies;
    }
}