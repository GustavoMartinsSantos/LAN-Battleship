using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        private bool allowDrop = true;

        public GroupBox getGroupBox_MyShips() {
            return gB_Ships;
        }

        public IPAddress getIP() {
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

        public int getPort() {
            return int.Parse(txt_Port.Text);
        }

        public void setPort(int porta) {
            txt_Port.Text = porta.ToString();
        }

        private void changeForm() {
            t1 = new Thread(openPartidaForm);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();

            this.Close();
        }

        private void openPartidaForm() {
            Application.Run(new PartidaForm(protocol, clientIP, tabuleiro));
        }

        private int[] getStartShipPositions(int[] dragPositions, int[] dropPositions) {
            MineField dragMine = tabuleiro.getMineFields()[dragPositions[0], dragPositions[1]];

            for (int x = dragMine.getShipPart(); x > 1; x--) {
                if (vertical) {
                    if (dropPositions[0] > 0)
                        dropPositions[0] -= 1;
                } else {
                    if (dropPositions[1] > 0)
                        dropPositions[1] -= 1;
                }
            }

            return dropPositions;
        }

        private int[,] getShipFields(int ship, ref int Y, ref int X) {
            bool allow = true;
            int fields = 3;
            switch (ship) {
                case 1:
                    fields = 5;
                    break;
                case 2:
                case 4:
                    fields = 4;
                    break;
                case 3:
                    fields = 2;
                    break;
                case 5:
                case 6:
                    fields = 3;
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

            for (cont = 0; cont < fields; cont++) {
                if (vertical) {
                    positions[cont, 0] = Y + cont;
                    positions[cont, 1] = X;
                } else {
                    positions[cont, 0] = Y;
                    positions[cont, 1] = X + cont;
                }

                if(allow) {
                    int y = positions[cont, 0];
                    int x = positions[cont, 1];
                    MineField[,] mines = tabuleiro.getMineFields();

                    int[,] verificationPositions = {
                        { y - 1, x - 1 },
                        { y - 1, x     },
                        { y - 1, x + 1 },
                        { y    , x - 1 },
                        { y    , x     },
                        { y    , x + 1 },
                        { y + 1, x - 1 },
                        { y + 1, x     },
                        { y + 1, x + 1 }
                    };

                    for (int c = 0; c < verificationPositions.GetLength(0); c++) {
                        y = verificationPositions[c, 0];
                        x = verificationPositions[c, 1];

                        if (y >= 0 && y < 10 && x >= 0 && x < 10) {
                            if (mines[y, x].getShipName() != 0 && mines[y, x].getShipName() != ship) {
                                allow = false;
                                break;
                            }
                        }
                    }
                }
            }

            if (allow)
                allowDrop = true;
            else
                allowDrop = false;
            return positions;
        }

        private void unsetShips (int ship) {
            for (int y = 0; y < 10; y++) {
                for (int x = 0; x < 10; x++) {
                    if (tabuleiro.getMineFields()[y, x].getShipName() == ship)
                        tabuleiro.getMineFields()[y, x].setShip(false, null, vertical);
                }
            }
        }

        private void setShips(int ship, int Y, int X) {
            int[,] positions = getShipFields(ship, ref Y, ref X);

            for (int cont = 0; cont < positions.GetLength(0); cont++) {
                string shipName = ship.ToString() + "_" + (cont + 1).ToString();

                int y = positions[cont, 0];
                int x = positions[cont, 1];
                MineField mine = tabuleiro.getMineFields()[y, x];

                mine.setShip(true, shipName, vertical);

                mine.btn.FlatAppearance.BorderSize = 1;
                mine.btn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        public void createShips() {
            Random rand = new Random();
            for (int ship = 1; ship <= 6; ship++) {
                int vertical = rand.Next(0, 2);
                int number = rand.Next(1, 101);

                if (vertical == 0)
                    this.vertical = false;
                else
                    this.vertical = true;
                
                int[] dropPositions = tabuleiro.getMineFieldPosition(number);
                getShipFields(ship, ref dropPositions[0], ref dropPositions[1]);

                if (allowDrop)
                    setShips(ship, dropPositions[0], dropPositions[1]);
                else
                    ship -= 1;
            }
        }

        public Insert_Ships() {
            InitializeComponent();

            comboBoxConection.SelectedIndex = 0;

            foreach (string IP in TCPIP.GetLocalIPAddress()) {
                comboBox_LocalIPs.Items.Add(IP);
            }

            comboBox_LocalIPs.SelectedIndex = 0;

            tabuleiro = new Tabuleiro(10, 10);

            tabuleiro.setMineFields(this);

            createShips();
        }

        public Insert_Ships(string IPConection, int porta, bool serverSide) {
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
            lbl_IP.Text = "IP do host";
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

            } catch (OverflowException) {
                MessageBox.Show("IP inválido!", "ERRO",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskTxt_HostIP.Focus();
            } catch (TimeoutException) {
                MessageBox.Show("Host não encontrado na rede", "Erro de conexão",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (SocketException) {
                string message = "Host já estabelecido";

                if (radioBtnClient.Checked)
                    message = "Host não estabelecido ainda";

                MessageBox.Show(message, "Erro de conexão",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().FullName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Randomize_Click(object sender, EventArgs e) {
            for (int c = 1; c <= 6; c++)
                unsetShips(c);

            createShips();
        }

        public void dragEnter(object sender, DragEventArgs e) {
            e.Effect = e.AllowedEffect;
        }

        public void btn_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (vertical)
                    vertical = false;
                else
                    vertical = true;
            }

            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] Positions = tabuleiro.getMineFieldPosition(number);
            MineField mine = tabuleiro.getMineFields()[Positions[0], Positions[1]];

            if (mine.isShip()) {
                string data = mine.getShipName().ToString() + ";";
                data += Positions[0].ToString() + ";" + Positions[1].ToString();

                this.DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        public void dragOverMineField(object sender, DragEventArgs e) {
            string data = e.Data.GetData(DataFormats.Text).ToString();
            string[] values = data.Split(';');
            int[] dragPositions = { int.Parse(values[1]), int.Parse(values[2]) };

            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            dropPositions = getStartShipPositions(dragPositions, dropPositions);
            int[,] positions = getShipFields(int.Parse(values[0]), ref dropPositions[0], ref dropPositions[1]);

            for (int cont = 0; cont < positions.GetLength(0); cont++) {
                MineField mine = tabuleiro.getMineFields()[positions[cont, 0], positions[cont, 1]];

                Button dropBtn = mine.btn;
                dropBtn.FlatAppearance.BorderSize = 3;

                if (allowDrop) { 
                    //mine.btn.AllowDrop = true;
                    dropBtn.FlatAppearance.BorderColor = Color.Blue;
                } else {
                    //mine.btn.AllowDrop = false;
                    dropBtn.FlatAppearance.BorderColor = Color.Red;
                }
            }
        }

        public void dragLeaveMineField(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            for (int c = 0; c < 10; c++) {
                Button dropBtn;

                if (vertical)
                    dropBtn = tabuleiro.getMineFields()[c, dropPositions[1]].btn;
                else
                    dropBtn = tabuleiro.getMineFields()[dropPositions[0], c].btn;

                dropBtn.AllowDrop = true;

                dropBtn.FlatAppearance.BorderSize = 1;
                dropBtn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        public void dragDropMinefield(object sender, DragEventArgs e) {
            string data = e.Data.GetData(DataFormats.Text).ToString();
            string[] values = data.Split(';');
            int[] dragPositions = { int.Parse(values[1]), int.Parse(values[2]) };

            Button btn = (Button)sender;
            int number = int.Parse(btn.Name.Substring(btn.Name.IndexOf("_") + 1));
            int[] dropPositions = tabuleiro.getMineFieldPosition(number);

            dropPositions = getStartShipPositions(dragPositions, dropPositions);
            int[,] positions = getShipFields(int.Parse(values[0]), ref dropPositions[0], ref dropPositions[1]);

            if (allowDrop) {
                lbl_Dica2.Visible = false;

                unsetShips(int.Parse(values[0]));
                setShips(int.Parse(values[0]), dropPositions[0], dropPositions[1]);
            } else {
                for (int cont = 0; cont < positions.GetLength(0); cont++) {
                    MineField mine = tabuleiro.getMineFields()[positions[cont, 0], positions[cont, 1]];
                    Button dropBtn = mine.btn;

                    dropBtn.FlatAppearance.BorderSize = 1;
                    dropBtn.FlatAppearance.BorderColor = Color.Black;
                }

                lbl_Dica2.Visible = true;
            }
        }

        public void Events_ClientConnected(object sender, ClientConnectedEventArgs e) {
            if (clientIP == null) {
                clientIP = e.IpPort;

                changeForm();
            } else
                protocol.server.DisconnectClient(e.IpPort);
        }

        public void Events_ServerConnected(object sender, EventArgs e) {
            changeForm();
        }

        private void radioBtnHost_CheckedChanged(object sender, EventArgs e) {
            lbl_IP.Text = "Seu IP";
            mskTxt_HostIP.Visible = false;
            comboBox_LocalIPs.Visible = true;
        }

        private void btn_RefreshIPs_Click(object sender, EventArgs e) {
            comboBox_LocalIPs.Items.Clear();
            
            foreach (string IP in TCPIP.GetLocalIPAddress()) {
                comboBox_LocalIPs.Items.Add(IP);
            }

            comboBox_LocalIPs.SelectedIndex = 0;
        }

        private void txt_Port_KeyPress(object sender, KeyPressEventArgs e) {
            char c = e.KeyChar; // recebe a tecla enviada

            // se a tecla digitada for diferente de backspace e números,
            if (c != 8 && (c < 40 || c > 57))
                e.Handled = true; // o evento é manipulado
        }
    }
}
