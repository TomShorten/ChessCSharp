using System;

namespace ChessCSharp
{
    class Board
    {
        private int sizeX, sizeY;
        private BoardCell[,] cells;
        private int nrOfPw, nrOfPb;

        public Board()
        {
            sizeX = 8;
            sizeY = 8;
            cells = new BoardCell[sizeX, sizeY];
            createCells();
        }
        public void drawBoard()
        {
            numberOfPieces();
            Console.WriteLine("  A    B    C    D    E    F    G    H " + "   Number of black pieces: " + nrOfPb);
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
            Console.WriteLine("----------------------------------------- Number of white pieces: " + nrOfPw);
            if(checkCheck())
            {
                Console.WriteLine("In check");
            }
            else
            {
                Console.WriteLine("Not in check");
            }
            
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
        public bool checkPiece(int pieceX, int pieceY, bool player, string side)
        {
            
            if(cells[pieceX, pieceY].getCurrentPiece() != null)
            {
                char charSide = Convert.ToChar(side);
                Piece piece = cells[pieceX, pieceY].getCurrentPiece();
                char[] pieceSplit = piece.output().ToCharArray();
                if(player == true & pieceSplit[1] == charSide)  // player 1
                {
                    return true;
                }
                else if (player == false & pieceSplit[1] != charSide) // player 2
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please select the piece from your side.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Please select a piece.");
                return false;
            }
        }

        public bool checkMove(int moveX, int moveY, int pieceX, int pieceY)
        {
            Piece currentPiece = cells[pieceX, pieceY].getCurrentPiece();
            char[] piece = currentPiece.output().ToCharArray();
            Piece attackPawn = cells[moveX, moveY].getCurrentPiece();
            char[] attackPiece;
            if (attackPawn != null )
            {
                attackPiece = attackPawn.output().ToCharArray();
            }
            else
            {
                attackPiece = "noPiece".ToCharArray();
            }
            if ((piece[1] == 'w' && attackPiece[1] == 'w') || (piece[1] == 'b' && attackPiece[1] == 'b'))
            {
                return false;
            }
            else
            {
                if (piece[0] == 'P')
                {

                    if (piece[1] == 'b' && pieceY != 1)
                    {
                        if ((moveY - pieceY) == 1)
                        {
                            if ((moveX - pieceX) == 0 && attackPawn == null)
                            {
                                return true;
                            }
                            else if (((moveX - pieceX) == 1 && attackPawn != null) || ((moveX - pieceX) == -1 && attackPawn != null)) // Can take own pawns
                            {
                                return true;
                            }
                        }
                    }
                    else if (piece[1] == 'b' && pieceY == 1)
                    {
                        if ((moveY - pieceY) < 3 && (moveX - pieceX) == 0)
                        {
                            return true;
                        }
                    }
                    else if (piece[1] == 'w' && pieceY != 6) // or 7 or 8
                    {
                        if ((pieceY - moveY) == 1)
                        {
                            if ((pieceX - moveX) == 0 && attackPawn == null)
                            {
                                return true;
                            }
                            else if (((pieceX - moveX) == 1 && attackPawn != null) || ((pieceX - moveX) == -1 && attackPawn != null)) // Can take own pawns
                            {
                                return true;
                            }
                        }
                    }
                    else if (piece[1] == 'w' && pieceY == 6)
                    {
                        if ((pieceY - moveY) < 3 && (moveX - pieceX) == 0)
                        {
                            return true;
                        }
                    }
                }
                else if (piece[0] == 'K')
                {
                    if (((moveY - pieceY) == 1 || (moveY - pieceY) == 0 || (moveY - pieceY) == -1) && ((moveX - pieceX) == 1 || (moveX - pieceX) == 0 || (moveX - pieceX) == -1))
                    {
                        return true;
                    }
                }
                else if (piece[0] == 'Q')
                {
                    if ((System.Math.Abs(moveY - pieceY) > 0 && (moveX - pieceX) == 0) || ((moveY - pieceY) == 0 && System.Math.Abs(moveX - pieceX) > 0) || ((moveY - pieceY) == (moveX - pieceX)))
                    {
                        return true;
                    }
                }
                else if (piece[0] == 'B')
                {
                    if (System.Math.Abs(moveY - pieceY) == System.Math.Abs(moveX - pieceX))
                    {
                        return true;
                    }
                }
                else if (piece[0] == 'N')
                {
                    if ((System.Math.Abs(moveY - pieceY) == 2 && System.Math.Abs(moveX - pieceX) == 1) || (System.Math.Abs(moveX - pieceX) == 2 && System.Math.Abs(moveY - pieceY) == 1))
                    {
                        return true;
                    }
                }
                else if (piece[0] == 'R')
                {
                    if ((System.Math.Abs(moveY - pieceY) > 0 && (moveX - pieceX) == 0) || ((moveY - pieceY) == 0 && System.Math.Abs(moveX - pieceX) > 0))
                    {
                        return true;
                    }
                }
            }
            Console.WriteLine("Please select a valid move.");
            return false;
            

        }
        public void numberOfPieces()
        {
            nrOfPw = 0;
            nrOfPb = 0;
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (cells[x, y].getCurrentPiece() != null)
                    {
                        Piece thisPiece = cells[x, y].getCurrentPiece();
                        char[] thisPieceColour = thisPiece.output().ToCharArray();

                        if (thisPieceColour[1] == 'w')
                        {
                            nrOfPw++;

                        }
                        else
                        {
                            nrOfPb++;
                        }
                    }

                }
            }
        }

        public bool checkCheck()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    Piece thisPiece = cells[x, y].getCurrentPiece();
                    if(thisPiece != null)
                    {
                        char[] thisPieceColour = thisPiece.output().ToCharArray();
                        if (thisPieceColour[0] == 'K') // x any y now fixed at kings position
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    if (cells[i, j].getCurrentPiece() != null)
                                    {
                                        char[] currentPiece = cells[i, j].getCurrentPiece().output().ToCharArray();
                                        if (currentPiece[0] == 'Q' && thisPieceColour[1] != currentPiece[1])
                                        {
                                            if ((System.Math.Abs(x - i) == System.Math.Abs(y - j)) || ((System.Math.Abs(x - i) > 0 && System.Math.Abs(y - j) == 0)) || ((System.Math.Abs(y - j) > 0 && System.Math.Abs(x - i) == 0)))
                                            {
                                                return true;
                                            }
                                        }
                                        else if (currentPiece[0] == 'B' && thisPieceColour[1] != currentPiece[1])
                                        {
                                            if (System.Math.Abs(x - i) == System.Math.Abs(y - j))
                                            {
                                                return true;
                                            }
                                        }
                                        else if (currentPiece[0] == 'R' && thisPieceColour[1] != currentPiece[1])
                                        {
                                            if (((System.Math.Abs(x - i) > 0 && System.Math.Abs(y - j) == 0)) || ((System.Math.Abs(y - j) > 0 && System.Math.Abs(x - i) == 0)))
                                            {
                                                return true;
                                            }
                                        }
                                        else if (currentPiece[0] == 'N' && thisPieceColour[1] != currentPiece[1])
                                        {
                                            if ((System.Math.Abs(x - i) == 2 && System.Math.Abs(y - j) == 1) || (System.Math.Abs(y - j) == 2 && System.Math.Abs(x - i) == 1))
                                            {
                                                return true;
                                            }
                                        }
                                        else if (currentPiece[0] == 'K' && thisPieceColour[1] != currentPiece[1])
                                        {
                                            if ((System.Math.Abs(x - i) < 2 && (System.Math.Abs(x - i) == System.Math.Abs(y - j))) || ((System.Math.Abs(x - i) == 1 && System.Math.Abs(y - j) == 0)) || ((System.Math.Abs(y - j) == 1 && System.Math.Abs(x - i) == 0)))
                                            {
                                                return true;
                                            }
                                        }
                                        /* pawn needed */
                                    }

                                }
                            }
                        }
                    }
                    

                }
            }
            return false;
        }
    }
}
