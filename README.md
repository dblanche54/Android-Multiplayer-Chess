# Android-Multiplayer-Chess

CMPT 436 Final Project

Created by Daniel Blanche & Michal Luczynski

The two main components of this project are the Android App and a main server. 

The chess game was developed in Xamarin Studio and was targeted for the Android platform. It allows users to connect to a server and play a game against another opponent. During your turn, you can drag and drop your game pieces and the client will determine if it is a legal move. Legal moves are passed to the server which communicates with the oponnent and passes on the move. The client also has a chat feature for communicating with the other player. 

The server is coded in C# and handles all the communication between clients. This includes moves, game state, and chat messages. It is threaded in order to support multiple games between multiple clients. All communication is done using sockets.

To play a game, you must specify the IP address of the server you will be playing on so the game knows who to connect to. You will need to specify both you and your opponent's usernames are. The server will look for an open lobby for you to play in. A lobby will be created if there are no open ones.

If you created the lobby you will be set as the white player. If you join a game you will be set as the black player.

![Main Fragment](https://github.com/dblanche54/Android-Multiplayer-Chess/blob/master/Screenshots/Screenshot_2015-12-03-16-15-15.png?raw=true) ![Login Fragment](https://github.com/dblanche54/Android-Multiplayer-Chess/blob/master/Screenshots/Screenshot_2015-12-05-19-01-27.png?raw=true)
