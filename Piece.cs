using System;

namespace ChessCSharp
{
    class Piece
    {
        private string iD;
        public Piece(string iD)
        {
            this.iD = iD;
        }
        public string output()
        {
            return iD;
        }
    }
}
