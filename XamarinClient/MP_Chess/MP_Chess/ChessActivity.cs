
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
		public string username;

		// put what opponent username is here
		public string opponent;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			ChessActions actions = new ChessActions (SocketSingleton.getInstance (), username, opponent);
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Chess);

			TextView board = FindViewById<TextView> (Resource.Id.ChessBoard);

			// Make a chess board
			ChessActions.gameSquare[,] chessBoard = actions.generateDefaultBoard ();

			actions.move (chessBoard, 1, 1, 5, 5);

			board.Text = actions.printBoard (chessBoard);

			// Create your application here
			Button exitButton = FindViewById<Button>(Resource.Id.ExitButton);

			//Wire up the connnect button
			exitButton.Click += (object sender, EventArgs e) =>
			{
				Intent intent = new Intent(Intent.ActionMain);
				intent.AddCategory(Intent.CategoryHome);
				intent.SetFlags(ActivityFlags.NewTask);
				StartActivity(intent);
				Finish();
			};

			Button gridButton = FindViewById<Button>(Resource.Id.GridButton);

			//Wire up the connnect button
			gridButton.Click += (object sender, EventArgs e) =>
			{
				Intent intent = new Intent(this,typeof(Chessboard));
				StartActivity(intent);
			};
		}
	}
}

