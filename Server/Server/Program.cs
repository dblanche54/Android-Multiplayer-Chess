using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {

        public enum chessmanColour { empty, white, black }
        public enum chessman { empty, King, Queen, Rook, Bishop, Knight, Pawn }

        // What is in a square
        public struct gameSquare
        {
            public chessmanColour colour; // colour of the piece on the square 
            public chessman piece; // content of the game piece
        }

        public struct gameObject
        {
            public gameSquare[,] boardGame;
            public List<String> chatRoom;
            public string playerOne;
            public string playerTwo;
        }

        public static List<gameObject> gamesInPlay;

        public static List<String> userNames;
        
        public delegate void Del(TcpClient client);

        gameSquare[,] generateDefaultBoard()
        {
            return
                new gameSquare[8, 8]
                { 
                    // ROW 1
                    {
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Rook },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Knight },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Bishop },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.King },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Queen },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Bishop },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Knight },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Rook }
                    },
                    // ROW 2
                    {
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.black, piece = chessman.Pawn }
                    },
                    // ROW 3
                    {
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty }
                    },
                    //ROW 4
                    {
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty }
                    },
                    // ROW 5
                    {
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty }
                    },
                    // ROW 6
                    {
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty },
                        new gameSquare() { colour = chessmanColour.empty, piece = chessman.empty }
                    },
                    // ROW 7
                    {
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Pawn }
                    },
                    // ROW 8
                    {
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Rook },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Knight },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Bishop },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Queen },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.King },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Bishop },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Knight },
                        new gameSquare() { colour = chessmanColour.white, piece = chessman.Rook }
                    }
                };
        }
        
        public static void handleNewConnection(TcpClient client)
        {
            try
            {
                // do the work of a server instance

            } catch (Exception E) { Console.WriteLine("Exception " + E); }
            
        }

        static void Main(string[] args)
        {
            Console.Write("Server Starting Up\n");

            // Initalize the lists
            userNames = new List<string>();
            gamesInPlay = new List<gameObject>();

            // create server, on port 8180
            TcpListener server = new TcpListener(8180);

            // start server
            server.Start();

            // Setup delegates
            List<Del> handleConnection = new List<Del>();
            List<IAsyncResult> results = new List<IAsyncResult>();

            // How many clients
            int connected = 0;

            //Allow connections
            while (true)
            {

                // Wait for client to connect
                TcpClient client = server.AcceptTcpClient();

                // Add blank field to list so we can use them for new connections
                results.Add(null);
                handleConnection.Add(null);

                Console.Write("Creating new Delegate to handle connection.\n");
                // get streams
                handleConnection[connected] = handleNewConnection;
                // Start new delegate
                results[connected] = handleConnection[connected].BeginInvoke(client, null, null);
                

                connected++;

            }
        }
    }
}
