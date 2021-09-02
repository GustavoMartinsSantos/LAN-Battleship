using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNaval_Forms {
    class Tabuleiro {
        private int rows = 10;
        private int columns = 10;
        private MineField[,] mineFields;
        private int startPositionY = 38;
        private int startPositionX = 38;
        private int addHeight = 51;
        private int addWidth = 51;

        public MineField[,] getMineFields () {
            return mineFields;
        }

        public int getNumberRows () {
            return rows;
        }

        public int getNumberColumns () {
            return columns;
        }

        public int[] getMineFieldPosition (int fieldNumber) {
            int[] Positions = new int[2];

            int verticalMult = columns;
            for (int x = 2; ; x++) {
                if ((fieldNumber - verticalMult) <= 0) {
                    Positions[0] = x - 2;
                    break;
                }  else
                    verticalMult = x * columns;
            }

            Positions[1] = fieldNumber - (Positions[0] * columns) - 1;

            return Positions;
        }

        

        public void setMineFields(PartidaForm form, bool opponentBoard) {
            mineFields = new MineField[rows, columns];
            int startVerticalPosition = startPositionY;
            int startHorizontalPosition = startPositionX;
            int number = 1;
            string boardBtn = "board2_";

            if (opponentBoard)
                boardBtn = "board1_";

            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < columns; x++) {
                    mineFields[y, x] = new MineField();

                    mineFields[y, x].createButton(boardBtn, number, form, opponentBoard, 
                    startVerticalPosition, startHorizontalPosition);

                    startHorizontalPosition += addWidth;
                    number++;
                }

                startHorizontalPosition = startPositionX;
                startVerticalPosition += addHeight;
            }
        }

        public void startPositions(int initialY, int initialX, int addHeight, int addWidth) {
            if (initialY > 0)
                startPositionY = initialY;
            if (initialX > 0)
                startPositionX = initialX;
            if (addHeight > 0)
                this.addHeight = addHeight;
            if (addWidth > 0)
                this.addWidth = addWidth;
        }

        public Tabuleiro(int rows, int columns) {
            if (rows > 0)
                this.rows = rows;
            if (columns > 0)
                this.columns = columns;
        }
    }
}
