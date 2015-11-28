
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

namespace MP_Chess
{
	[Activity (Label = "ChessActivity")]			
	public class ChessActivity : Activity
	{

		// put what my username is here
		public static string username;

		// put what opponent username is here
		public static string opponent;

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

			TextView[,] table = new TextView[8, 8];

			table[0,0] = FindViewById<TextView> (Resource.Id.ChessSquare00);
			table[0,1] = FindViewById<TextView> (Resource.Id.ChessSquare01);
			table[0,2] = FindViewById<TextView> (Resource.Id.ChessSquare02);
			table[0,3] = FindViewById<TextView> (Resource.Id.ChessSquare03);
			table[0,4] = FindViewById<TextView> (Resource.Id.ChessSquare04);
			table[0,5] = FindViewById<TextView> (Resource.Id.ChessSquare05);
			table[0,6] = FindViewById<TextView> (Resource.Id.ChessSquare06);
			table[0,7] = FindViewById<TextView> (Resource.Id.ChessSquare07);

			table[1,0] = FindViewById<TextView> (Resource.Id.ChessSquare10);
			table[1,1] = FindViewById<TextView> (Resource.Id.ChessSquare11);
			table[1,2] = FindViewById<TextView> (Resource.Id.ChessSquare12);
			table[1,3] = FindViewById<TextView> (Resource.Id.ChessSquare13);
			table[1,4] = FindViewById<TextView> (Resource.Id.ChessSquare14);
			table[1,5] = FindViewById<TextView> (Resource.Id.ChessSquare15);
			table[1,6] = FindViewById<TextView> (Resource.Id.ChessSquare16);
			table[1,7] = FindViewById<TextView> (Resource.Id.ChessSquare17);

			table[2,0] = FindViewById<TextView> (Resource.Id.ChessSquare20);
			table[2,1] = FindViewById<TextView> (Resource.Id.ChessSquare21);
			table[2,2] = FindViewById<TextView> (Resource.Id.ChessSquare22);
			table[2,3] = FindViewById<TextView> (Resource.Id.ChessSquare23);
			table[2,4] = FindViewById<TextView> (Resource.Id.ChessSquare24);
			table[2,5] = FindViewById<TextView> (Resource.Id.ChessSquare25);
			table[2,6] = FindViewById<TextView> (Resource.Id.ChessSquare26);
			table[2,7] = FindViewById<TextView> (Resource.Id.ChessSquare27);

			table[3,0] = FindViewById<TextView> (Resource.Id.ChessSquare30);
			table[3,1] = FindViewById<TextView> (Resource.Id.ChessSquare31);
			table[3,2] = FindViewById<TextView> (Resource.Id.ChessSquare32);
			table[3,3] = FindViewById<TextView> (Resource.Id.ChessSquare33);
			table[3,4] = FindViewById<TextView> (Resource.Id.ChessSquare34);
			table[3,5] = FindViewById<TextView> (Resource.Id.ChessSquare35);
			table[3,6] = FindViewById<TextView> (Resource.Id.ChessSquare36);
			table[3,7] = FindViewById<TextView> (Resource.Id.ChessSquare37);

			table[4,0] = FindViewById<TextView> (Resource.Id.ChessSquare40);
			table[4,1] = FindViewById<TextView> (Resource.Id.ChessSquare41);
			table[4,2] = FindViewById<TextView> (Resource.Id.ChessSquare42);
			table[4,3] = FindViewById<TextView> (Resource.Id.ChessSquare43);
			table[4,4] = FindViewById<TextView> (Resource.Id.ChessSquare44);
			table[4,5] = FindViewById<TextView> (Resource.Id.ChessSquare45);
			table[4,6] = FindViewById<TextView> (Resource.Id.ChessSquare46);
			table[4,7] = FindViewById<TextView> (Resource.Id.ChessSquare47);

			table[5,0] = FindViewById<TextView> (Resource.Id.ChessSquare50);
			table[5,1] = FindViewById<TextView> (Resource.Id.ChessSquare51);
			table[5,2] = FindViewById<TextView> (Resource.Id.ChessSquare52);
			table[5,3] = FindViewById<TextView> (Resource.Id.ChessSquare53);
			table[5,4] = FindViewById<TextView> (Resource.Id.ChessSquare54);
			table[5,5] = FindViewById<TextView> (Resource.Id.ChessSquare55);
			table[5,6] = FindViewById<TextView> (Resource.Id.ChessSquare56);
			table[5,7] = FindViewById<TextView> (Resource.Id.ChessSquare57);

			table[6,0] = FindViewById<TextView> (Resource.Id.ChessSquare60);
			table[6,1] = FindViewById<TextView> (Resource.Id.ChessSquare61);
			table[6,2] = FindViewById<TextView> (Resource.Id.ChessSquare62);
			table[6,3] = FindViewById<TextView> (Resource.Id.ChessSquare63);
			table[6,4] = FindViewById<TextView> (Resource.Id.ChessSquare64);
			table[6,5] = FindViewById<TextView> (Resource.Id.ChessSquare65);
			table[6,6] = FindViewById<TextView> (Resource.Id.ChessSquare66);
			table[6,7] = FindViewById<TextView> (Resource.Id.ChessSquare67);

			table[7,0] = FindViewById<TextView> (Resource.Id.ChessSquare70);
			table[7,1] = FindViewById<TextView> (Resource.Id.ChessSquare71);
			table[7,2] = FindViewById<TextView> (Resource.Id.ChessSquare72);
			table[7,3] = FindViewById<TextView> (Resource.Id.ChessSquare73);
			table[7,4] = FindViewById<TextView> (Resource.Id.ChessSquare74);
			table[7,5] = FindViewById<TextView> (Resource.Id.ChessSquare75);
			table[7,6] = FindViewById<TextView> (Resource.Id.ChessSquare76);
			table[7,7] = FindViewById<TextView> (Resource.Id.ChessSquare77);

			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					switch (chessboard [i, j].piece)
					{
					case ChessActions.chessman.Bishop:
						table[i,j].Text = "B ";
						break;
					case ChessActions.chessman.King:
						table[i,j].Text = "K ";
						break;
					case ChessActions.chessman.Knight:
						table[i,j].Text = "N ";
						break;
					case ChessActions.chessman.Pawn:
						table[i,j].Text = "P ";
						break;
					case ChessActions.chessman.Queen:
						table[i,j].Text = "Q ";
						break;
					case ChessActions.chessman.Rook:
						table[i,j].Text = "R ";
						break;
					default:
						table[i,j].Text = "  ";
						break;
					}
					//table[i,j].Text = chessboard [i, j].piece.ToString ();
					if (chessboard [i, j].colour == ChessActions.chessmanColour.black) {
						table [i, j].SetTextColor(Android.Graphics.Color.Cyan);
					} else if (chessboard [i, j].colour == ChessActions.chessmanColour.white) {
						table [i, j].SetTextColor(Android.Graphics.Color.White);
					}
				}
			}

		}


		protected override void OnCreate (Bundle savedInstanceState)
		{
			actions = new ChessActions (username, opponent);
			actions.login ();
			actions.newGame ();
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

			string MoveFrom;
			string MoveTo;

			moveButton.Click += (object sender, EventArgs e) => 
			{
				MoveFrom = fromMove.Text;
				MoveTo = toMove.Text;
				actions.move(chessBoard, MoveFrom[1] - '0', MoveFrom[0]-'A', MoveTo[1] - '0', MoveTo[0]-'A');
				printToTable(chessBoard);
				actions.printOnServer();
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
		}
	}
}

