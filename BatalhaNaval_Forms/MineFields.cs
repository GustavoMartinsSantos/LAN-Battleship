using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNaval_Forms {
    class MineField {
        private static int heightField = 45;
        private static int widthFields = 45;

        private bool Vertical = false;
        private bool Ship = false;
        private bool Jogada = false;

        public Button btn;

        public bool isVertical() {
            return Vertical;
        }

        public bool getShip() {
            return Ship;
        }

        public void setShip() {
            Ship = true;
        }

        public bool getJogada () {
            return Jogada;
        }

        public void setJogada() {
            Jogada = true;

            setImage();
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
                btn.Image = Image.FromFile("../../IMG/Explosao.png");
            else if (Jogada)
                btn.Image = Image.FromFile("../../IMG/Splash.png");
            else {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255);
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255);
                btn.BackColor = Color.FromArgb(0, 255, 255, 255);
            }
        }

        public MineField () {}
    }
}
