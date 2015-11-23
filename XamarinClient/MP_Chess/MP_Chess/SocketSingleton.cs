using System;

using Java.IO;
using Java.Net;

namespace MP_Chess
{
	public class SocketSingleton
	{
		private static Socket clientSocket;
		private DataInputStream input;
		private DataOutputStream output;
		private static SocketSingleton instance;

		public static int SERVER_PORT;
		public static String SERVER_IP;

		static PrintWriter outWriter;

		public SocketSingleton ()
		{
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

				try{
					clientSocket = new Socket(SERVER_IP,SERVER_PORT);
				}catch(IOException e){
					//Print log?
					System.Console.WriteLine(e.ToString());
				}
			}
		}

		public Socket getSocket(){
			return clientSocket;
		}

		public PrintWriter getOut(){
			return outWriter;
		}
	}
}

