using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTcp;

namespace BatalhaNaval_Forms {
    public partial class PartidaForm : Form {
        private TCPIP protocol;
        private Thread t1;
        private Tabuleiro myBoard;
        private Tabuleiro opponentBoard;
        private string clientIP;
        private bool firstMessage = true;
        private bool yourTurn = false;

        public GroupBox getGroupBox_YourShips() {
            return gB_YourShips;
        }

        public GroupBox getGroupBox_OponnentShips () {
            return gB_OponnentShips;
        }

        public PartidaForm() {
            InitializeComponent();
        }

         public PartidaForm (TCPIP protocol, string ClientIP) {
            InitializeComponent();

            clientIP = ClientIP;
            this.protocol = protocol;

            if (clientIP != null) { // first player is server side
                yourTurn = true;
                lbl_Turn.Text = "Sua vez.";
            }

            try {
                protocol.setEventsForm2(this);

                myBoard = new Tabuleiro(10, 10);
                myBoard.setMineFields(this, false);

                opponentBoard = new Tabuleiro(10, 10);
                opponentBoard.setMineFields(this, true);

                string message = "";
                for (int y = 0; y < myBoard.getNumberRows(); y++) {
                    for (int x = 0; x < myBoard.getNumberColumns(); x++) {
                        if (y == 1) {
                            message += "1";
                            myBoard.getMineFields()[y, x].setShip();
                        } else
                            message += "0";
                    }
                }

                protocol.sendMessage(clientIP, message);

                if(clientIP == null) {
                    MessageBox.Show("Conexão feita com o host.", "Conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("Conexão feita com sucesso. Você é o host", "Conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btn_Mina_Click(object sender, EventArgs e) {
            if (yourTurn) {
                Button btn = (Button)sender;
                int Position = int.Parse(btn.Name.Substring(btn.Name.IndexOf("n") + 1));
                int[] cordenates = opponentBoard.getMineFieldPosition(Position);
                MineField mine = opponentBoard.getMineFields()[cordenates[0], cordenates[1]];

                if (!mine.getJogada()) {
                    mine.setJogada();

                    string message = cordenates[0].ToString() + ";" +
                    cordenates[1].ToString() + ";";

                    protocol.sendMessage(clientIP, message);

                    yourTurn = false;
                    lbl_Turn.Text = "Espere a jogada do jogador adversário...";
                }
            }
        }

        public void Events_ClientDataReceived(object sender, DataReceivedEventArgs e) {
            string message = Encoding.UTF8.GetString(e.Data);

            if (firstMessage) {
                int rows = opponentBoard.getNumberRows();
                int columns = opponentBoard.getNumberColumns();

                for (int y = 0; y < rows; y++) {
                    for (int x = 0; x < columns; x++) {
                        int index = (y * rows) + x;

                        if (message[index] == '1')
                            opponentBoard.getMineFields()[y, x].setShip();
                    }
                }

                firstMessage = false;
            } else {
                lbl_Result.Text = message;

                string[] values = message.Split(';');
                int Y = int.Parse(values[0]);
                int X = int.Parse(values[1]);

                myBoard.getMineFields()[Y, X].setJogada();

                yourTurn = true;
                lbl_Turn.Text = "Sua vez.";
            }
        }

        public void Events_ServerDataReceived(object sender, DataReceivedEventArgs e) {
            string message = Encoding.UTF8.GetString(e.Data);

            if (firstMessage) {
                int rows = opponentBoard.getNumberRows();
                int columns = opponentBoard.getNumberColumns();

                for (int y = 0; y < rows; y++) {
                    for(int x = 0; x < columns; x++) {
                        int index = (y * rows) + x;

                        if (message[index] == '1')
                            opponentBoard.getMineFields()[y, x].setShip();
                    }
                }

                firstMessage = false;
            } else {

                lbl_Result.Text = message;

                string[] values = message.Split(';');
                int Y = int.Parse(values[0]);
                int X = int.Parse(values[1]);

                myBoard.getMineFields()[Y, X].setJogada();

                yourTurn = true;
                lbl_Turn.Text = "Sua vez.";
            }
        }

        public void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e) {
            MessageBox.Show("Conexão perdida com o client.", "Conexão perdida",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

            protocol.server.Stop();

            ChangeForm();
        }

        public void Events_Disconnected(object sender, EventArgs e) {
            MessageBox.Show("Conexão perdida com o host.", "Conexão perdida",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

            ChangeForm();
        }

        public void ChangeForm () {
            t1 = new Thread(openInsertShipsForm);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();

            this.Close();
        }

        private void openInsertShipsForm() {
            Application.Run(new Insert_Ships());
        }

    }
}
