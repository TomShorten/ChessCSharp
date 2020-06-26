using System;

namespace ChessCSharp
{
    class BoardCell
    {
        private int x, y;
        private Piece currentPiece;

        public BoardCell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.currentPiece = null;
        }
        public BoardCell(int x, int y, Piece currentPiece) : this(x, y)
        {
            this.currentPiece = currentPiece;
        }
        public string output()
        {
            if (currentPiece == null)
            {
                return "|    ";
            }
            else
            {
                return "| " + currentPiece.output() + " ";
            }
            
        }
        public Piece getCurrentPiece()
        {
            return currentPiece;
        }

        public void setCurrentPiece(Piece value)
        {
            currentPiece = value;
        }

        public void removePiece()
        {
            currentPiece = null;
        }

    }

}
