
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading;
using System.Timers;

namespace MP_Chess
{
	[Activity (Label = "ChessActivity")]			
	public class ChessActivity : Activity
	{

		// put what my username is here
		public static string username;

		// put what opponent username is here
		public static string opponent;

		// is it my turn?
		public bool myTurn;

		//What type of connection are we making (new or join)
		public static bool newGame;

		public ChessActions actions;

		public void printToTable(ChessActions.gameSquare[,] chessboard)
		{
			/*for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TextView tableSquare = FindViewById<TextView> (Resource.Id.ChessSquare + i + j);
				}
			}*/

			ImageView[,] table = new ImageView[8, 8];

			table[0,0] = FindViewById<ImageView> (Resource.Id.ChessSquare00);
			table[0,1] = FindViewById<ImageView> (Resource.Id.ChessSquare01);
			table[0,2] = FindViewById<ImageView> (Resource.Id.ChessSquare02);
			table[0,3] = FindViewById<ImageView> (Resource.Id.ChessSquare03);
			table[0,4] = FindViewById<ImageView> (Resource.Id.ChessSquare04);
			table[0,5] = FindViewById<ImageView> (Resource.Id.ChessSquare05);
			table[0,6] = FindViewById<ImageView> (Resource.Id.ChessSquare06);
			table[0,7] = FindViewById<ImageView> (Resource.Id.ChessSquare07);

			table[1,0] = FindViewById<ImageView> (Resource.Id.ChessSquare10);
			table[1,1] = FindViewById<ImageView> (Resource.Id.ChessSquare11);
			table[1,2] = FindViewById<ImageView> (Resource.Id.ChessSquare12);
			table[1,3] = FindViewById<ImageView> (Resource.Id.ChessSquare13);
			table[1,4] = FindViewById<ImageView> (Resource.Id.ChessSquare14);
			table[1,5] = FindViewById<ImageView> (Resource.Id.ChessSquare15);
			table[1,6] = FindViewById<ImageView> (Resource.Id.ChessSquare16);
			table[1,7] = FindViewById<ImageView> (Resource.Id.ChessSquare17);

			table[2,0] = FindViewById<ImageView> (Resource.Id.ChessSquare20);
			table[2,1] = FindViewById<ImageView> (Resource.Id.ChessSquare21);
			table[2,2] = FindViewById<ImageView> (Resource.Id.ChessSquare22);
			table[2,3] = FindViewById<ImageView> (Resource.Id.ChessSquare23);
			table[2,4] = FindViewById<ImageView> (Resource.Id.ChessSquare24);
			table[2,5] = FindViewById<ImageView> (Resource.Id.ChessSquare25);
			table[2,6] = FindViewById<ImageView> (Resource.Id.ChessSquare26);
			table[2,7] = FindViewById<ImageView> (Resource.Id.ChessSquare27);

			table[3,0] = FindViewById<ImageView> (Resource.Id.ChessSquare30);
			table[3,1] = FindViewById<ImageView> (Resource.Id.ChessSquare31);
			table[3,2] = FindViewById<ImageView> (Resource.Id.ChessSquare32);
			table[3,3] = FindViewById<ImageView> (Resource.Id.ChessSquare33);
			table[3,4] = FindViewById<ImageView> (Resource.Id.ChessSquare34);
			table[3,5] = FindViewById<ImageView> (Resource.Id.ChessSquare35);
			table[3,6] = FindViewById<ImageView> (Resource.Id.ChessSquare36);
			table[3,7] = FindViewById<ImageView> (Resource.Id.ChessSquare37);

			table[4,0] = FindViewById<ImageView> (Resource.Id.ChessSquare40);
			table[4,1] = FindViewById<ImageView> (Resource.Id.ChessSquare41);
			table[4,2] = FindViewById<ImageView> (Resource.Id.ChessSquare42);
			table[4,3] = FindViewById<ImageView> (Resource.Id.ChessSquare43);
			table[4,4] = FindViewById<ImageView> (Resource.Id.ChessSquare44);
			table[4,5] = FindViewById<ImageView> (Resource.Id.ChessSquare45);
			table[4,6] = FindViewById<ImageView> (Resource.Id.ChessSquare46);
			table[4,7] = FindViewById<ImageView> (Resource.Id.ChessSquare47);

			table[5,0] = FindViewById<ImageView> (Resource.Id.ChessSquare50);
			table[5,1] = FindViewById<ImageView> (Resource.Id.ChessSquare51);
			table[5,2] = FindViewById<ImageView> (Resource.Id.ChessSquare52);
			table[5,3] = FindViewById<ImageView> (Resource.Id.ChessSquare53);
			table[5,4] = FindViewById<ImageView> (Resource.Id.ChessSquare54);
			table[5,5] = FindViewById<ImageView> (Resource.Id.ChessSquare55);
			table[5,6] = FindViewById<ImageView> (Resource.Id.ChessSquare56);
			table[5,7] = FindViewById<ImageView> (Resource.Id.ChessSquare57);

			table[6,0] = FindViewById<ImageView> (Resource.Id.ChessSquare60);
			table[6,1] = FindViewById<ImageView> (Resource.Id.ChessSquare61);
			table[6,2] = FindViewById<ImageView> (Resource.Id.ChessSquare62);
			table[6,3] = FindViewById<ImageView> (Resource.Id.ChessSquare63);
			table[6,4] = FindViewById<ImageView> (Resource.Id.ChessSquare64);
			table[6,5] = FindViewById<ImageView> (Resource.Id.ChessSquare65);
			table[6,6] = FindViewById<ImageView> (Resource.Id.ChessSquare66);
			table[6,7] = FindViewById<ImageView> (Resource.Id.ChessSquare67);

			table[7,0] = FindViewById<ImageView> (Resource.Id.ChessSquare70);
			table[7,1] = FindViewById<ImageView> (Resource.Id.ChessSquare71);
			table[7,2] = FindViewById<ImageView> (Resource.Id.ChessSquare72);
			table[7,3] = FindViewById<ImageView> (Resource.Id.ChessSquare73);
			table[7,4] = FindViewById<ImageView> (Resource.Id.ChessSquare74);
			table[7,5] = FindViewById<ImageView> (Resource.Id.ChessSquare75);
			table[7,6] = FindViewById<ImageView> (Resource.Id.ChessSquare76);
			table[7,7] = FindViewById<ImageView> (Resource.Id.ChessSquare77);

			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					switch (chessboard [i, j].piece)
					{
					case ChessActions.chessman.Bishop:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackBishop);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhiteBishop);
						}

						break;
					case ChessActions.chessman.King:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackKing);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhiteKing);
						}

						break;
					case ChessActions.chessman.Knight:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackKnight);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhiteKnight);
						}
						break;
					case ChessActions.chessman.Pawn:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackPawn);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhitePawn);
						}
						break;
					case ChessActions.chessman.Queen:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackQueen);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhiteQueen);
						}
						break;
					case ChessActions.chessman.Rook:
						if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
							table [i, j].SetImageResource (Resource.Drawable.BlackRook);
						} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
							table [i, j].SetImageResource (Resource.Drawable.WhiteRook);
						}

						break;
					default:
						table [i, j].SetImageResource (Resource.Drawable.blank);
						break;
					}
				}
			}

		}

		public void getUpdates(ChessActions actions, ChessActions.gameSquare[,] chessBoard, TextView whoTurn){
				if (actions.getLastMove (chessBoard)) {
					myTurn = true;
					if(myTurn)
						whoTurn.Text = username + "'s Turn";
					else 
						whoTurn.Text = opponent + "'s Turn";

					printToTable(chessBoard);
			}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			actions = new ChessActions (username, opponent);
			actions.login ();
			if (newGame) {
				actions.newGame ();
				myTurn = true;
			} else {
				actions.joinGame ();
				myTurn = false;
			}
			// if you are creating the game, you are white player
			ChessActions.isWhite = newGame;

			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Chess);


	//		TextView board = FindViewById<TextView> (Resource.Id.ChessBoard);

			// Make a chess board
			ChessActions.gameSquare[,] chessBoard = actions.generateDefaultBoard ();

			printToTable (chessBoard);
			//board.Text = actions.printBoard (chessBoard);

			actions.printOnServer ();

			Button moveButton = FindViewById<Button> (Resource.Id.MoveButton);

			EditText fromMove = FindViewById<EditText> (Resource.Id.MoveFrom);
			EditText toMove = FindViewById<EditText> (Resource.Id.MoveTo);

			TextView headText = FindViewById<TextView> (Resource.Id.HeadText);
			headText.Text = "Playing against " + opponent + ".";
			TextView whoTurn = FindViewById<TextView> (Resource.Id.whoTurn);

			if (newGame == true) {
				whoTurn.Text = username + "'s Turn";
			} else {
				whoTurn.Text = opponent + "'s Turn";
			}

			string MoveFrom;
			string MoveTo;

			moveButton.Click += (object sender, EventArgs e) => 
			{
				if(myTurn){
					MoveFrom = fromMove.Text;
					MoveTo = toMove.Text;
					// Make sure parameter is valid
					if(actions.move(chessBoard, MoveFrom[1] - '0', MoveFrom[0]-'A', MoveTo[1] - '0', MoveTo[0]-'A'))
					{
						printToTable(chessBoard);
						actions.printOnServer();
						whoTurn.Text = opponent + "'s Turn";
						myTurn = false;
					}
					else 
					{
						fromMove.Text = "A1";
						toMove.Text = "A2";
					}
				}
			};

			// Create your application here
			Button exitButton = FindViewById<Button>(Resource.Id.ExitButton);

			//Wire up the connnect button
			exitButton.Click += (object sender, EventArgs e) =>
			{
				actions.logout();
				Intent intent = new Intent(Intent.ActionMain);
				intent.AddCategory(Intent.CategoryHome);
				intent.SetFlags(ActivityFlags.NewTask);
				StartActivity(intent);
				Finish();
			};

			// get updates
				System.Threading.ThreadPool.QueueUserWorkItem(delegate {
				//getUpdates (actions, chessBoard, whoTurn);
				while(true){
					RunOnUiThread(()=>getUpdates(actions, chessBoard, whoTurn));
					System.Threading.Thread.Sleep (1000);
				}
				}, null);
		}
	}
}

