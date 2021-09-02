using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNaval_Forms {
    public partial class Insert_Ships : Form {
        private Thread t1;
        private TCPIP protocol;
        private Tabuleiro tabuleiro;
        public bool isServer;
        private string clientIP;

        public IPAddress getIP () {
            IPAddress ip;

            if (mskTxt_HostIP.Visible) {
                byte[] bytesIP = new byte[4];

                for (int x = 0; x < 4; x++) {
                    bytesIP[x] = byte.Parse(mskTxt_HostIP.Text.Substring(x * 4, 3));
                }

                ip = new IPAddress(bytesIP);
            } else {
                ip = IPAddress.Parse(comboBox_LocalIPs.SelectedItem.ToString());
                isServer = true;
            }

            return ip;
        }

        public int getPort () {
            return int.Parse(txt_Port.Text);
        }

        public Insert_Ships() {
            InitializeComponent();

            comboBoxConection.SelectedIndex = 0;
            
            foreach (string IP in TCPIP.GetLocalIPAddress()) {
                comboBox_LocalIPs.Items.Add(IP);
            }

            comboBox_LocalIPs.SelectedIndex = 0;

        }

        private void radioBtnClient_CheckedChanged(object sender, EventArgs e) {
            lbl_IP.Text = "IP do host: ";
            comboBox_LocalIPs.Visible = false;

            lbl_IP.Visible = true;
            mskTxt_HostIP.Visible = true;
        }

        private void btn_Play_Click(object sender, EventArgs e) {
            try {
                if (radioBtnClient.Checked) {
                    if (!mskTxt_HostIP.MaskCompleted) {
                        MessageBox.Show("IP inválido!", "ERRO",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mskTxt_HostIP.Focus();
                    } else {
                        protocol = new TCPIP(getIP(), getPort(), this, isServer);
                        protocol.client.Connect();
                    }
                } else
                    protocol = new TCPIP(getIP(), getPort(), this, isServer);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeForm () {
            t1 = new Thread(openPartidaForm);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();

            this.Close();
        }

        private void openPartidaForm () {
            Application.Run(new PartidaForm(protocol, clientIP));
        }

        private void radioBtnHost_CheckedChanged(object sender, EventArgs e) {
            lbl_IP.Text = "Seu IP: ";
            mskTxt_HostIP.Visible = false;
            comboBox_LocalIPs.Visible = true;
        }

        private void pictureBox16_Click(object sender, EventArgs e) {
            this.DoDragDrop("asda", DragDropEffects.Copy);
        }

        private void pictureBox28_DragEnter(object sender, DragEventArgs e) {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBox28_DragDrop(object sender, DragEventArgs e) {
            //Bitmap image = (Bitmap) e.Data.GetData(DataFormats.Bitmap);
            string data = e.Data.GetData(DataFormats.Text).ToString();

            MessageBox.Show(data);
        }

        public void Events_ClientConnected(object sender, ClientConnectedEventArgs e) {
            if (clientIP == null) {
                clientIP = e.IpPort;

                ChangeForm();
            } else
                protocol.server.DisconnectClient(e.IpPort);
        }

        public void Events_ServerConnected(object sender, EventArgs e) {
            ChangeForm();
        }
    }
}
