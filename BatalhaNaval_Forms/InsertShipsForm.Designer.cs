
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
            this.btn_Randomize = new System.Windows.Forms.Button();
            this.btn_RefreshIPs = new System.Windows.Forms.Button();
            this.lbl_Conection = new System.Windows.Forms.Label();
            this.comboBox_LocalIPs = new System.Windows.Forms.ComboBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.comboBoxConection = new System.Windows.Forms.ComboBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.radioBtnHost = new System.Windows.Forms.RadioButton();
            this.radioBtnClient = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.gB_Ships = new System.Windows.Forms.GroupBox();
            this.lbl_10 = new System.Windows.Forms.Label();
            this.lbl_9 = new System.Windows.Forms.Label();
            this.lbl_8 = new System.Windows.Forms.Label();
            this.lbl_7 = new System.Windows.Forms.Label();
            this.lbl_6 = new System.Windows.Forms.Label();
            this.lbl_5 = new System.Windows.Forms.Label();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_A = new System.Windows.Forms.Label();
            this.lbl_B = new System.Windows.Forms.Label();
            this.lbl_C = new System.Windows.Forms.Label();
            this.lbl_D = new System.Windows.Forms.Label();
            this.lbl_E = new System.Windows.Forms.Label();
            this.lbl_F = new System.Windows.Forms.Label();
            this.lbl_G = new System.Windows.Forms.Label();
            this.lbl_H = new System.Windows.Forms.Label();
            this.lbl_I = new System.Windows.Forms.Label();
            this.lbl_J = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Dica = new System.Windows.Forms.Label();
            this.lbl_Dica2 = new System.Windows.Forms.Label();
            this.groupBox_Conection.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskTxt_HostIP
            // 
            this.mskTxt_HostIP.Font = new System.Drawing.Font("Consolas", 12F);
            this.mskTxt_HostIP.Location = new System.Drawing.Point(145, 122);
            this.mskTxt_HostIP.Mask = "990.990.990.990";
            this.mskTxt_HostIP.Name = "mskTxt_HostIP";
            this.mskTxt_HostIP.Size = new System.Drawing.Size(157, 26);
            this.mskTxt_HostIP.TabIndex = 2;
            this.mskTxt_HostIP.Visible = false;
            // 
            // btn_Play
            // 
            this.btn_Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_Play.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btn_Play.ForeColor = System.Drawing.Color.LightGreen;
            this.btn_Play.Location = new System.Drawing.Point(15, 170);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(178, 30);
            this.btn_Play.TabIndex = 8;
            this.btn_Play.Text = "Iniciar partida";
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // groupBox_Conection
            // 
            this.groupBox_Conection.Controls.Add(this.btn_Randomize);
            this.groupBox_Conection.Controls.Add(this.btn_RefreshIPs);
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
            this.groupBox_Conection.Location = new System.Drawing.Point(34, 171);
            this.groupBox_Conection.Name = "groupBox_Conection";
            this.groupBox_Conection.Size = new System.Drawing.Size(313, 260);
            this.groupBox_Conection.TabIndex = 0;
            this.groupBox_Conection.TabStop = false;
            // 
            // btn_Randomize
            // 
            this.btn_Randomize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_Randomize.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btn_Randomize.ForeColor = System.Drawing.Color.LightGreen;
            this.btn_Randomize.Location = new System.Drawing.Point(15, 206);
            this.btn_Randomize.Name = "btn_Randomize";
            this.btn_Randomize.Size = new System.Drawing.Size(178, 30);
            this.btn_Randomize.TabIndex = 9;
            this.btn_Randomize.Text = "Randomizar";
            this.btn_Randomize.UseVisualStyleBackColor = false;
            this.btn_Randomize.Click += new System.EventHandler(this.btn_Randomize_Click);
            // 
            // btn_RefreshIPs
            // 
            this.btn_RefreshIPs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_RefreshIPs.Image = ((System.Drawing.Image)(resources.GetObject("btn_RefreshIPs.Image")));
            this.btn_RefreshIPs.Location = new System.Drawing.Point(218, 170);
            this.btn_RefreshIPs.Name = "btn_RefreshIPs";
            this.btn_RefreshIPs.Size = new System.Drawing.Size(70, 66);
            this.btn_RefreshIPs.TabIndex = 2;
            this.btn_RefreshIPs.UseVisualStyleBackColor = false;
            this.btn_RefreshIPs.Click += new System.EventHandler(this.btn_RefreshIPs_Click);
            // 
            // lbl_Conection
            // 
            this.lbl_Conection.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Conection.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_Conection.Location = new System.Drawing.Point(66, 24);
            this.lbl_Conection.Name = "lbl_Conection";
            this.lbl_Conection.Size = new System.Drawing.Size(73, 18);
            this.lbl_Conection.TabIndex = 0;
            this.lbl_Conection.Text = "Conexão";
            // 
            // comboBox_LocalIPs
            // 
            this.comboBox_LocalIPs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LocalIPs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_LocalIPs.FormattingEnabled = true;
            this.comboBox_LocalIPs.Location = new System.Drawing.Point(145, 121);
            this.comboBox_LocalIPs.Name = "comboBox_LocalIPs";
            this.comboBox_LocalIPs.Size = new System.Drawing.Size(157, 27);
            this.comboBox_LocalIPs.TabIndex = 7;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.lbl_IP.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_IP.Location = new System.Drawing.Point(56, 125);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(53, 21);
            this.lbl_IP.TabIndex = 6;
            this.lbl_IP.Text = "Seu IP";
            // 
            // comboBoxConection
            // 
            this.comboBoxConection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConection.Font = new System.Drawing.Font("Consolas", 12F);
            this.comboBoxConection.FormattingEnabled = true;
            this.comboBoxConection.Items.AddRange(new object[] {
            "TCP/IP"});
            this.comboBoxConection.Location = new System.Drawing.Point(145, 21);
            this.comboBoxConection.Name = "comboBoxConection";
            this.comboBoxConection.Size = new System.Drawing.Size(157, 27);
            this.comboBoxConection.TabIndex = 1;
            // 
            // txt_Port
            // 
            this.txt_Port.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Port.Location = new System.Drawing.Point(146, 86);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(156, 26);
            this.txt_Port.TabIndex = 5;
            this.txt_Port.Text = "1425";
            this.txt_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Port_KeyPress);
            // 
            // radioBtnHost
            // 
            this.radioBtnHost.AutoSize = true;
            this.radioBtnHost.Checked = true;
            this.radioBtnHost.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.radioBtnHost.ForeColor = System.Drawing.Color.LightGreen;
            this.radioBtnHost.Location = new System.Drawing.Point(76, 53);
            this.radioBtnHost.Name = "radioBtnHost";
            this.radioBtnHost.Size = new System.Drawing.Size(60, 25);
            this.radioBtnHost.TabIndex = 2;
            this.radioBtnHost.TabStop = true;
            this.radioBtnHost.Text = "Host";
            this.radioBtnHost.UseVisualStyleBackColor = true;
            this.radioBtnHost.CheckedChanged += new System.EventHandler(this.radioBtnHost_CheckedChanged);
            // 
            // radioBtnClient
            // 
            this.radioBtnClient.AutoSize = true;
            this.radioBtnClient.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.radioBtnClient.ForeColor = System.Drawing.Color.LightGreen;
            this.radioBtnClient.Location = new System.Drawing.Point(188, 53);
            this.radioBtnClient.Name = "radioBtnClient";
            this.radioBtnClient.Size = new System.Drawing.Size(68, 25);
            this.radioBtnClient.TabIndex = 3;
            this.radioBtnClient.Text = "Client";
            this.radioBtnClient.UseVisualStyleBackColor = true;
            this.radioBtnClient.CheckedChanged += new System.EventHandler(this.radioBtnClient_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.label4.ForeColor = System.Drawing.Color.LightGreen;
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Porta de conexão";
            // 
            // gB_Ships
            // 
            this.gB_Ships.BackColor = System.Drawing.Color.Transparent;
            this.gB_Ships.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gB_Ships.BackgroundImage")));
            this.gB_Ships.Location = new System.Drawing.Point(430, 66);
            this.gB_Ships.Name = "gB_Ships";
            this.gB_Ships.Size = new System.Drawing.Size(559, 552);
            this.gB_Ships.TabIndex = 1;
            this.gB_Ships.TabStop = false;
            // 
            // lbl_10
            // 
            this.lbl_10.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_10.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_10.Location = new System.Drawing.Point(379, 555);
            this.lbl_10.Name = "lbl_10";
            this.lbl_10.Size = new System.Drawing.Size(45, 26);
            this.lbl_10.TabIndex = 6;
            this.lbl_10.Text = "10";
            this.lbl_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_9
            // 
            this.lbl_9.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_9.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_9.Location = new System.Drawing.Point(379, 505);
            this.lbl_9.Name = "lbl_9";
            this.lbl_9.Size = new System.Drawing.Size(45, 26);
            this.lbl_9.TabIndex = 7;
            this.lbl_9.Text = "9";
            this.lbl_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_8
            // 
            this.lbl_8.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_8.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_8.Location = new System.Drawing.Point(379, 455);
            this.lbl_8.Name = "lbl_8";
            this.lbl_8.Size = new System.Drawing.Size(45, 26);
            this.lbl_8.TabIndex = 8;
            this.lbl_8.Text = "8";
            this.lbl_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_7
            // 
            this.lbl_7.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_7.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_7.Location = new System.Drawing.Point(379, 405);
            this.lbl_7.Name = "lbl_7";
            this.lbl_7.Size = new System.Drawing.Size(45, 26);
            this.lbl_7.TabIndex = 9;
            this.lbl_7.Text = "7";
            this.lbl_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_6
            // 
            this.lbl_6.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_6.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_6.Location = new System.Drawing.Point(379, 355);
            this.lbl_6.Name = "lbl_6";
            this.lbl_6.Size = new System.Drawing.Size(45, 26);
            this.lbl_6.TabIndex = 10;
            this.lbl_6.Text = "6";
            this.lbl_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_5
            // 
            this.lbl_5.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_5.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_5.Location = new System.Drawing.Point(379, 305);
            this.lbl_5.Name = "lbl_5";
            this.lbl_5.Size = new System.Drawing.Size(45, 26);
            this.lbl_5.TabIndex = 11;
            this.lbl_5.Text = "5";
            this.lbl_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_4
            // 
            this.lbl_4.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_4.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_4.Location = new System.Drawing.Point(379, 255);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(45, 26);
            this.lbl_4.TabIndex = 12;
            this.lbl_4.Text = "4";
            this.lbl_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_3
            // 
            this.lbl_3.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_3.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_3.Location = new System.Drawing.Point(379, 205);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(45, 26);
            this.lbl_3.TabIndex = 13;
            this.lbl_3.Text = "3";
            this.lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_2
            // 
            this.lbl_2.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_2.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_2.Location = new System.Drawing.Point(379, 155);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(45, 26);
            this.lbl_2.TabIndex = 14;
            this.lbl_2.Text = "2";
            this.lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_1
            // 
            this.lbl_1.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_1.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_1.Location = new System.Drawing.Point(379, 104);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(45, 26);
            this.lbl_1.TabIndex = 15;
            this.lbl_1.Text = "1";
            this.lbl_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_A
            // 
            this.lbl_A.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_A.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_A.Location = new System.Drawing.Point(456, 24);
            this.lbl_A.Name = "lbl_A";
            this.lbl_A.Size = new System.Drawing.Size(45, 26);
            this.lbl_A.TabIndex = 16;
            this.lbl_A.Text = "A";
            this.lbl_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_B
            // 
            this.lbl_B.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_B.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_B.Location = new System.Drawing.Point(507, 24);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(45, 26);
            this.lbl_B.TabIndex = 17;
            this.lbl_B.Text = "B";
            this.lbl_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C
            // 
            this.lbl_C.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_C.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_C.Location = new System.Drawing.Point(558, 24);
            this.lbl_C.Name = "lbl_C";
            this.lbl_C.Size = new System.Drawing.Size(45, 26);
            this.lbl_C.TabIndex = 18;
            this.lbl_C.Text = "C";
            this.lbl_C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_D
            // 
            this.lbl_D.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_D.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_D.Location = new System.Drawing.Point(609, 24);
            this.lbl_D.Name = "lbl_D";
            this.lbl_D.Size = new System.Drawing.Size(45, 26);
            this.lbl_D.TabIndex = 19;
            this.lbl_D.Text = "D";
            this.lbl_D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_E
            // 
            this.lbl_E.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_E.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_E.Location = new System.Drawing.Point(660, 24);
            this.lbl_E.Name = "lbl_E";
            this.lbl_E.Size = new System.Drawing.Size(45, 26);
            this.lbl_E.TabIndex = 20;
            this.lbl_E.Text = "E";
            this.lbl_E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_F
            // 
            this.lbl_F.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_F.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_F.Location = new System.Drawing.Point(711, 24);
            this.lbl_F.Name = "lbl_F";
            this.lbl_F.Size = new System.Drawing.Size(45, 26);
            this.lbl_F.TabIndex = 21;
            this.lbl_F.Text = "F";
            this.lbl_F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_G
            // 
            this.lbl_G.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_G.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_G.Location = new System.Drawing.Point(762, 24);
            this.lbl_G.Name = "lbl_G";
            this.lbl_G.Size = new System.Drawing.Size(45, 26);
            this.lbl_G.TabIndex = 22;
            this.lbl_G.Text = "G";
            this.lbl_G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_H
            // 
            this.lbl_H.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_H.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_H.Location = new System.Drawing.Point(813, 24);
            this.lbl_H.Name = "lbl_H";
            this.lbl_H.Size = new System.Drawing.Size(45, 26);
            this.lbl_H.TabIndex = 18;
            this.lbl_H.Text = "H";
            this.lbl_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_I
            // 
            this.lbl_I.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_I.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_I.Location = new System.Drawing.Point(864, 24);
            this.lbl_I.Name = "lbl_I";
            this.lbl_I.Size = new System.Drawing.Size(45, 26);
            this.lbl_I.TabIndex = 23;
            this.lbl_I.Text = "I";
            this.lbl_I.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_J
            // 
            this.lbl_J.Font = new System.Drawing.Font("Microsoft Tai Le", 16F);
            this.lbl_J.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_J.Location = new System.Drawing.Point(915, 24);
            this.lbl_J.Name = "lbl_J";
            this.lbl_J.Size = new System.Drawing.Size(45, 26);
            this.lbl_J.TabIndex = 24;
            this.lbl_J.Text = "J";
            this.lbl_J.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_Title.Location = new System.Drawing.Point(57, 66);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(279, 42);
            this.lbl_Title.TabIndex = 25;
            this.lbl_Title.Text = "Batalha Naval";
            // 
            // lbl_Dica
            // 
            this.lbl_Dica.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dica.ForeColor = System.Drawing.Color.LightGreen;
            this.lbl_Dica.Location = new System.Drawing.Point(30, 455);
            this.lbl_Dica.Name = "lbl_Dica";
            this.lbl_Dica.Size = new System.Drawing.Size(317, 44);
            this.lbl_Dica.TabIndex = 10;
            this.lbl_Dica.Text = "Clique com o botão direito do mouse para mudar o navio para vertical/horizontal";
            // 
            // lbl_Dica2
            // 
            this.lbl_Dica2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dica2.ForeColor = System.Drawing.Color.Red;
            this.lbl_Dica2.Location = new System.Drawing.Point(30, 520);
            this.lbl_Dica2.Name = "lbl_Dica2";
            this.lbl_Dica2.Size = new System.Drawing.Size(317, 44);
            this.lbl_Dica2.TabIndex = 26;
            this.lbl_Dica2.Text = "Navios devem ter entre si uma distância de um campo adjacente";
            this.lbl_Dica2.Visible = false;
            // 
            // Insert_Ships
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(37)))), ((int)(((byte)(59)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 638);
            this.Controls.Add(this.lbl_Dica2);
            this.Controls.Add(this.lbl_Dica);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.lbl_J);
            this.Controls.Add(this.lbl_I);
            this.Controls.Add(this.lbl_H);
            this.Controls.Add(this.lbl_G);
            this.Controls.Add(this.lbl_F);
            this.Controls.Add(this.lbl_E);
            this.Controls.Add(this.lbl_D);
            this.Controls.Add(this.lbl_C);
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.lbl_A);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_3);
            this.Controls.Add(this.lbl_4);
            this.Controls.Add(this.lbl_5);
            this.Controls.Add(this.lbl_6);
            this.Controls.Add(this.lbl_7);
            this.Controls.Add(this.lbl_8);
            this.Controls.Add(this.lbl_9);
            this.Controls.Add(this.lbl_10);
            this.Controls.Add(this.gB_Ships);
            this.Controls.Add(this.groupBox_Conection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 698);
            this.Name = "Insert_Ships";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batalha Naval";
            this.groupBox_Conection.ResumeLayout(false);
            this.groupBox_Conection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox gB_Ships;
        private System.Windows.Forms.Button btn_RefreshIPs;
        private System.Windows.Forms.Label lbl_10;
        private System.Windows.Forms.Label lbl_9;
        private System.Windows.Forms.Label lbl_8;
        private System.Windows.Forms.Label lbl_7;
        private System.Windows.Forms.Label lbl_6;
        private System.Windows.Forms.Label lbl_5;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_A;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.Label lbl_C;
        private System.Windows.Forms.Label lbl_D;
        private System.Windows.Forms.Label lbl_E;
        private System.Windows.Forms.Label lbl_F;
        private System.Windows.Forms.Label lbl_G;
        private System.Windows.Forms.Label lbl_H;
        private System.Windows.Forms.Label lbl_I;
        private System.Windows.Forms.Label lbl_J;
        private System.Windows.Forms.Button btn_Randomize;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Dica;
        private System.Windows.Forms.Label lbl_Dica2;
    }
}

