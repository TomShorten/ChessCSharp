using System;

namespace ChessCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRunning = true;
            string side;
            do
            {
                Console.WriteLine("Player 1 please select your side: W/B");
                side = Console.ReadLine();

            } while (!checkSide(side));

            Board board = new Board();
            board.drawBoard();

            while (gameRunning)
            {
                Console.WriteLine("Player 1 select your first piece to move: e.g A2");
                string input = Console.ReadLine();
                char[] parts = input.ToCharArray();
                int pieceX = char.ToUpper(parts[0]) - 65;
                int pieceY = int.Parse(parts[1].ToString()) - 1;

                Console.WriteLine("Enter where you want to move your piece: e.g A3");
                input = Console.ReadLine();
                parts = input.ToCharArray();
                int moveX = char.ToUpper(parts[0]) - 65;
                int moveY = int.Parse(parts[1].ToString()) - 1;

                Console.Clear();

                board.movePiece(pieceX, pieceY, moveX, moveY);
                board.drawBoard();

                Console.WriteLine("Player 2 select your first piece to move: e.g A2");
                input = Console.ReadLine();
                parts = input.ToCharArray();
                pieceX = char.ToUpper(parts[0]) - 65;
                pieceY = int.Parse(parts[1].ToString()) - 1;

                Console.WriteLine("Enter where you want to move your piece: e.g A3");
                input = Console.ReadLine();
                parts = input.ToCharArray();
                moveX = char.ToUpper(parts[0]) - 65;
                moveY = int.Parse(parts[1].ToString()) - 1;

                Console.Clear();

                board.movePiece(pieceX, pieceY, moveX, moveY);
                board.drawBoard();


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
