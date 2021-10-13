using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNaval_Forms {
    public class MineField {
        private static int heightField = 45;
        private static int widthFields = 45;

        private bool Vertical = false;
        private bool Ship = false;
        private bool Jogada = false;
        private string shipPart;

        public Button btn;

        public bool isVertical() {
            return Vertical;
        }

        public bool isShip() {
            return Ship;
        }

        public void setShip(bool ship, string shipName, bool vertical) {
            Ship = ship;
            shipPart = shipName;
            Vertical = vertical;


            //if(shipName != null)
            setImage(); // possíveis erros
        }

        public void setShip (string shipNumber) {
            Ship = true;
            shipPart = shipNumber;
        }

        public string getShip() {
            return shipPart;
        }

        public int getShipPart () {
            if (shipPart == null)
                return 0;
            else
                return int.Parse(shipPart.Substring(shipPart.IndexOf("_") + 1));
        }

        public int getShipName () {
            if (shipPart == null)
                return 0;
            else
                return int.Parse(shipPart.Substring(0, shipPart.IndexOf("_")));
        }

        public bool getJogada () {
            return Jogada;
        }

        public void setJogada(Tabuleiro tabuleiro) {
            Jogada = true;

            if (Ship)
                tabuleiro.addAcerto();

            setImage();
        }

        public void setPlayerField (Insert_Ships form, int number, int startVerticalPosition, int startHorizontalPosition) {
            btn = new Button();

            btn.Height = heightField;
            btn.Width = widthFields;
            btn.Name = "btn_" + number.ToString();
            btn.Location = new Point(startHorizontalPosition, startVerticalPosition);

            setImage();

            btn.AllowDrop  = true;
            btn.DragEnter += new DragEventHandler(form.dragEnter);
            btn.MouseDown += new MouseEventHandler(form.btn_MouseDown);
            btn.DragDrop  += new DragEventHandler(form.dragDropMinefield);
            btn.DragOver  += new DragEventHandler(form.dragOverMineField);
            btn.DragLeave += new EventHandler(form.dragLeaveMineField);

            form.getGroupBox_MyShips().Controls.Add(btn);
        }

        public void createButton(string board, int number, PartidaForm form, bool opponentBoard, int startVerticalPosition, int startHorizontalPosition) {
            btn = new Button();

            btn.Height = heightField;
            btn.Width = widthFields;
            btn.Name = board + "btn" + number.ToString();
            btn.Location = new Point(startHorizontalPosition, startVerticalPosition);
            
            setImage();

            if (opponentBoard)
                btn.Click += new EventHandler(form.btn_Mina_Click);

            if (opponentBoard)
                form.getGroupBox_OponnentShips().Controls.Add(btn);
            else
                form.getGroupBox_YourShips().Controls.Add(btn);
        }

        public void setImage () {
            if (Ship && Jogada)
                btn.Image = Properties.Resources.Explosao;
            else if (Jogada)
                btn.Image = Properties.Resources.Splash;
            else if (Ship) {
                btn.Image = (Image)Properties.Resources.ResourceManager.GetObject("Ship" + shipPart);

                if (Vertical) {
                    btn.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            } else {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                btn.BackColor = Color.FromArgb(0, 255, 255, 255);
                btn.Image = null;
            }
        }

        public MineField () {}
    }
}
