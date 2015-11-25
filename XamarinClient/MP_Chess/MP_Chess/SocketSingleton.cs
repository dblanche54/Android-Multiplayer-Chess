using System;

using Java.IO;
using Java.Net;

using System.Net;
using System.Net.Sockets;
using System.IO;


namespace MP_Chess
{
	public sealed class SocketSingleton
	{
		private static Java.Net.Socket clientSocket;
		private DataInputStream input;
		private DataOutputStream output;
		private static SocketSingleton instance;

		public static int SERVER_PORT;
		public static String SERVER_IP;

		public static TcpClient connection;

		public static StreamWriter outWriter;

		public static StreamReader outReader;

		public SocketSingleton(){
		}


		public SocketSingleton(String serverAddr, int serverPort){
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
				connection = new TcpClient (SERVER_IP, SERVER_PORT);
				outWriter = new StreamWriter(connection.GetStream());
				outReader = new StreamReader(connection.GetStream());
				try{
					clientSocket = new Java.Net.Socket(SERVER_IP,SERVER_PORT);
				}catch(System.IO.IOException e){
					//Print log?
					System.Console.WriteLine(e.ToString());
				}
			}
		}

		public Java.Net.Socket getSocket(){
			return clientSocket;
		}

		public bool isConnected(){
			if (clientSocket != null)
				return true;
			return false;
		}

		public void startSocket(){
			try{
				if(SERVER_IP != null && SERVER_PORT > 0)
					clientSocket = new Java.Net.Socket(SERVER_IP,SERVER_PORT);
				outWriter = new StreamWriter(connection.GetStream());
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

