namespace MQOBot
{
    partial class Form1
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboFight = new System.Windows.Forms.ComboBox();
            this.btnStopFight = new System.Windows.Forms.Button();
            this.btnStartFight = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatPoints = new System.Windows.Forms.Label();
            this.lblWorkload = new System.Windows.Forms.Label();
            this.lblRelics = new System.Windows.Forms.Label();
            this.lblChests = new System.Windows.Forms.Label();
            this.lblElements = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.ProgressHP = new System.Windows.Forms.ProgressBar();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblSkill2 = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.ProgressSkill2 = new System.Windows.Forms.ProgressBar();
            this.lblSkill1 = new System.Windows.Forms.Label();
            this.ProgressMana = new System.Windows.Forms.ProgressBar();
            this.ProgressSkill1 = new System.Windows.Forms.ProgressBar();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblMana = new System.Windows.Forms.Label();
            this.ProgressLevel = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboSkill = new System.Windows.Forms.ComboBox();
            this.btnStopSkill = new System.Windows.Forms.Button();
            this.btnStartSkill = new System.Windows.Forms.Button();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtChatToSend = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(180, 531);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(493, 111);
            this.txtLog.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnSendChat);
            this.panel1.Controls.Add(this.txtChatToSend);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 513);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboFight);
            this.groupBox3.Controls.Add(this.btnStopFight);
            this.groupBox3.Controls.Add(this.btnStartFight);
            this.groupBox3.Location = new System.Drawing.Point(331, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 100);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fighting";
            // 
            // comboFight
            // 
            this.comboFight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFight.FormattingEnabled = true;
            this.comboFight.Location = new System.Drawing.Point(168, 19);
            this.comboFight.MaxDropDownItems = 20;
            this.comboFight.Name = "comboFight";
            this.comboFight.Size = new System.Drawing.Size(121, 21);
            this.comboFight.TabIndex = 2;
            this.comboFight.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // btnStopFight
            // 
            this.btnStopFight.Location = new System.Drawing.Point(87, 19);
            this.btnStopFight.Name = "btnStopFight";
            this.btnStopFight.Size = new System.Drawing.Size(75, 23);
            this.btnStopFight.TabIndex = 1;
            this.btnStopFight.Text = "Stop";
            this.btnStopFight.UseVisualStyleBackColor = true;
            this.btnStopFight.Click += new System.EventHandler(this.btnStopFight_Click);
            // 
            // btnStartFight
            // 
            this.btnStartFight.Enabled = false;
            this.btnStartFight.Location = new System.Drawing.Point(6, 19);
            this.btnStartFight.Name = "btnStartFight";
            this.btnStartFight.Size = new System.Drawing.Size(75, 23);
            this.btnStartFight.TabIndex = 0;
            this.btnStartFight.Text = "Start";
            this.btnStartFight.UseVisualStyleBackColor = true;
            this.btnStartFight.Click += new System.EventHandler(this.btnStartFight_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatPoints);
            this.groupBox2.Controls.Add(this.lblWorkload);
            this.groupBox2.Controls.Add(this.lblRelics);
            this.groupBox2.Controls.Add(this.lblChests);
            this.groupBox2.Controls.Add(this.lblElements);
            this.groupBox2.Controls.Add(this.lblGold);
            this.groupBox2.Controls.Add(this.ProgressHP);
            this.groupBox2.Controls.Add(this.lblHP);
            this.groupBox2.Controls.Add(this.lblSkill2);
            this.groupBox2.Controls.Add(this.lblPlayerName);
            this.groupBox2.Controls.Add(this.ProgressSkill2);
            this.groupBox2.Controls.Add(this.lblSkill1);
            this.groupBox2.Controls.Add(this.ProgressMana);
            this.groupBox2.Controls.Add(this.ProgressSkill1);
            this.groupBox2.Controls.Add(this.lblLevel);
            this.groupBox2.Controls.Add(this.lblMana);
            this.groupBox2.Controls.Add(this.ProgressLevel);
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 503);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stats";
            // 
            // lblStatPoints
            // 
            this.lblStatPoints.AutoSize = true;
            this.lblStatPoints.Location = new System.Drawing.Point(9, 333);
            this.lblStatPoints.Name = "lblStatPoints";
            this.lblStatPoints.Size = new System.Drawing.Size(58, 13);
            this.lblStatPoints.TabIndex = 24;
            this.lblStatPoints.Text = "Stat Points";
            // 
            // lblWorkload
            // 
            this.lblWorkload.AutoSize = true;
            this.lblWorkload.Location = new System.Drawing.Point(9, 362);
            this.lblWorkload.Name = "lblWorkload";
            this.lblWorkload.Size = new System.Drawing.Size(53, 13);
            this.lblWorkload.TabIndex = 23;
            this.lblWorkload.Text = "Workload";
            // 
            // lblRelics
            // 
            this.lblRelics.AutoSize = true;
            this.lblRelics.Location = new System.Drawing.Point(9, 307);
            this.lblRelics.Name = "lblRelics";
            this.lblRelics.Size = new System.Drawing.Size(36, 13);
            this.lblRelics.TabIndex = 22;
            this.lblRelics.Text = "Relics";
            // 
            // lblChests
            // 
            this.lblChests.AutoSize = true;
            this.lblChests.Location = new System.Drawing.Point(9, 281);
            this.lblChests.Name = "lblChests";
            this.lblChests.Size = new System.Drawing.Size(39, 13);
            this.lblChests.TabIndex = 21;
            this.lblChests.Text = "Chests";
            // 
            // lblElements
            // 
            this.lblElements.AutoSize = true;
            this.lblElements.Location = new System.Drawing.Point(9, 256);
            this.lblElements.Name = "lblElements";
            this.lblElements.Size = new System.Drawing.Size(50, 13);
            this.lblElements.TabIndex = 20;
            this.lblElements.Text = "Elements";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(9, 233);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(29, 13);
            this.lblGold.TabIndex = 19;
            this.lblGold.Text = "Gold";
            // 
            // ProgressHP
            // 
            this.ProgressHP.Location = new System.Drawing.Point(6, 54);
            this.ProgressHP.Name = "ProgressHP";
            this.ProgressHP.Size = new System.Drawing.Size(91, 23);
            this.ProgressHP.TabIndex = 6;
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(7, 38);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(22, 13);
            this.lblHP.TabIndex = 8;
            this.lblHP.Text = "HP";
            // 
            // lblSkill2
            // 
            this.lblSkill2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkill2.AutoSize = true;
            this.lblSkill2.Location = new System.Drawing.Point(9, 173);
            this.lblSkill2.Name = "lblSkill2";
            this.lblSkill2.Size = new System.Drawing.Size(33, 13);
            this.lblSkill2.TabIndex = 17;
            this.lblSkill2.Text = "Level";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(6, 16);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(67, 13);
            this.lblPlayerName.TabIndex = 5;
            this.lblPlayerName.Text = "Player Name";
            // 
            // ProgressSkill2
            // 
            this.ProgressSkill2.Location = new System.Drawing.Point(6, 189);
            this.ProgressSkill2.Name = "ProgressSkill2";
            this.ProgressSkill2.Size = new System.Drawing.Size(195, 23);
            this.ProgressSkill2.TabIndex = 16;
            // 
            // lblSkill1
            // 
            this.lblSkill1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkill1.AutoSize = true;
            this.lblSkill1.Location = new System.Drawing.Point(9, 131);
            this.lblSkill1.Name = "lblSkill1";
            this.lblSkill1.Size = new System.Drawing.Size(33, 13);
            this.lblSkill1.TabIndex = 15;
            this.lblSkill1.Text = "Level";
            // 
            // ProgressMana
            // 
            this.ProgressMana.Location = new System.Drawing.Point(113, 54);
            this.ProgressMana.Name = "ProgressMana";
            this.ProgressMana.Size = new System.Drawing.Size(88, 23);
            this.ProgressMana.TabIndex = 7;
            // 
            // ProgressSkill1
            // 
            this.ProgressSkill1.Location = new System.Drawing.Point(6, 147);
            this.ProgressSkill1.Name = "ProgressSkill1";
            this.ProgressSkill1.Size = new System.Drawing.Size(195, 23);
            this.ProgressSkill1.TabIndex = 14;
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(9, 88);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 13;
            this.lblLevel.Text = "Level";
            // 
            // lblMana
            // 
            this.lblMana.AutoSize = true;
            this.lblMana.Location = new System.Drawing.Point(114, 38);
            this.lblMana.Name = "lblMana";
            this.lblMana.Size = new System.Drawing.Size(34, 13);
            this.lblMana.TabIndex = 9;
            this.lblMana.Text = "Mana";
            // 
            // ProgressLevel
            // 
            this.ProgressLevel.Location = new System.Drawing.Point(6, 104);
            this.ProgressLevel.Name = "ProgressLevel";
            this.ProgressLevel.Size = new System.Drawing.Size(195, 23);
            this.ProgressLevel.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboSkill);
            this.groupBox1.Controls.Add(this.btnStopSkill);
            this.groupBox1.Controls.Add(this.btnStartSkill);
            this.groupBox1.Location = new System.Drawing.Point(331, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 121);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skilling";
            // 
            // comboSkill
            // 
            this.comboSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSkill.FormattingEnabled = true;
            this.comboSkill.Location = new System.Drawing.Point(168, 19);
            this.comboSkill.MaxDropDownItems = 20;
            this.comboSkill.Name = "comboSkill";
            this.comboSkill.Size = new System.Drawing.Size(121, 21);
            this.comboSkill.TabIndex = 5;
            this.comboSkill.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // btnStopSkill
            // 
            this.btnStopSkill.Location = new System.Drawing.Point(87, 19);
            this.btnStopSkill.Name = "btnStopSkill";
            this.btnStopSkill.Size = new System.Drawing.Size(75, 23);
            this.btnStopSkill.TabIndex = 4;
            this.btnStopSkill.Text = "Stop";
            this.btnStopSkill.UseVisualStyleBackColor = true;
            this.btnStopSkill.Click += new System.EventHandler(this.btnStopSkill_Click);
            // 
            // btnStartSkill
            // 
            this.btnStartSkill.Enabled = false;
            this.btnStartSkill.Location = new System.Drawing.Point(6, 19);
            this.btnStartSkill.Name = "btnStartSkill";
            this.btnStartSkill.Size = new System.Drawing.Size(75, 23);
            this.btnStartSkill.TabIndex = 3;
            this.btnStartSkill.Text = "Start";
            this.btnStartSkill.UseVisualStyleBackColor = true;
            this.btnStartSkill.Click += new System.EventHandler(this.btnStartSkill_Click);
            // 
            // btnSendChat
            // 
            this.btnSendChat.Location = new System.Drawing.Point(561, 488);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(100, 23);
            this.btnSendChat.TabIndex = 4;
            this.btnSendChat.Text = "Send";
            this.btnSendChat.UseVisualStyleBackColor = true;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // txtChatToSend
            // 
            this.txtChatToSend.Location = new System.Drawing.Point(218, 488);
            this.txtChatToSend.Name = "txtChatToSend";
            this.txtChatToSend.Size = new System.Drawing.Size(337, 20);
            this.txtChatToSend.TabIndex = 11;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(218, 307);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(443, 175);
            this.txtChat.TabIndex = 4;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(81, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Location = new System.Drawing.Point(12, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 111);
            this.panel2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSendChat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 654);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "MQO Bot";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblMana;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.ProgressBar ProgressMana;
        private System.Windows.Forms.ProgressBar ProgressHP;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.TextBox txtChatToSend;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ProgressBar ProgressLevel;
        private System.Windows.Forms.Label lblSkill1;
        private System.Windows.Forms.ProgressBar ProgressSkill1;
        private System.Windows.Forms.Label lblSkill2;
        private System.Windows.Forms.ProgressBar ProgressSkill2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblElements;
        private System.Windows.Forms.Label lblRelics;
        private System.Windows.Forms.Label lblChests;
        private System.Windows.Forms.Label lblWorkload;
        private System.Windows.Forms.Label lblStatPoints;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboFight;
        private System.Windows.Forms.Button btnStopFight;
        private System.Windows.Forms.Button btnStartFight;
        private System.Windows.Forms.ComboBox comboSkill;
        private System.Windows.Forms.Button btnStopSkill;
        private System.Windows.Forms.Button btnStartSkill;
    }
}

