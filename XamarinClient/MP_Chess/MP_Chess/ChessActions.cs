using System;

namespace MP_Chess
{
	public class ChessActions
	{
		public static SocketSingleton socket;

		// put what my username is here
		public string username;

		// put what opponent username is here
		public string opponent;

		// Data types to represent what state a board block could be in
		// chessmanColour repreents the colour of the piece, or in case of no piece; empty
		public enum chessmanColour { empty, white, black }

		// chesman represents the type of pieces, or if none; empty
		public enum chessman { empty, King, Queen, Rook, Bishop, Knight, Pawn }

		// What is in a square
		public struct gameSquare
		{
			public chessmanColour colour; // colour of the piece on the square 
			public chessman piece; // content of the game piece
		}

		// Genearte a standard board
		public gameSquare[,] generateDefaultBoard()
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

		public string printBoard(gameSquare[,] square){
			string board = "";
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					switch (square[i, j].piece)
					{
					case chessman.Bishop:
						board = board + "B ";
						break;
					case chessman.King:
						board = board + "K ";
						break;
					case chessman.Knight:
						board = board + "N ";
						break;
					case chessman.Pawn:
						board = board + "P ";
						break;
					case chessman.Queen:
						board = board + "Q ";
						break;
					case chessman.Rook:
						board = board + "R ";
						break;
					default:
						board = board + "  ";
						break;
					}
				}
				board = board + "\n";
			}
			return board;
		}




		// login to server
		public bool login(){
			string toSend = "LOGIN " + username;
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();

			return false;
		}

		// start a new game (i.e. you are player 1)
		public bool newGame(){
			string toSend = "NEW " + opponent;
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();

			return false;
		}

		// join an existing game (i.e. you are player 2)
		public bool joinGame(){
			string toSend = "JOIN " + opponent;
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();

			return false;
		}

		// move a piece
		public bool move(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2){
			// currently assuming the move is legal
			/*
			switch (chessBoard [x1, y1].piece)
			{
				case chessman.empty:
					return false;
					break;
				case chessman.Pawn:
					if (chessBoard [x2, y2].piece != chessman.empty) {
						if (Math.Abs (x1 - x1) == 1 && Math.Abs (y1 - y2) == 1) {
						// valid, do nothing to stop it
						}
					} else if ((y2 != y1 + 1 || y2 != y1 - 1) && x1 != x2) {
						// not vaild move
						return false;
					}
					break;
				case chessman.Rook:
					if (!(x1 == x2 || y1 == y2)) {
						return false;
					}
					break;
				case chessman.Queen:
					if (x1 == x1 || y1 == y2) {
							
					}
					break;
				default:

					break;
			} */

				string toSend = "MOVE " + x1.ToString () + " " + y1.ToString () + " " + x2.ToString () + " " + y2.ToString ();
				chessBoard [x2, y2] = chessBoard [x1, y1];
				chessBoard [x1, y1] = new gameSquare { colour = chessmanColour.empty, piece = chessman.empty };
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				return true;



		}

		// get last move made by other player, false is returned if no move yet made
		public bool getLastMove(gameSquare[,] chessBoard){
			string toSend = "GETMOVE";
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();
			string recieve;
			recieve = socket.getIn ().ReadLine ();
			string[] recieveSplit;
			recieveSplit = recieve.Split (' ');
			if (recieveSplit [0] == "MOVE") {
				int x1 = Convert.ToInt32 (recieveSplit [1]);
				int y1 = Convert.ToInt32 (recieveSplit [2]);
				int x2 = Convert.ToInt32 (recieveSplit [3]);
				int y2 = Convert.ToInt32 (recieveSplit [4]);
				// the move made by player 2
				chessBoard [x2, y2] = chessBoard [x1, y1];
				chessBoard [x1, y1] = new gameSquare { colour = chessmanColour.empty, piece = chessman.empty };
				return true;
			} else {
				return false;
			}
			return false;
		}

		public bool logout(){
			string toSend = "LOGOUT";
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();
			return false;
		}

		// used for debugging on server
		public bool printOnServer(){
			string toSend = "PRINT";
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();
			return false;
		}

		// return string of all last chat messages
		public string getLastChat(){
			string toSend = "GET";
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();
			// then recieve from socket
			return "";
		}

		// post to chatroom
		public bool postToChat(string message){
			string toSend = message;
			socket.getOut ().WriteLine (toSend);
			socket.getOut ().Flush ();
			return false;
		}



		public ChessActions (string uname, string uopp)
		{
			username = uname;
			opponent = uopp;
		}
	}
}

