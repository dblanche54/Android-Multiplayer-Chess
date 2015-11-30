using System;

namespace MP_Chess
{
	public class ChatActions
	{

		//string messages;
		public SocketSingleton sock;

		public ChatActions ()
		{
			sock = SocketSingleton.getInstance ();
		}

		public void SendMsg(String msg){
			sock.getOut().WriteLine(msg);
			sock.getOut ().Flush ();
		}

		public string GetMsg(){
			sock.getOut().WriteLine("GET");
			sock.getOut ().Flush ();
			string value = sock.getIn ().ReadLine ();
			if (value == "")
				return value;
			else
				return value + "\n";
		}

	}
}

