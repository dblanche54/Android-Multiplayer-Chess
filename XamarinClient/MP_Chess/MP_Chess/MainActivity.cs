using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Java.IO;
using Java.Net;
using Android.Content.PM;



namespace MP_Chess
{
	[Activity (Label = "MP Chess", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{

		/// <summary>Port number on the server.</summary>
		protected int portNum = 8080;

		/// <summary>My user name.</summary>
		protected String uname;

		/// <summary>Server Address.</summary>
		protected String serverAddr;

		/// <summary>Instance of the socket used to connect to server.</summary>
		public static SocketSingleton sockInstance;

		ProgressDialog progress;

		/// <summary>Handles connecting to the server and starting a game.</summary>
		void onConnecToServer(){
			EditText serverText = FindViewById<EditText>(Resource.Id.ServerText);
			EditText userText = FindViewById<EditText>(Resource.Id.UserText);
			EditText oppText = FindViewById<EditText> (Resource.Id.OpponentText);

			serverAddr= serverText.Text;
			uname = userText.Text;

			sockInstance = new SocketSingleton (serverAddr, 8080);
			SocketSingleton.initSingleton ();

			// On "Connect" button click, try to connect to a server.
			progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true); 

				if (progress != null)
					progress.Hide();
				if(!sockInstance.isConnected()){
					setError("Couldn't connect");
				}else{
					setError("Connected");
					Intent intent = new Intent(this,typeof(ChessActivity));
					ChessActions.socket = sockInstance;
					ChessActivity.username = userText.Text;
					ChessActivity.opponent = oppText.Text;
					ChessActivity.actions = new ChessActions (ChessActivity.username, ChessActivity.opponent);

					ChessActivity.actions.login ();
					string read = SocketSingleton.getInstance().getIn().ReadLine();
					if (read == "TRUE"){
						if (ChessActivity.actions.joinGame()) {
							ChessActivity.myTurn = false;
							ChessActivity.newGame = false;
							StartActivity(intent);
						} else {
							if(ChessActivity.actions.newGame ()) {
								ChessActivity.myTurn = true;
								ChessActivity.newGame = true;
								StartActivity(intent);
							}
							else
								setError("Username already in use for a game.");
						}
					} else {
						setError("Could not use username to login.");
					}
				}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button connectButton = FindViewById<Button>(Resource.Id.ConnectButton);

			//Wire up the connnect button
			connectButton.Click += (object sender, EventArgs e) =>
			{
				onConnecToServer();

			};

		}

		/// <summary>Fills in the error text box.</summary>
		private void setError(String str){
			TextView errorText = FindViewById<TextView>(Resource.Id.ErrorText);
			errorText.Text = str;
		}
	}
}



