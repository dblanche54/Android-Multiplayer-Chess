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




namespace MP_Chess
{
	[Activity (Label = "MP Chess", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		public Socket socket;
		protected int portNum = 8080;
		protected String uname;
		protected String serverAddr;

		SocketSingleton sockInstance;

		ProgressDialog progress;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			sockInstance = new SocketSingleton ();

			// Get our UI controls from the loaded layout:
			EditText serverText = FindViewById<EditText>(Resource.Id.ServerText);
			EditText userText = FindViewById<EditText>(Resource.Id.UserText);

			Button connectButton = FindViewById<Button>(Resource.Id.ConnectButton);

			//Wire up the connnect button
			connectButton.Click += (object sender, EventArgs e) =>
			{
				

				serverAddr= serverText.Text;
				uname = userText.Text;

				new ClientThread().Start();
				/*
				// On "Connect" button click, try to connect to a server.
				progress = ProgressDialog.Show(this, "Loading", "Please Wait...", true); 

				Task.Factory.StartNew (
					// tasks allow you to use the lambda syntax to pass work
					() => {
						ConProcess();
					}
				).ContinueWith(t => {
					if (progress != null)
						progress.Hide();
					if(socket == null){
						//setError("Couldn't connect");
						var intent = new Intent(this, typeof(ChessActivity));
						StartActivity(intent);
					}else{
						setError("Connected");
					}

				}, TaskScheduler.FromCurrentSynchronizationContext()

				);*/
			};

		}

		protected static void initSingleton(){
			SocketSingleton.initSingleton ();
		}



		public abstract class BaseThread {
			private Thread _thread;

			protected BaseThread() { 
				_thread = new Thread(new ThreadStart(this.RunThread)); }
			
			public void Start() {
				_thread.Start ();
			}
			public void Join() { _thread.Join();}
			public bool isActive { get { return _thread.IsAlive; } }

		public abstract void RunThread();
	}

		public class ClientThread : BaseThread {
			
			public override void RunThread(){
				initSingleton ();
				Socket socket = SocketSingleton.getInstance ().getSocket ();

				while (true) {
					//Receive comms
				}
			}
		}

		private void setError(String str){
			TextView errorText = FindViewById<TextView>(Resource.Id.ErrorText);
			errorText.Text = str;
		}

		protected void ConProcess(){
			try{

				socket = new Socket(serverAddr, portNum);

			}catch(IOException ioe){
				setError( ioe.ToString());
			}
		}
	}
}



