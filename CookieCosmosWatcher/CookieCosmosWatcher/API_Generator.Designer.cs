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
            this.lblSelectApi = new System.Windows.Forms.Label();
            this.rdoPlayer = new System.Windows.Forms.RadioButton();
            this.rdoData = new System.Windows.Forms.RadioButton();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.cbxPlayerStats = new System.Windows.Forms.CheckBox();
            this.cbxPlayerServers = new System.Windows.Forms.CheckBox();
            this.cbxPlayerAchievements = new System.Windows.Forms.CheckBox();
            this.cbxPlayerTitles = new System.Windows.Forms.CheckBox();
            this.cbxPlayerRelics = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsPermanents = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsConsumables = new System.Windows.Forms.CheckBox();
            this.cbxPlayerItemsCraftables = new System.Windows.Forms.CheckBox();
            this.cbxPlayerCookies = new System.Windows.Forms.CheckBox();
            this.lblSelectDataset = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.cbxDataItems = new System.Windows.Forms.CheckBox();
            this.cbxDataCookies = new System.Windows.Forms.CheckBox();
            this.cbxDataAchievements = new System.Windows.Forms.CheckBox();
            this.cbxDataTitles = new System.Windows.Forms.CheckBox();
            this.cbxDataCrafting = new System.Windows.Forms.CheckBox();
            this.cbxDataRelics = new System.Windows.Forms.CheckBox();
            this.tbxApiUrl = new System.Windows.Forms.TextBox();
            this.lblApiUrl = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKeyInfo = new System.Windows.Forms.Label();
            this.lblApiUrlInfo = new System.Windows.Forms.Label();
            this.lblCopied = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelPlayer.SuspendLayout();
            this.panelData.SuspendLayout();
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
            this.lblOverview.Size = new System.Drawing.Size(591, 102);
            this.lblOverview.TabIndex = 54;
            this.lblOverview.Text = resources.GetString("lblOverview.Text");
            // 
            // lblSelectApi
            // 
            this.lblSelectApi.AutoSize = true;
            this.lblSelectApi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelectApi.Location = new System.Drawing.Point(12, 111);
            this.lblSelectApi.Name = "lblSelectApi";
            this.lblSelectApi.Size = new System.Drawing.Size(70, 17);
            this.lblSelectApi.TabIndex = 55;
            this.lblSelectApi.Text = "Select API";
            // 
            // rdoPlayer
            // 
            this.rdoPlayer.AutoSize = true;
            this.rdoPlayer.Checked = true;
            this.rdoPlayer.Location = new System.Drawing.Point(29, 143);
            this.rdoPlayer.Name = "rdoPlayer";
            this.rdoPlayer.Size = new System.Drawing.Size(64, 21);
            this.rdoPlayer.TabIndex = 56;
            this.rdoPlayer.TabStop = true;
            this.rdoPlayer.Text = "Player";
            this.rdoPlayer.UseVisualStyleBackColor = true;
            this.rdoPlayer.CheckedChanged += new System.EventHandler(this.rdoPlayer_CheckedChanged);
            // 
            // rdoData
            // 
            this.rdoData.AutoSize = true;
            this.rdoData.Location = new System.Drawing.Point(29, 170);
            this.rdoData.Name = "rdoData";
            this.rdoData.Size = new System.Drawing.Size(59, 21);
            this.rdoData.TabIndex = 57;
            this.rdoData.Text = "Data";
            this.rdoData.UseVisualStyleBackColor = true;
            this.rdoData.CheckedChanged += new System.EventHandler(this.rdoData_CheckedChanged);
            // 
            // panelPlayer
            // 
            this.panelPlayer.Controls.Add(this.cbxPlayerStats);
            this.panelPlayer.Controls.Add(this.cbxPlayerServers);
            this.panelPlayer.Controls.Add(this.cbxPlayerAchievements);
            this.panelPlayer.Controls.Add(this.cbxPlayerTitles);
            this.panelPlayer.Controls.Add(this.cbxPlayerRelics);
            this.panelPlayer.Controls.Add(this.cbxPlayerItemsPermanents);
            this.panelPlayer.Controls.Add(this.cbxPlayerItemsConsumables);
            this.panelPlayer.Controls.Add(this.cbxPlayerItemsCraftables);
            this.panelPlayer.Controls.Add(this.cbxPlayerCookies);
            this.panelPlayer.Location = new System.Drawing.Point(186, 143);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(243, 280);
            this.panelPlayer.TabIndex = 58;
            // 
            // cbxPlayerStats
            // 
            this.cbxPlayerStats.AutoSize = true;
            this.cbxPlayerStats.Enabled = false;
            this.cbxPlayerStats.Location = new System.Drawing.Point(17, 217);
            this.cbxPlayerStats.Name = "cbxPlayerStats";
            this.cbxPlayerStats.Size = new System.Drawing.Size(154, 21);
            this.cbxPlayerStats.TabIndex = 8;
            this.cbxPlayerStats.Tag = "256";
            this.cbxPlayerStats.Text = "stats (coming soon)";
            this.cbxPlayerStats.UseVisualStyleBackColor = true;
            this.cbxPlayerStats.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerServers
            // 
            this.cbxPlayerServers.AutoSize = true;
            this.cbxPlayerServers.Checked = true;
            this.cbxPlayerServers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPlayerServers.Enabled = false;
            this.cbxPlayerServers.Location = new System.Drawing.Point(17, 1);
            this.cbxPlayerServers.Name = "cbxPlayerServers";
            this.cbxPlayerServers.Size = new System.Drawing.Size(180, 21);
            this.cbxPlayerServers.TabIndex = 7;
            this.cbxPlayerServers.Tag = "1";
            this.cbxPlayerServers.Text = "servers and general info";
            this.cbxPlayerServers.UseVisualStyleBackColor = true;
            // 
            // cbxPlayerAchievements
            // 
            this.cbxPlayerAchievements.AutoSize = true;
            this.cbxPlayerAchievements.Location = new System.Drawing.Point(17, 190);
            this.cbxPlayerAchievements.Name = "cbxPlayerAchievements";
            this.cbxPlayerAchievements.Size = new System.Drawing.Size(118, 21);
            this.cbxPlayerAchievements.TabIndex = 6;
            this.cbxPlayerAchievements.Tag = "128";
            this.cbxPlayerAchievements.Text = "achievements";
            this.cbxPlayerAchievements.UseVisualStyleBackColor = true;
            this.cbxPlayerAchievements.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerTitles
            // 
            this.cbxPlayerTitles.AutoSize = true;
            this.cbxPlayerTitles.Location = new System.Drawing.Point(17, 163);
            this.cbxPlayerTitles.Name = "cbxPlayerTitles";
            this.cbxPlayerTitles.Size = new System.Drawing.Size(56, 21);
            this.cbxPlayerTitles.TabIndex = 5;
            this.cbxPlayerTitles.Tag = "64";
            this.cbxPlayerTitles.Text = "titles";
            this.cbxPlayerTitles.UseVisualStyleBackColor = true;
            this.cbxPlayerTitles.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerRelics
            // 
            this.cbxPlayerRelics.AutoSize = true;
            this.cbxPlayerRelics.Location = new System.Drawing.Point(17, 136);
            this.cbxPlayerRelics.Name = "cbxPlayerRelics";
            this.cbxPlayerRelics.Size = new System.Drawing.Size(58, 21);
            this.cbxPlayerRelics.TabIndex = 4;
            this.cbxPlayerRelics.Tag = "32";
            this.cbxPlayerRelics.Text = "relics";
            this.cbxPlayerRelics.UseVisualStyleBackColor = true;
            this.cbxPlayerRelics.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsPermanents
            // 
            this.cbxPlayerItemsPermanents.AutoSize = true;
            this.cbxPlayerItemsPermanents.Location = new System.Drawing.Point(17, 109);
            this.cbxPlayerItemsPermanents.Name = "cbxPlayerItemsPermanents";
            this.cbxPlayerItemsPermanents.Size = new System.Drawing.Size(149, 21);
            this.cbxPlayerItemsPermanents.TabIndex = 3;
            this.cbxPlayerItemsPermanents.Tag = "16";
            this.cbxPlayerItemsPermanents.Text = "items - Permanents";
            this.cbxPlayerItemsPermanents.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsPermanents.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsConsumables
            // 
            this.cbxPlayerItemsConsumables.AutoSize = true;
            this.cbxPlayerItemsConsumables.Location = new System.Drawing.Point(17, 82);
            this.cbxPlayerItemsConsumables.Name = "cbxPlayerItemsConsumables";
            this.cbxPlayerItemsConsumables.Size = new System.Drawing.Size(161, 21);
            this.cbxPlayerItemsConsumables.TabIndex = 2;
            this.cbxPlayerItemsConsumables.Tag = "8";
            this.cbxPlayerItemsConsumables.Text = "items - Consumables";
            this.cbxPlayerItemsConsumables.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsConsumables.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerItemsCraftables
            // 
            this.cbxPlayerItemsCraftables.AutoSize = true;
            this.cbxPlayerItemsCraftables.Location = new System.Drawing.Point(17, 55);
            this.cbxPlayerItemsCraftables.Name = "cbxPlayerItemsCraftables";
            this.cbxPlayerItemsCraftables.Size = new System.Drawing.Size(140, 21);
            this.cbxPlayerItemsCraftables.TabIndex = 1;
            this.cbxPlayerItemsCraftables.Tag = "4";
            this.cbxPlayerItemsCraftables.Text = "items - Craftables";
            this.cbxPlayerItemsCraftables.UseVisualStyleBackColor = true;
            this.cbxPlayerItemsCraftables.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxPlayerCookies
            // 
            this.cbxPlayerCookies.AutoSize = true;
            this.cbxPlayerCookies.Location = new System.Drawing.Point(17, 28);
            this.cbxPlayerCookies.Name = "cbxPlayerCookies";
            this.cbxPlayerCookies.Size = new System.Drawing.Size(76, 21);
            this.cbxPlayerCookies.TabIndex = 0;
            this.cbxPlayerCookies.Tag = "2";
            this.cbxPlayerCookies.Text = "cookies";
            this.cbxPlayerCookies.UseVisualStyleBackColor = true;
            this.cbxPlayerCookies.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // lblSelectDataset
            // 
            this.lblSelectDataset.AutoSize = true;
            this.lblSelectDataset.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelectDataset.Location = new System.Drawing.Point(183, 111);
            this.lblSelectDataset.Name = "lblSelectDataset";
            this.lblSelectDataset.Size = new System.Drawing.Size(106, 17);
            this.lblSelectDataset.TabIndex = 59;
            this.lblSelectDataset.Text = "Select Datasets";
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.cbxDataItems);
            this.panelData.Controls.Add(this.cbxDataCookies);
            this.panelData.Controls.Add(this.cbxDataAchievements);
            this.panelData.Controls.Add(this.cbxDataTitles);
            this.panelData.Controls.Add(this.cbxDataCrafting);
            this.panelData.Controls.Add(this.cbxDataRelics);
            this.panelData.Location = new System.Drawing.Point(186, 143);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(243, 280);
            this.panelData.TabIndex = 59;
            this.panelData.Visible = false;
            // 
            // cbxDataItems
            // 
            this.cbxDataItems.AutoSize = true;
            this.cbxDataItems.Location = new System.Drawing.Point(17, 28);
            this.cbxDataItems.Name = "cbxDataItems";
            this.cbxDataItems.Size = new System.Drawing.Size(61, 21);
            this.cbxDataItems.TabIndex = 8;
            this.cbxDataItems.Tag = "2";
            this.cbxDataItems.Text = "items";
            this.cbxDataItems.UseVisualStyleBackColor = true;
            this.cbxDataItems.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataCookies
            // 
            this.cbxDataCookies.AutoSize = true;
            this.cbxDataCookies.Location = new System.Drawing.Point(17, 1);
            this.cbxDataCookies.Name = "cbxDataCookies";
            this.cbxDataCookies.Size = new System.Drawing.Size(76, 21);
            this.cbxDataCookies.TabIndex = 7;
            this.cbxDataCookies.Tag = "1";
            this.cbxDataCookies.Text = "cookies";
            this.cbxDataCookies.UseVisualStyleBackColor = true;
            this.cbxDataCookies.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataAchievements
            // 
            this.cbxDataAchievements.AutoSize = true;
            this.cbxDataAchievements.Location = new System.Drawing.Point(17, 136);
            this.cbxDataAchievements.Name = "cbxDataAchievements";
            this.cbxDataAchievements.Size = new System.Drawing.Size(118, 21);
            this.cbxDataAchievements.TabIndex = 3;
            this.cbxDataAchievements.Tag = "32";
            this.cbxDataAchievements.Text = "achievements";
            this.cbxDataAchievements.UseVisualStyleBackColor = true;
            this.cbxDataAchievements.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataTitles
            // 
            this.cbxDataTitles.AutoSize = true;
            this.cbxDataTitles.Location = new System.Drawing.Point(17, 109);
            this.cbxDataTitles.Name = "cbxDataTitles";
            this.cbxDataTitles.Size = new System.Drawing.Size(56, 21);
            this.cbxDataTitles.TabIndex = 2;
            this.cbxDataTitles.Tag = "16";
            this.cbxDataTitles.Text = "titles";
            this.cbxDataTitles.UseVisualStyleBackColor = true;
            this.cbxDataTitles.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataCrafting
            // 
            this.cbxDataCrafting.AutoSize = true;
            this.cbxDataCrafting.Location = new System.Drawing.Point(17, 82);
            this.cbxDataCrafting.Name = "cbxDataCrafting";
            this.cbxDataCrafting.Size = new System.Drawing.Size(77, 21);
            this.cbxDataCrafting.TabIndex = 1;
            this.cbxDataCrafting.Tag = "8";
            this.cbxDataCrafting.Text = "crafting";
            this.cbxDataCrafting.UseVisualStyleBackColor = true;
            this.cbxDataCrafting.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // cbxDataRelics
            // 
            this.cbxDataRelics.AutoSize = true;
            this.cbxDataRelics.Location = new System.Drawing.Point(17, 55);
            this.cbxDataRelics.Name = "cbxDataRelics";
            this.cbxDataRelics.Size = new System.Drawing.Size(58, 21);
            this.cbxDataRelics.TabIndex = 0;
            this.cbxDataRelics.Tag = "4";
            this.cbxDataRelics.Text = "relics";
            this.cbxDataRelics.UseVisualStyleBackColor = true;
            this.cbxDataRelics.CheckedChanged += new System.EventHandler(this.CalculateDataset);
            // 
            // tbxApiUrl
            // 
            this.tbxApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxApiUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.tbxApiUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxApiUrl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxApiUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tbxApiUrl.Location = new System.Drawing.Point(29, 587);
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
            this.lblApiUrl.Location = new System.Drawing.Point(12, 540);
            this.lblApiUrl.Name = "lblApiUrl";
            this.lblApiUrl.Size = new System.Drawing.Size(47, 17);
            this.lblApiUrl.TabIndex = 61;
            this.lblApiUrl.Text = "API Url";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblApiKey.Location = new System.Drawing.Point(12, 438);
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
            this.tbxApiKey.Location = new System.Drawing.Point(29, 483);
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
            this.lblApiKeyInfo.Location = new System.Drawing.Point(26, 463);
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
            this.lblApiUrlInfo.Location = new System.Drawing.Point(26, 567);
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
            this.lblCopied.Location = new System.Drawing.Point(400, 577);
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
            // API_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(615, 636);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.lblApiUrlInfo);
            this.Controls.Add(this.lblApiKeyInfo);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.lblApiUrl);
            this.Controls.Add(this.tbxApiUrl);
            this.Controls.Add(this.lblSelectDataset);
            this.Controls.Add(this.rdoData);
            this.Controls.Add(this.rdoPlayer);
            this.Controls.Add(this.lblSelectApi);
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelPlayer);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "API_Generator";
            this.Text = "API_Generator";
            this.Load += new System.EventHandler(this.API_Generator_Load);
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblSelectApi;
        private System.Windows.Forms.RadioButton rdoPlayer;
        private System.Windows.Forms.RadioButton rdoData;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.CheckBox cbxPlayerStats;
        private System.Windows.Forms.CheckBox cbxPlayerServers;
        private System.Windows.Forms.CheckBox cbxPlayerAchievements;
        private System.Windows.Forms.CheckBox cbxPlayerTitles;
        private System.Windows.Forms.CheckBox cbxPlayerRelics;
        private System.Windows.Forms.CheckBox cbxPlayerItemsPermanents;
        private System.Windows.Forms.CheckBox cbxPlayerItemsConsumables;
        private System.Windows.Forms.CheckBox cbxPlayerItemsCraftables;
        private System.Windows.Forms.CheckBox cbxPlayerCookies;
        private System.Windows.Forms.Label lblSelectDataset;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.CheckBox cbxDataCookies;
        private System.Windows.Forms.CheckBox cbxDataAchievements;
        private System.Windows.Forms.CheckBox cbxDataTitles;
        private System.Windows.Forms.CheckBox cbxDataCrafting;
        private System.Windows.Forms.CheckBox cbxDataRelics;
        private System.Windows.Forms.TextBox tbxApiUrl;
        private System.Windows.Forms.Label lblApiUrl;
        private System.Windows.Forms.CheckBox cbxDataItems;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox tbxApiKey;
        private System.Windows.Forms.Label lblApiKeyInfo;
        private System.Windows.Forms.Label lblApiUrlInfo;
        private System.Windows.Forms.Label lblCopied;
        private System.Windows.Forms.Timer timer;
    }
}