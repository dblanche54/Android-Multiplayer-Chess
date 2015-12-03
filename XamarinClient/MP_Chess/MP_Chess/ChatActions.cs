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
			try {
				sock.getOut().WriteLine(msg);
				sock.getOut ().Flush ();
			} catch (Exception e) {
			}
		}

		public string GetMsg(){
			try {
				sock.getOut ().WriteLine ("GET");
				sock.getOut ().Flush ();
				string value = sock.getIn ().ReadLine ();
				if (value == "")
					return value;
				else
					return value + "\n";
			} catch (Exception e) {
				return "";
			}
		}

	}
}

