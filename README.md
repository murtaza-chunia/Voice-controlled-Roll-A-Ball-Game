# Voice-controlled-Roll-A-Ball-Game

This is a simple roller ball game implemented in Unity 3D with voice recognition capability.
Player have to move and control the ball with voice commands like "up","back","east" and "west" and
collect all the objects in the scene.

Following are the steps to install the development environment required to run and build this game.

A]  Game building Environment Unity3D

	1] Download and Install Unity 3D 5.3.3f1 from this link: http://unity3d.com/get-unity/download?ref=personal
	2] Install with default selected components.



B]  Activate Speech recognition Sytem on your local machine(Steps for Windows PC)

	1] Open control panel.
	2] Click on Speech Recognition.
	3] Click on Setup microphone.
		- Select the type of Audio input device you want. (ex. headset) and follow the subsequent steps.
	4] Click on Start Speech Recognition and follow the subsequent steps.



C]  Development tools required for writing the voice recognition script are 

	1] Microsoft Visual studio Express 2013 for windows desktop 
		-Select the .exe file to download and install from this link: https://www.microsoft.com/en-us/download/details.aspx?id=44914
	2] Microsoft Speech Platform - software development kit(Version 11)(x64 and x86, download and install both the versions) 
		-from this link: https://www.microsoft.com/en-us/download/details.aspx?id=27226
	3] Microsoft Speech Platform - Runtime (version 11) (x64 and x86) 
		-from this link: https://www.microsoft.com/en-us/download/details.aspx?id=27225
	4] Microsoft Speech Platform - Runtime Languages (version 11)(download the en-us version) 
		-from this link: https://www.microsoft.com/en-us/download/details.aspx?id=27224
 


D]  Running the game

	1] Extract the dolby_project.zip file. It has two folders "firstgame" and "vs2013".
	2] Make sure that these two folders are in the same directory
	3] Open Unity3D and in that click "open" and select firstgame folder.
	4] Hit the play button.
		-Say "up" to move forward.
		-Say "back" to move back.
		-Say "east" to move right.
		-Say "west" to move left.
	5] Collect all the pick ups to win.
	6] If the ball does not move it means it is not processing the voice commands.
	7] Open the speech folder in vs2013 and in that double click on speech project.
		-build and run the project (click the play button) an see if it works without any error. If no error than blank console will be displayed.
			-it means the x64 version of microsoft.speech.dll works in our system.
		-If there is an error, message will be displayed on console and it means x64 version of microsoft.speech.dll is not supported.
			-remove this dll from the references in solution explorer window.
			-right click on reference and than add reference.
			-browse to the path C:\Program Files(x86)\Microsoft SDKs\Speech\v11.0\Assembly\microsoft.speech.dll
		    -Build and run the project again.
		    -Blank console will be displayed. Now speak any of these words "east","west","up","back" or "exit" it will display on console for a fraction of second and exit.
