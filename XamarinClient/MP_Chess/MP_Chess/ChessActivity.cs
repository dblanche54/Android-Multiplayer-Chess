
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
using Android.Content.PM;
using System.Threading;
using System.Timers;

namespace MP_Chess
{
	[Activity (Label = "ChessActivity", ScreenOrientation = ScreenOrientation.Portrait) ]			
	public class ChessActivity : Activity
	{

		// put what my username is here
		public static string username;

		// put what opponent username is here
		public static string opponent;

		// is it my turn?
		public static bool myTurn;

		//What type of connection are we making (new or join)
		public static bool newGame;

		public static ChessActions actions;

		public ChatActions chat;

		TextView txt; //Chat Display

		//Touch related vars
		int flipper = 0;				

		string MoveFrom;
		string MoveTo;


		ChessActions.gameSquare[,] chessBoard;

		public static TextView whoTurn;

		ImageView[,] table;


		protected override void OnCreate (Bundle savedInstanceState)
		{
			chat = new ChatActions ();


			// if you are creating the game, you are white player
			ChessActions.isWhite = newGame;

			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Chess);


			/**

			chatDisplay.SetOnTouchListener(new View.IOnTouchListener(){
				public  Boolean OnTouchEvent(MotionEvent ev){
					this.Parent.requestedi
					return (onTouchEvent)ev;
				}
			}
			*/

	//		TextView board = FindViewById<TextView> (Resource.Id.ChessBoard);

			// Make a chess board
			chessBoard = actions.generateDefaultBoard ();

			printToTable (chessBoard);
			//board.Text = actions.printBoard (chessBoard);

			actions.printOnServer ();

			/**
			 * 
			 * Test of updating Move from on touch. Right now only the left most
			 * white pawn will update the move from EditText.
			 * 
			 * Will have to looop through all elements of table and and MyOnTouch
			 * 
			 * Might have to  change IDs to something like A0 through H7 to simplify
			 * filling in the MoveTo and From boxes
			 */


			int i, j;
			for (i = 0; i < 8; i++) {
				for (j = 0; j < 8; j++) {
					table [i, j].LongClick += PieceLongClick;
					table [i, j].Drag += DropZone_Drag;
				}
			}
			txt = FindViewById<TextView> (Resource.Id.ChatDisplay);



			TextView headText = FindViewById<TextView> (Resource.Id.HeadText);
			if (!newGame) {
				headText.Text = "Playing " + opponent + ". You're Black.";
			} else {
				headText.Text = "Playing " + opponent + ". You're White.";

			}
			whoTurn = FindViewById<TextView> (Resource.Id.whoTurn);

			EditText msgText = FindViewById<EditText> (Resource.Id.MsgText);
			Button sendButton = FindViewById<Button> (Resource.Id.SendButton);
			sendButton.Click += (object sender, EventArgs e) => {
				chat.SendMsg (msgText.Text);
				//Send string to chat

				msgText.Text = "";
			};

			if (newGame == true) {
				whoTurn.Text = username + "'s Turn";
			} else {
				whoTurn.Text = opponent + "'s Turn";
			}


			/*
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
			};*/

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
				System.Environment.Exit(0);
			};

			// get updates
				System.Threading.ThreadPool.QueueUserWorkItem(delegate {
				//getUpdates (actions, chessBoard, whoTurn);
				while(true){
					RunOnUiThread(()=>getUpdates(actions, chessBoard, whoTurn));
					RunOnUiThread(()=>getMsg(chat, txt));
					System.Threading.Thread.Sleep (1000);
				}
				}, null);
			/**
			System.Threading.ThreadPool.QueueUserWorkItem(delegate {
				//getUpdates (actions, chessBoard, whoTurn);
				while(true){
					RunOnUiThread(()=>getMsg(chat));
					System.Threading.Thread.Sleep (1000);
				}
			}, null);*/
		}

		public static void OnServerFail(){
			

			whoTurn.Text = "Connection to server lost.";
			myTurn = false;

		}

		void PieceLongClick(object sender, View.LongClickEventArgs e){
			// Generate clip data package to attach it to the drag
			View v = (View)sender;
			var data = ClipData.NewPlainText("pos", Resources.GetResourceEntryName (v.Id));

			// Start dragging and pass data
			((sender) as ImageView).StartDrag(data, new View.DragShadowBuilder(((sender) as ImageView)), null, 0);
		}

		public void MyOnTouch(object sender, View.TouchEventArgs touchEventArgs){

			switch (touchEventArgs.Event.Action & MotionEventActions.Mask )
			{
			case MotionEventActions.Down:
				View v = (View)sender;
				string s = Resources.GetResourceEntryName (v.Id);
				if (flipper == 0) {
					MoveFrom = s;
					flipper++;
				} else {
					MoveTo = s;
					flipper--;
				}
				break;
			case MotionEventActions.Move:
				// Handle both the Down and Move actions.
				//message = "Touch Begins";
				break;
			case MotionEventActions.Up:
				//message = "Touch Ends";
				break;

			default:
				//message = string.Empty;
				break;
			}
		}

		public void DropZone_Drag (object sender, View.DragEventArgs e)
		{
			// React on different dragging events
			var evt = e.Event;

			switch (evt.Action) 
			{
			case DragAction.Ended:  
			case DragAction.Started:
				e.Handled = true;
				break;                
				// Dragged element enters the drop zone
			case DragAction.Entered:                   
				//result.Text = "Drop it like it's hot!";
				break;
				// Dragged element exits the drop zone
			case DragAction.Exited:                   
				//result.Text = "Drop something here!";
				break;
				// Dragged element has been dropped at the drop zone
				case DragAction.Drop:
				// You can check if element may be dropped here
				// If not do not set e.Handled to true
					e.Handled = true;

					View fromView = (View)sender;
					var data = e.Event.ClipData;
					
					if(myTurn){
					MoveFrom = data.GetItemAt(0).Text;
						MoveTo = Resources.GetResourceEntryName (fromView.Id);
						//txt.Text = Resources.GetResourceEntryName (fromView.Id) +data.GetItemAt(0).Text;

						MoveFrom = data.GetItemAt(0).Text;
						MoveTo =  Resources.GetResourceEntryName (fromView.Id);
						// Make sure parameter is valid
						if(actions.move(chessBoard, MoveFrom[1] - '0', MoveFrom[0]-'A', MoveTo[1] - '0', MoveTo[0]-'A'))
						{
							myTurn = false;
							whoTurn.Text = opponent + "'s Turn";
							printToTable(chessBoard);
							actions.printOnServer();
						}
						else 
						{
							MoveFrom = "A1";
							MoveTo = "A2";
						}
					}
					break;
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

		public void getMsg(ChatActions chat, TextView txt){

			//txt.Append( chat.GetMsg ());
			txt.Text = chat.GetMsg() + txt.Text;
		}

		public void printToTable(ChessActions.gameSquare[,] chessboard)
		{
			/*for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TextView tableSquare = FindViewById<TextView> (Resource.Id.ChessSquare + i + j);
				}
			}*/

			table = new ImageView[8, 8];

			table[0,0] = FindViewById<ImageView> (Resource.Id.A0);
			table[0,1] = FindViewById<ImageView> (Resource.Id.B0);
			table[0,2] = FindViewById<ImageView> (Resource.Id.C0);
			table[0,3] = FindViewById<ImageView> (Resource.Id.D0);
			table[0,4] = FindViewById<ImageView> (Resource.Id.E0);
			table[0,5] = FindViewById<ImageView> (Resource.Id.F0);
			table[0,6] = FindViewById<ImageView> (Resource.Id.G0);
			table[0,7] = FindViewById<ImageView> (Resource.Id.H0);

			table[1,0] = FindViewById<ImageView> (Resource.Id.A1);
			table[1,1] = FindViewById<ImageView> (Resource.Id.B1);
			table[1,2] = FindViewById<ImageView> (Resource.Id.C1);
			table[1,3] = FindViewById<ImageView> (Resource.Id.D1);
			table[1,4] = FindViewById<ImageView> (Resource.Id.E1);
			table[1,5] = FindViewById<ImageView> (Resource.Id.F1);
			table[1,6] = FindViewById<ImageView> (Resource.Id.G1);
			table[1,7] = FindViewById<ImageView> (Resource.Id.H1);

			table[2,0] = FindViewById<ImageView> (Resource.Id.A2);
			table[2,1] = FindViewById<ImageView> (Resource.Id.B2);
			table[2,2] = FindViewById<ImageView> (Resource.Id.C2);
			table[2,3] = FindViewById<ImageView> (Resource.Id.D2);
			table[2,4] = FindViewById<ImageView> (Resource.Id.E2);
			table[2,5] = FindViewById<ImageView> (Resource.Id.F2);
			table[2,6] = FindViewById<ImageView> (Resource.Id.G2);
			table[2,7] = FindViewById<ImageView> (Resource.Id.H2);

			table[3,0] = FindViewById<ImageView> (Resource.Id.A3);
			table[3,1] = FindViewById<ImageView> (Resource.Id.B3);
			table[3,2] = FindViewById<ImageView> (Resource.Id.C3);
			table[3,3] = FindViewById<ImageView> (Resource.Id.D3);
			table[3,4] = FindViewById<ImageView> (Resource.Id.E3);
			table[3,5] = FindViewById<ImageView> (Resource.Id.F3);
			table[3,6] = FindViewById<ImageView> (Resource.Id.G3);
			table[3,7] = FindViewById<ImageView> (Resource.Id.H3);

			table[4,0] = FindViewById<ImageView> (Resource.Id.A4);
			table[4,1] = FindViewById<ImageView> (Resource.Id.B4);
			table[4,2] = FindViewById<ImageView> (Resource.Id.C4);
			table[4,3] = FindViewById<ImageView> (Resource.Id.D4);
			table[4,4] = FindViewById<ImageView> (Resource.Id.E4);
			table[4,5] = FindViewById<ImageView> (Resource.Id.F4);
			table[4,6] = FindViewById<ImageView> (Resource.Id.G4);
			table[4,7] = FindViewById<ImageView> (Resource.Id.H4);

			table[5,0] = FindViewById<ImageView> (Resource.Id.A5);
			table[5,1] = FindViewById<ImageView> (Resource.Id.B5);
			table[5,2] = FindViewById<ImageView> (Resource.Id.C5);
			table[5,3] = FindViewById<ImageView> (Resource.Id.D5);
			table[5,4] = FindViewById<ImageView> (Resource.Id.E5);
			table[5,5] = FindViewById<ImageView> (Resource.Id.F5);
			table[5,6] = FindViewById<ImageView> (Resource.Id.G5);
			table[5,7] = FindViewById<ImageView> (Resource.Id.H5);

			table[6,0] = FindViewById<ImageView> (Resource.Id.A6);
			table[6,1] = FindViewById<ImageView> (Resource.Id.B6);
			table[6,2] = FindViewById<ImageView> (Resource.Id.C6);
			table[6,3] = FindViewById<ImageView> (Resource.Id.D6);
			table[6,4] = FindViewById<ImageView> (Resource.Id.E6);
			table[6,5] = FindViewById<ImageView> (Resource.Id.F6);
			table[6,6] = FindViewById<ImageView> (Resource.Id.G6);
			table[6,7] = FindViewById<ImageView> (Resource.Id.H6);

			table[7,0] = FindViewById<ImageView> (Resource.Id.A7);
			table[7,1] = FindViewById<ImageView> (Resource.Id.B7);
			table[7,2] = FindViewById<ImageView> (Resource.Id.C7);
			table[7,3] = FindViewById<ImageView> (Resource.Id.D7);
			table[7,4] = FindViewById<ImageView> (Resource.Id.E7);
			table[7,5] = FindViewById<ImageView> (Resource.Id.F7);
			table[7,6] = FindViewById<ImageView> (Resource.Id.G7);
			table[7,7] = FindViewById<ImageView> (Resource.Id.H7);

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
			if (ChessActions.endGame == true) {
				if (!myTurn) { // if you just moved
					whoTurn.Text = username + " wins";
					myTurn = false;
				} else {
					whoTurn.Text = opponent + " wins";
					myTurn = false;
				}
			}
		}
	}
}

