using System;

namespace ChessCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            bool player = true; // true is player 1
            string side;
            do
            {
                Console.WriteLine("Player 1 please select your side: W/B");
                side = Console.ReadLine();

            } while (!checkSide(side));
            Console.Clear();
            Board board = new Board();
            board.drawBoard();

            while (gameRunning)
            {
                string input;
                char[] parts;
                int pieceX;
                int pieceY;
                int moveX;
                int moveY;

                if (player)
                {
                    do
                    {
                        Console.WriteLine("Player 1 select a piece to move: e.g A2");
                        input = Console.ReadLine();
                        parts = input.ToCharArray();
                        pieceX = char.ToUpper(parts[0]) - 65;
                        pieceY = int.Parse(parts[1].ToString()) - 1;
                    } while(!board.checkPiece(pieceX, pieceY, player, side));


                    do
                    {
                        Console.WriteLine("Enter where you want to move your piece: e.g A3");
                        input = Console.ReadLine();
                        parts = input.ToCharArray();
                        moveX = char.ToUpper(parts[0]) - 65;
                        moveY = int.Parse(parts[1].ToString()) - 1;
                    } while(!board.checkMove(moveX, moveY, pieceX, pieceY));

                    Console.Clear();
                    board.movePiece(pieceX, pieceY, moveX, moveY);
                    board.drawBoard();
                    player = false;
                    
                    
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Player 2 select a  piece to move: e.g A2");
                        input = Console.ReadLine();
                        parts = input.ToCharArray();
                        pieceX = char.ToUpper(parts[0]) - 65;
                        pieceY = int.Parse(parts[1].ToString()) - 1;

                    } while(!board.checkPiece(pieceX, pieceY, player, side));


                    do
                    {
                        Console.WriteLine("Enter where you want to move your piece: e.g A3");
                        input = Console.ReadLine();
                        parts = input.ToCharArray();
                        moveX = char.ToUpper(parts[0]) - 65;
                        moveY = int.Parse(parts[1].ToString()) - 1;
                    } while (!board.checkMove(moveX, moveY, pieceX, pieceY));

                    Console.Clear();
                    board.movePiece(pieceX, pieceY, moveX, moveY);
                    board.drawBoard();
                    player = true;
                    
                }
            }

        }
        private static bool checkSide(string side)
        {
            side = side.ToLower();
            if (side == "w" || side == "b")
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Please input again");
                return false;
            }

        }
    }
}
