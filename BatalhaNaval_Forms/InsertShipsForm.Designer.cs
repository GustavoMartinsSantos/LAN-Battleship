
namespace BatalhaNaval_Forms {
    partial class Insert_Ships {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Insert_Ships));
            this.mskTxt_HostIP = new System.Windows.Forms.MaskedTextBox();
            this.btn_Play = new System.Windows.Forms.Button();
            this.groupBox_Conection = new System.Windows.Forms.GroupBox();
            this.lbl_Conection = new System.Windows.Forms.Label();
            this.comboBox_LocalIPs = new System.Windows.Forms.ComboBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.comboBoxConection = new System.Windows.Forms.ComboBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.radioBtnHost = new System.Windows.Forms.RadioButton();
            this.radioBtnClient = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_Ships = new System.Windows.Forms.GroupBox();
            this.groupBox_Conection.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskTxt_HostIP
            // 
            this.mskTxt_HostIP.Location = new System.Drawing.Point(141, 114);
            this.mskTxt_HostIP.Mask = "990.990.990.990";
            this.mskTxt_HostIP.Name = "mskTxt_HostIP";
            this.mskTxt_HostIP.Size = new System.Drawing.Size(121, 20);
            this.mskTxt_HostIP.TabIndex = 2;
            this.mskTxt_HostIP.Visible = false;
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(56, 153);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(206, 23);
            this.btn_Play.TabIndex = 8;
            this.btn_Play.Text = "Iniciar partida";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // groupBox_Conection
            // 
            this.groupBox_Conection.Controls.Add(this.lbl_Conection);
            this.groupBox_Conection.Controls.Add(this.comboBox_LocalIPs);
            this.groupBox_Conection.Controls.Add(this.lbl_IP);
            this.groupBox_Conection.Controls.Add(this.mskTxt_HostIP);
            this.groupBox_Conection.Controls.Add(this.btn_Play);
            this.groupBox_Conection.Controls.Add(this.comboBoxConection);
            this.groupBox_Conection.Controls.Add(this.txt_Port);
            this.groupBox_Conection.Controls.Add(this.radioBtnHost);
            this.groupBox_Conection.Controls.Add(this.radioBtnClient);
            this.groupBox_Conection.Controls.Add(this.label4);
            this.groupBox_Conection.Location = new System.Drawing.Point(12, 146);
            this.groupBox_Conection.Name = "groupBox_Conection";
            this.groupBox_Conection.Size = new System.Drawing.Size(356, 229);
            this.groupBox_Conection.TabIndex = 0;
            this.groupBox_Conection.TabStop = false;
            // 
            // lbl_Conection
            // 
            this.lbl_Conection.AutoSize = true;
            this.lbl_Conection.Location = new System.Drawing.Point(64, 20);
            this.lbl_Conection.Name = "lbl_Conection";
            this.lbl_Conection.Size = new System.Drawing.Size(52, 13);
            this.lbl_Conection.TabIndex = 0;
            this.lbl_Conection.Text = "Conexão:";
            // 
            // comboBox_LocalIPs
            // 
            this.comboBox_LocalIPs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LocalIPs.FormattingEnabled = true;
            this.comboBox_LocalIPs.Location = new System.Drawing.Point(141, 114);
            this.comboBox_LocalIPs.Name = "comboBox_LocalIPs";
            this.comboBox_LocalIPs.Size = new System.Drawing.Size(121, 21);
            this.comboBox_LocalIPs.TabIndex = 7;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(64, 117);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(42, 13);
            this.lbl_IP.TabIndex = 6;
            this.lbl_IP.Text = "Seu IP:";
            // 
            // comboBoxConection
            // 
            this.comboBoxConection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConection.FormattingEnabled = true;
            this.comboBoxConection.Items.AddRange(new object[] {
            "TCP/IP"});
            this.comboBoxConection.Location = new System.Drawing.Point(141, 12);
            this.comboBoxConection.Name = "comboBoxConection";
            this.comboBoxConection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxConection.TabIndex = 1;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(153, 76);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(79, 20);
            this.txt_Port.TabIndex = 5;
            this.txt_Port.Text = "1425";
            // 
            // radioBtnHost
            // 
            this.radioBtnHost.AutoSize = true;
            this.radioBtnHost.Checked = true;
            this.radioBtnHost.Location = new System.Drawing.Point(83, 48);
            this.radioBtnHost.Name = "radioBtnHost";
            this.radioBtnHost.Size = new System.Drawing.Size(47, 17);
            this.radioBtnHost.TabIndex = 2;
            this.radioBtnHost.TabStop = true;
            this.radioBtnHost.Text = "Host";
            this.radioBtnHost.UseVisualStyleBackColor = true;
            this.radioBtnHost.CheckedChanged += new System.EventHandler(this.radioBtnHost_CheckedChanged);
            // 
            // radioBtnClient
            // 
            this.radioBtnClient.AutoSize = true;
            this.radioBtnClient.Location = new System.Drawing.Point(163, 48);
            this.radioBtnClient.Name = "radioBtnClient";
            this.radioBtnClient.Size = new System.Drawing.Size(51, 17);
            this.radioBtnClient.TabIndex = 3;
            this.radioBtnClient.Text = "Client";
            this.radioBtnClient.UseVisualStyleBackColor = true;
            this.radioBtnClient.CheckedChanged += new System.EventHandler(this.radioBtnClient_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Porta de conexão";
            // 
            // groupBox_Ships
            // 
            this.groupBox_Ships.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Ships.BackgroundImage = global::BatalhaNaval_Forms.Properties.Resources.Fundo;
            this.groupBox_Ships.Location = new System.Drawing.Point(475, 30);
            this.groupBox_Ships.Name = "groupBox_Ships";
            this.groupBox_Ships.Size = new System.Drawing.Size(592, 558);
            this.groupBox_Ships.TabIndex = 1;
            this.groupBox_Ships.TabStop = false;
            // 
            // Insert_Ships
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1089, 624);
            this.Controls.Add(this.groupBox_Ships);
            this.Controls.Add(this.groupBox_Conection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Insert_Ships";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batalha Naval";
            this.groupBox_Conection.ResumeLayout(false);
            this.groupBox_Conection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mskTxt_HostIP;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.GroupBox groupBox_Conection;
        private System.Windows.Forms.Label lbl_Conection;
        private System.Windows.Forms.ComboBox comboBox_LocalIPs;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.ComboBox comboBoxConection;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.RadioButton radioBtnHost;
        private System.Windows.Forms.RadioButton radioBtnClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_Ships;
    }
}

