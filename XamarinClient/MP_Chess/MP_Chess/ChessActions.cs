using System;


namespace MP_Chess
{
	public class ChessActions
	{
		/// <summary>Instance of the socket used to connect to server.</summary>
		public static SocketSingleton socket;

		/// <summary>My user name.</summary>
		public static string username;

		/// <summary>Opponents user name.</summary>
		public static string opponent;

		/// <summary>Represents color of the piece. In case of no piece - empty.</summary>
		public enum chessmanColour { empty, white, black }

		/// <summary>Represents piece type, or empty if none.</summary>
		public enum chessman { empty, King, Queen, Rook, Bishop, Knight, Pawn }

		/// <summary>Am I the white player?.</summary>
		public static bool isWhite;

		/// <summary>Is the game over?.</summary>
		public static bool endGame;

		/// <summary>Game Square struct. Contains piece type & color.</summary>
		public struct gameSquare
		{
			public chessmanColour colour; // colour of the piece on the square 
			public chessman piece; // content of the game piece
		}


		/// <summary>Genearte a chess board with game pieces.</summary>
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

		/// <summary>Prints and ASCI board. (Not used in current version)</summary>
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




		/// <summary>Log in to the server.</summary>
		public bool login(){
			try {
				string toSend = "LOGIN " + username;
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();

				return true;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Start a new game. (You will be palyer 1)</summary>
		public bool newGame(){
			try {
				string toSend = "NEW " + opponent;
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				string recieve = socket.getIn ().ReadLine();
				endGame = false;
				if (recieve == "TRUE")
					return true;
				return false;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Joins an existing game. (you will be player 2)</summary>
		public bool joinGame(){
			try {
				string toSend = "JOIN " + opponent;
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				endGame = false;
				string recieve = socket.getIn().ReadLine();
				if (recieve == "TRUE")
					return true;
				return false;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Checks if Pawn move is legal.</summary>
		public bool pawnLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2){
			if (chessBoard [x1, y1].colour == chessmanColour.white) {
				if (x1 == 6) {
					if (x1 == x2 + 2 && y1 == y2)
						return true;
				}
				if (chessBoard [x2, y2].piece == chessman.empty) {
					if (x1 == x2 + 1 && y1 == y2)
						return true;

				} else if (chessBoard [x2, y2].piece != chessman.empty && chessBoard [x2, y2].colour == chessmanColour.black) {
					if (x1 == x2 + 1 && ((y1 == y2 - 1) || (y1 == y2 + 1)))
						return true;

				}
			} else if (chessBoard [x1, y1].colour == chessmanColour.black) {
				if (x1 == 1) {
					if (x1 == x2 - 2 && y1 == y2)
						return true;
				}
				if (chessBoard [x2, y2].piece == chessman.empty) {
					if (x1 == x2 - 1 && y1 == y2)
						return true;

				} else if (chessBoard [x2, y2].piece != chessman.empty && chessBoard[x2, y2].colour == chessmanColour.white) {
					if (x1 == x2 - 1 && ((y1 == y2 - 1) || (y1 == y2 + 1)))
						return true;
				} 
			}

			return false;
		}

		/// <summary>Checks if King move is legal.</summary>
		public bool kingLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2){
			if (x1 == x2) {
				if (y1 == y2 + 1 || y1 == y2 - 1)
					return true;

			} else if (y1 == y2) {
				if (x1 == x2 + 1 || x1 == x2 - 1)
					return true;

			} else {
				if (x1 == x2 + 1 || x1 == x2 - 1) {
					if (y1 == y2 + 1 || y1 == y2 - 1)
						return true;
				}
			}
			return false;
		}

		/// <summary>Checks if Rook move is legal.</summary>
		public bool rookLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2) {
			if (x1 == x2) {
				if (y2 > y1) {
					for (int i = y1 + 1; i < y2; i++) {
						if (chessBoard [x1, i].piece != chessman.empty)
							return false;
					}
					return true;
				} else {
					for (int i = y1 - 1; i > y2; i--) {
						if (chessBoard [x1, i].piece != chessman.empty)
							return false;
					}
					return true;
				}
			} else if (y1 == y2) {
				if (x2 > x1) {
					for (int i = x1 + 1; i < x2; i++) {
						if (chessBoard [i, y1].piece != chessman.empty) {
							return false;
						}
					}
					return true;
				} else {
					for (int i = x1 - 1; i > x2; i--) {
						if (chessBoard [i, y1].piece != chessman.empty) {
							return false;
						}
					}
					return true;
				}
			}
			return false;
		}

		/// <summary>Checks if Queen move is legal.</summary>
		public bool queenLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2) {
			// queen is a combination of these moves being legal
			return bishopLegal(chessBoard, x1, y1, x2, y2) || rookLegal(chessBoard, x1, y1, x2, y2);
		}

		/// <summary>Checks if Bishop move is legal.</summary>
		public bool bishopLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2) {
			if (Math.Abs (x1 - x2) == Math.Abs (y1 - y2)) {
				if (x1 < x2) {
					if (y1 < y2) {
						int j = y1 + 1;
						for (int i = x1 + 1; i < x2; i++) {
							if (chessBoard [i, j].piece != chessman.empty) {
								return false;
							}
							j++;
							}
							return true;
					} else if (y2 < y1) {						
						int j = y1 - 1;
						for (int i = x1 + 1; i < x2; i++) {
							if (chessBoard [i, j].piece != chessman.empty) {
								return false;
							}
							j--;
							}
						return true;
					}
				} else if (x2 < x1) {
					if (y1 < y2) {
						int j = y1 + 1;
						for (int i = x1 - 1; i > x2; i--) {
							if (chessBoard [i, j].piece != chessman.empty) {
								return false;
							}
							j++;			
							}
						return true;
					} else if (y2 < y1) {
						int j = y1 - 1;
						for (int i = x1 - 1; i > x2; i--) {
							if (chessBoard [i, j].piece != chessman.empty) {
								return false;
							}
							j--;
							}
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>Checks if Knight move is legal.</summary>
		public bool knightLegal(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2) {
			if (x1 == x2 - 1 || x1 == x2 + 1) {
				if (y1 == y2 - 2 || y1 == y2 + 2) {
					return true;
				}
			} else if (y1 == y2 - 1 || y1 == y2 + 1) {
				if (x1 == x2 - 2 || x1 == x2 + 2) {
					return true;
				}
			}
			return false;
		}

		/// <summary>Moves a game piece.</summary>
		/// <remarks><para>(x1,y1) - from postion, (x2,y2) - to position</para></remarks>

		public bool move(gameSquare[,] chessBoard, int x1, int y1, int x2, int y2){
			try {
				// check parameters are legal
				if (x1 >= 0 && x1 <= 7
					&& x2 >= 0 && x2 <= 7
					&& y1 >= 0 && y1 <= 7
					&& y2 >= 0 && y2 <= 7) {
					// make sure it's your piece to move
					if ((chessBoard [x1, y1].colour == chessmanColour.white && isWhite) || chessBoard [x1, y1].colour == chessmanColour.black && !isWhite) {
						// check if the move is legal

						if ((chessBoard [x1, y1].colour == chessmanColour.white && chessBoard [x2, y2].colour == chessmanColour.white)
						    || (chessBoard [x1, y1].colour == chessmanColour.black && chessBoard [x2, y2].colour == chessmanColour.black))
								return false; 

							bool isLegal = false;
							switch (chessBoard [x1, y1].piece) {
							case chessman.Bishop:
								isLegal = bishopLegal (chessBoard, x1, y1, x2, y2);
								break;
							case chessman.King:
								isLegal = kingLegal (chessBoard, x1, y1, x2, y2);
								break;
							case chessman.Knight:
								isLegal = knightLegal (chessBoard, x1, y1, x2, y2);
								break;
							case chessman.Pawn:
								isLegal = pawnLegal (chessBoard, x1, y1, x2, y2);
								if(isLegal && (x2 == 7 || x2 == 0))
									chessBoard [x1, y1].piece = chessman.Queen;
							break;
							case chessman.Queen:
								isLegal = queenLegal (chessBoard, x1, y1, x2, y2);
								break;
							case chessman.Rook:
								isLegal = rookLegal (chessBoard, x1, y1, x2, y2);
								break;
							}
						/*	Android.Widget.Toast.MakeText (Android.App.Application.Context, isLegal.ToString (),
								Android.Widget.ToastLength.Long).Show ();
*/
							if (isLegal) {
								string toSend = "MOVE " + x1.ToString () + " " + y1.ToString () + " " + x2.ToString () + " " + y2.ToString ();
								if (chessBoard[x2, y2].piece == chessman.King) endGame = true;
								chessBoard [x2, y2] = chessBoard [x1, y1];
								chessBoard [x1, y1] = new gameSquare { colour = chessmanColour.empty, piece = chessman.empty };
								socket.getOut ().WriteLine (toSend);
								socket.getOut ().Flush ();
								return true;
							} else {
								return false;
							}
						} else {
							return false;
						}
					} else {
						return false;
					}
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Get last move made by other player, 
		/// false is returned if no move yet made.</summary>
		public bool getLastMove(gameSquare[,] chessBoard){
			try {
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
					if (chessBoard[x2, y2].piece == chessman.King) endGame = true;

					if(chessBoard[x1, y1].piece == chessman.Pawn && (x2 == 0 || x2 == 7))
						chessBoard[x1, y1].piece = chessman.Queen;
					
					chessBoard [x2, y2] = chessBoard [x1, y1];
					chessBoard [x1, y1] = new gameSquare { colour = chessmanColour.empty, piece = chessman.empty };
					return true;
				} else {
					return false;
				}
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Log out of the server.</summary>
		public bool logout(){
			try {
				string toSend = "LOGOUT";
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				return true;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}
			
		/// <summary>Used for debugging on server.</summary>
		public bool printOnServer(){
			try {
				string toSend = "PRINT";
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				return true;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}

		/// <summary>Returns string of all last chat messages.</summary>
		public string getLastChat(){
			try {
				string toSend = "GET";
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				// then recieve from socket
				return "";
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return "";
			}
		}

		/// <summary>Posts a message to chat room.</summary>
		public bool postToChat(string message){
			try {
				string toSend = message;
				socket.getOut ().WriteLine (toSend);
				socket.getOut ().Flush ();
				return true;
			} catch (Exception e) {
				ChessActivity.OnServerFail ();
				return false;
			}
		}


		/// <summary>Costructor which sets user name and opponent name.</summary>
		public ChessActions (string uname, string uopp)
		{
			username = uname;
			opponent = uopp;
		}
	}
}

