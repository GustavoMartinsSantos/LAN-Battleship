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

        private int[,] getShipFields (int ship, int Y, int X) {
            int fields = 3;
            switch (ship) {
                case 1:
                    fields = 5;
                    break;
            }

            int cont = X;

            if (vertical)
                cont = Y;

            // verifica se as posições à frente são válidas
            for (int c = 0; c < fields; c++) {
                if (cont > 9) {
                    if (vertical)
                        Y -= 1;
                    else
                        X -= 1;
                }

                cont++;
            }

            int[,] positions = new int[fields, 2];

            for(cont = 0; cont < fields; cont++) {
                positions[cont, 0] = Y;
                positions[cont, 1] = X + cont;

                if (vertical) {
                    positions[cont, 0] = Y + cont;
                    positions[cont, 1] = X;
                }
            }

            return positions;
        }

        private int setShips(int ship, int Y, int X, bool move) {
            if (!move) { // desalocação dos navios
                for (int c = 0; c < 10; c++) {
                    if (tabuleiro.getMineFields()[c, X].getShipName() ==
                        tabuleiro.getMineFields()[c, X].getShipName())
                        tabuleiro.getMineFields()[c, X].setShip(false, "", vertical);

                    if (tabuleiro.getMineFields()[Y, c].getShipName() ==
                        tabuleiro.getMineFields()[Y, c].getShipName())
                        tabuleiro.getMineFields()[Y, c].setShip(false, "", vertical);
                }
            } else {
                int[,] positions = getShipFields(ship, Y, X);

                for (int cont = 0; cont < positions.GetLength(0); cont++) {
                    // resolver o problema de alocação de uma posição do navio diferente da ponta
                    string shipName = ship.ToString() + "_" + (cont + 1).ToString();

                    MineField mine = tabuleiro.getMineFields()[positions[cont, 0], positions[cont, 1]];

                    mine.setShip(true, shipName, vertical);

                    mine.btn.FlatAppearance.BorderSize = 1;
                    mine.btn.FlatAppearance.BorderColor = Color.Black;
                }
            }

            return 1;
        }
        
        public void createShips () {
            tabuleiro = new Tabuleiro(10, 10);

            tabuleiro.setShips(this);

            setShips(1, 4, 9, true);
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
            int[] dragPositions = { int.Parse(values[1]), int.Parse(values[2]) };

            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            setShips(int.Parse(values[0]), dragPositions[0], dragPositions[1], false);
            setShips(int.Parse(values[0]), dropPositions[0], dropPositions[1], true);
        }

        public void dragOverMineField (object sender, DragEventArgs e) {
            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            string data = e.Data.GetData(DataFormats.Text).ToString();
            string[] values = data.Split(';');

            int[,] positions = getShipFields(int.Parse(values[0]), dropPositions[0], dropPositions[1]);
            for(int cont = 0; cont < positions.GetLength(0); cont++) {
                Button dropBtn = tabuleiro.getMineFields()[positions[cont, 0], positions[cont, 1]].btn;

                dropBtn.FlatAppearance.BorderSize = 3;
                dropBtn.FlatAppearance.BorderColor = Color.Blue;
            }
        }

        public void dragLeaveMineField (object sender, EventArgs e) {
            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            for (int c = 0; c < 10; c++) {
                Button dropBtn = tabuleiro.getMineFields()[c, dropPositions[1]].btn;

                dropBtn.FlatAppearance.BorderSize = 1;
                dropBtn.FlatAppearance.BorderColor = Color.Black;

                dropBtn = tabuleiro.getMineFields()[dropPositions[0], c].btn;

                dropBtn.FlatAppearance.BorderSize = 1;
                dropBtn.FlatAppearance.BorderColor = Color.Black;                
            }
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
