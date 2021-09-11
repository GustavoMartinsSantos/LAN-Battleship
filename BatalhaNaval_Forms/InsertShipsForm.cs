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
        private bool vertical = false;
        public GroupBox getGroupBox_MyShips() {
            return gB_Ships;
        }

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

        public void setPort (int porta) {
            txt_Port.Text = porta.ToString();
        }

        private void deallocateShips (int ship, int Y, int X) {
            /*int fields = 3;
            switch (ship) {
                case 1:
                    fields = 5;
                    break;
            }

            for (int cont = 0; cont < fields; cont--) {
                int[] position = { Y, X - cont };

                if (vertical) {
                    position[0] = Y - cont;
                    position[1] = X;
                }

                if (tabuleiro.getMineFields()[Y, X].getShip())
                    tabuleiro.getMineFields()[position[0], position[1]].setShip(false, "", vertical);
            }*/
        }

        private int setShips(int ship, int Y, int X, bool move) {
            int cont = X;

            if (vertical)
                cont = Y;

            int fields = 3;
            switch(ship) {
                case 1: fields = 5;
                    break;
            }

            // verifica se as posições à frente são válidas
            for(int c = 0; c < fields; c++) {
                if(cont > 9) {
                    if (vertical)
                        Y -= 1;
                    else
                        X -= 1;
                }

                /*int x = X; // resolver problema de navio já alocado na linha/coluna
                int y = Y;

                if (vertical) {
                    y = cont;
                    x = X;
                }

                if (tabuleiro.getMineFields()[y, x].getShip())
                    return 0;*/

                cont++;
            }

            /*if (!move)
                deallocateShips(ship, Y, X);*/

            cont = 0;
            while (cont < fields) {
                string shipName = ship.ToString() + "_" + (cont + 1).ToString();
                int[] position = { Y, X + cont };

                if (vertical) {
                    position[0] = Y + cont;
                    position[1] = X;
                }

                //MineField mine = tabuleiro.getMineFields()[position[0], position[1]];


                tabuleiro.getMineFields()[position[0], position[1]].setShip(move, shipName, vertical);

                cont++;
            }

            return 1;
        }
        
        public void createShips () {
            tabuleiro = new Tabuleiro(10, 10);
            //tabuleiro.setShips(this);
            //tabuleiro.setMineFields(this, false);

            tabuleiro.setShips(this);

            setShips(1, 4, 3, true);
            /*f(setShips(1, 5, false, 5, 3) == 0) {
                MessageBox.Show("Errado");
            }*/
        }

        public Insert_Ships() {
            InitializeComponent();

            comboBoxConection.SelectedIndex = 0;
            
            foreach (string IP in TCPIP.GetLocalIPAddress()) {
                comboBox_LocalIPs.Items.Add(IP);
            }

            comboBox_LocalIPs.SelectedIndex = 0;

            createShips();
        }

        public Insert_Ships (string IPConection, int porta, bool serverSide) {
            InitializeComponent();

            setPort(porta);

            comboBoxConection.SelectedIndex = 0;

            foreach (string LocalIP in TCPIP.GetLocalIPAddress()) {
                comboBox_LocalIPs.Items.Add(LocalIP);
            }

            if (serverSide) {
                for (int x = 0; x < comboBox_LocalIPs.Items.Count; x++) {
                    if (IPConection == comboBox_LocalIPs.Items[x].ToString())
                        comboBox_LocalIPs.SelectedIndex = x;
                }
            } else {
                radioBtnClient.Checked = true;

                mskTxt_HostIP.Text = IPConection;
            }

            createShips();
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
            //Application.Run(new PartidaForm(protocol, clientIP, tabuleiro));
        }

        public void dragEnter(object sender, DragEventArgs e) {
            e.Effect = e.AllowedEffect;
        }

        public void btn_MouseDown(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] Positions = tabuleiro.getMineFieldPosition(number);
            MineField mine = tabuleiro.getMineFields()[Positions[0], Positions[1]];

            if (mine.getShip()) {
                string data = mine.getShipName().ToString() + ";";
                      data += Positions[0].ToString() + ";" + Positions[1].ToString();

                this.DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        public void dragDropMinefield(object sender, DragEventArgs e) {
            string data = e.Data.GetData(DataFormats.Text).ToString();
            string[] values = data.Split(';');

            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] Positions = tabuleiro.getMineFieldPosition(number);

            setShips(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), false);
            setShips(int.Parse(values[0]), Positions[0], Positions[1], true);

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.Black;
        }

        public void dragOverMineField (object sender, DragEventArgs e) {
            Button btn = (Button) sender;

            btn.FlatAppearance.BorderSize  = 3;
            btn.FlatAppearance.BorderColor = Color.Blue;
        }

        public void dragLeaveMineField (object sender, EventArgs e) {
            Button btn = (Button)sender;

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.Black;
        }

        private void radioBtnHost_CheckedChanged(object sender, EventArgs e) {
            lbl_IP.Text = "Seu IP: ";
            mskTxt_HostIP.Visible = false;
            comboBox_LocalIPs.Visible = true;
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

        private void btn_Rotate_Click(object sender, EventArgs e) {
            if (vertical)
                vertical = false;
            else
                vertical = true;
        }
    }
}
