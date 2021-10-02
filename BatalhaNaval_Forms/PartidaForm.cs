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
        private int qtdAcertos = 0;

        public GroupBox getGroupBox_YourShips() {
            return gB_YourShips;
        }

        public GroupBox getGroupBox_OponnentShips () {
            return gB_OponnentShips;
        }

        public PartidaForm() {
            InitializeComponent();
        }

        public PartidaForm (TCPIP protocol, string ClientIP, Tabuleiro myBoard) {
            InitializeComponent();

            clientIP = ClientIP;
            this.protocol = protocol;
            this.myBoard = new Tabuleiro(10, 10);

            if (clientIP != null) { // first player is server side
                yourTurn = true;
                lbl_Turn.Text = "Sua vez.";
            }

            try {
                protocol.setEventsForm2(this);

                this.myBoard.setMineFields(this, false);

                opponentBoard = new Tabuleiro(10, 10);
                opponentBoard.setMineFields(this, true);

                string message = ""; // loop para envio dos navios escolhidos
                for (int y = 0; y < myBoard.getNumberRows(); y++) {
                    for (int x = 0; x < myBoard.getNumberColumns(); x++) {
                        MineField mine = myBoard.getMineFields()[y, x];

                        if (mine.isShip()) {
                            message += mine.getShipName().ToString();

                            this.myBoard.getMineFields()[y, x].setShip(true, mine.getShip(), mine.isVertical());

                            qtdAcertos++;
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
                //Quem estiver atirando deverá marcar o local na área “JOGO DO ADVERSÁRIO“. Se for 
                //água marque com uma bolinha para não atirar no mesmo quadradinho mais de uma vez. 
                //Se for fogo marque com X, se afundou pinte o quadrado e já coloque bolinhas ao redor, pois nenhum navio pode encostar no outro.
                if (!mine.getJogada()) {
                    mine.setJogada(opponentBoard);
                    if (opponentBoard.getQtdAcertos() == qtdAcertos)
                        youWin();

                    string message = cordenates[0].ToString() + ";" +
                    cordenates[1].ToString() + ";";

                    protocol.sendMessage(clientIP, message);

                    // Se o tiro acertou a água, passa a vez para o adversário
                    if (!mine.isShip()) {
                        yourTurn = false;
                        lbl_Turn.Text = "Espere a jogada do jogador adversário...";
                    }
                }
            }
        }

        private void youWin () {
            MessageBox.Show("Parabéns, você venceu!!", "Jogo finalizado", MessageBoxButtons.OK);

            protocol.sendMessage(clientIP, "GAME OVER");

            JogarNovamente();
        }

        private void youLose () {
            MessageBox.Show("Você perdeu o jogo :(", "GAME OVER", MessageBoxButtons.OK);

            JogarNovamente();
        }

        private void JogarNovamente () {
            if (clientIP != null) {
                protocol.server.Events.ClientDisconnected -= Events_ClientDisconnected;

                protocol.server.Stop();
            } else
                protocol.client.Events.Disconnected -= Events_Disconnected;

            if (MessageBox.Show("Deseja jogar novamente?", "Nova partida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                t1 = new Thread(openNewMatch);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();

                Close();
            } else
                ChangeForm();
        }

        private void receivingData (string message) {
            if (firstMessage) {
                int rows = opponentBoard.getNumberRows();
                int columns = opponentBoard.getNumberColumns();

                for (int y = 0; y < rows; y++) {
                    for (int x = 0; x < columns; x++) {
                        int index = (y * rows) + x;

                        if (message[index] != '0')
                            opponentBoard.getMineFields()[y, x].setShip(message[index].ToString());
                    }
                }

                firstMessage = false;
            } else {
                lbl_Result.Text = message;

                if (message == "GAME OVER")
                    youLose();

                string[] values = message.Split(';');
                int Y = int.Parse(values[0]);
                int X = int.Parse(values[1]);

                myBoard.getMineFields()[Y, X].setJogada(myBoard);

                yourTurn = true;
                lbl_Turn.Text = "Sua vez.";
            }
        }

        public void Events_ClientDataReceived(object sender, DataReceivedEventArgs e) {
            string message = Encoding.UTF8.GetString(e.Data);

            receivingData(message);
        }

        public void Events_ServerDataReceived(object sender, DataReceivedEventArgs e) {
            string message = Encoding.UTF8.GetString(e.Data);

            receivingData(message);
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

        private void openNewMatch () {
            bool serverSide = false;
            string IP = "";

            if (clientIP != null) {
                serverSide = true;
                IP = protocol.getIP().ToString();
            } else {
                for (int x = 0; x < 4; x++) {
                    if (protocol.getIP().GetAddressBytes()[x].ToString().Length < 2)
                        IP += "  ";
                    else if (protocol.getIP().GetAddressBytes()[x].ToString().Length < 3)
                        IP += " ";

                    IP += protocol.getIP().GetAddressBytes()[x].ToString();
                }
            }

            Application.Run(new Insert_Ships(IP, protocol.getPort(), serverSide));
        }

    }
}
