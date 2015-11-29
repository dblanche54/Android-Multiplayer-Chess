using System;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace MP_Chess
{
	public sealed class SocketSingleton
	{
		private static SocketSingleton instance;

		public static int SERVER_PORT;
		public static string SERVER_IP;

		public static TcpClient connection;

		public static StreamWriter outWriter;

		public static bool connected;

		public static StreamReader outReader;

		public SocketSingleton(){
		}

		public SocketSingleton(string serverAddr, int serverPort){
			if (serverAddr != null && serverPort != 0) {
				SERVER_IP = serverAddr;
				SERVER_PORT = serverPort;
			}
		}

		public static SocketSingleton getInstance(){
			if(instance == null)
				instance = new SocketSingleton();
			return instance;
		}

		public static void initSingleton(){
			if (instance == null) {
				instance = new SocketSingleton ();
				try{
					if(connection == null)
						instance.startSocket();
					outWriter = new StreamWriter(connection.GetStream());
					outReader = new StreamReader(connection.GetStream());


				//	clientSocket = new Java.Net.Socket(SERVER_IP,SERVER_PORT);
				}catch(System.IO.IOException e){
					//Print log?
					System.Console.WriteLine(e.ToString());
				}
			}
		}

		public bool isConnected(){
			/*
			// Detect if client disconnected
			if( connection.Client.Poll( 0, SelectMode.SelectRead ) )
			{
				byte[] b = new byte[1];
				if (connection.Client.Receive (b, SocketFlags.Peek) == 0) {
					// Client disconnected
					return true;
				} else {
					return false;
				}
			}
			return false; */
			return connected;
		}

		public void startSocket(){
		try{
			if (connection == null)
				if(SERVER_IP != null && SERVER_PORT > 0){
					connection = new TcpClient ();
					var result = connection.BeginConnect(SERVER_IP, SERVER_PORT, null, null);
					var done = result.AsyncWaitHandle.WaitOne(System.TimeSpan.FromSeconds(1));
					if(!done)
						connected = false;
					else
						connected = true;
				}
		//			clientSocket = new Java.Net.Socket(SERVER_IP,SERVER_PORT);
		//		outWriter = new StreamWriter(connection.GetStream());
			}catch(Exception e){
			}
		}

		public StreamWriter getOut(){
			return outWriter;
		}

		public StreamReader getIn(){
			return outReader;
		}
	}
}

