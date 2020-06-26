using System;

namespace ChessCSharp
{
    class Board
    {
        private int sizeX, sizeY;
        private BoardCell[,] cells;

        public Board()
        {
            sizeX = 8;
            sizeY = 8;
            cells = new BoardCell[sizeX, sizeY];
            createCells();
        }
        public void drawBoard()
        {
            Console.WriteLine("  A    B    C    D    E    F    G    H");
            for (int y = 0; y < sizeY; y++)
            {
                Console.WriteLine("-----------------------------------------");
                for (int x = 0; x < sizeX; x++)
                {
                    Console.Write(cells[x, y].output());
                    if (x == sizeX - 1)
                    {
                        Console.WriteLine("| " + (y + 1));
                    }

                }
            }
            Console.WriteLine("-----------------------------------------");
        }
        private void createCells()
        {
            cells[0, 0] = new BoardCell(0, 0, new Piece("Rb"));
            cells[1, 0] = new BoardCell(1, 0, new Piece("Nb"));
            cells[2, 0] = new BoardCell(2, 0, new Piece("Bb"));
            cells[3, 0] = new BoardCell(3, 0, new Piece("Qb"));
            cells[4, 0] = new BoardCell(4, 0, new Piece("Kb"));
            cells[5, 0] = new BoardCell(5, 0, new Piece("Bb"));
            cells[6, 0] = new BoardCell(6, 0, new Piece("Nb"));
            cells[7, 0] = new BoardCell(7, 0, new Piece("Rb"));

            for (int i = 0; i < sizeX; i++)
            {
                cells[i, 1] = new BoardCell(i, 1, new Piece("Pb"));
                cells[i, 6] = new BoardCell(i, 6, new Piece("Pw"));
            }

            cells[0, 7] = new BoardCell(0, 7, new Piece("Rw"));
            cells[1, 7] = new BoardCell(1, 7, new Piece("Nw"));
            cells[2, 7] = new BoardCell(2, 7, new Piece("Bw"));
            cells[3, 7] = new BoardCell(3, 7, new Piece("Qw"));
            cells[4, 7] = new BoardCell(4, 7, new Piece("Kw"));
            cells[5, 7] = new BoardCell(5, 7, new Piece("Bw"));
            cells[6, 7] = new BoardCell(6, 7, new Piece("Nw"));
            cells[7, 7] = new BoardCell(7, 7, new Piece("Rw"));
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (cells[i, j] == null)
                    {
                        cells[i, j] = new BoardCell(i, j);
                    }
                    
                }
            }
        }
        public void movePiece(int pieceX, int pieceY, int moveX, int moveY)
        {
            Piece currentPiece = cells[pieceX, pieceY].getCurrentPiece();
            cells[pieceX, pieceY].removePiece();
            cells[moveX, moveY].setCurrentPiece(currentPiece);
        }


    }
}
