/**This script is attached to the ball object
	 */ 

using System;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Collections;


	public class playercontroller : MonoBehaviour {

	public Text countText;
	public Text winText;
	private Rigidbody rb;
	static	private float moveVertical = 0.0f;
	static	private float moveHorizontal = 0.0f;
	private int y = 100; 
	private int up = 0;
	private int back = 0;
	private int left = 0;
	private int right = 0;
	private int count = 0;
	private string path = Directory.GetCurrentDirectory();

	// Use this for initialization called only once when the game starts
	void Start() {

		rb = GetComponent<Rigidbody> ();
		winText.text = "";
		countText.text = "Count : " + count.ToString ();
		Process compiler = new Process ();
		compiler.StartInfo.FileName = path + "\\..\\vs2013\\speech\\bin\\Debug\\speech.exe";
		compiler.StartInfo.UseShellExecute = false;
		compiler.StartInfo.RedirectStandardOutput = true; // redirecting the output od the speech file to get the command spoken by the user...
		compiler.StartInfo.CreateNoWindow = true;
		compiler.Start (); // starting the execution of the script...
		string var = compiler.StandardOutput.ReadToEnd ();
		compiler.Close ();

		Regex rgx = new Regex ("[^a-zA-Z0-9 -]"); // creating a regex to filter the newline introduced by the speech process while writing the string to the StandardOutput
		var = rgx.Replace (var, "");

		if (var == "You said up") {//string written to StandardOutput when user says "up"(ball moves up)
			moveVertical = 4.0f;
			up = 1;
		}
		if (var == "You said back") { //string written to StandardOutput by speech program when user says "back"(ball moves down)
			moveVertical = -4.0f;
			back = 1;
		}
		if (var == "You said east") {//string written to StandardOutput when user says "east"(ball moves right)
			moveHorizontal = 4.0f;
			right = 1;
		}
		if (var == "You said west") {//string written to StandardOutput when user says "west" (ball moves left)
			moveHorizontal = -4.0f;
			left = 1;
		}
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement);
	}//Start ends



	/** FixedUpdate is called once per frame.
	 * It regularly runs the speech.exe to check if the user has given any voice commands.
	 */
	void FixedUpdate() {
			y = y - 1;
			if(y == 0)
			{
				y = 100;
				Process compiler = new Process();
				compiler.StartInfo.FileName = path + "\\..\\vs2013\\speech\\bin\\Debug\\speech.exe";
				compiler.StartInfo.UseShellExecute = false;
				compiler.StartInfo.RedirectStandardOutput = true;
				compiler.StartInfo.CreateNoWindow = true;
				compiler.Start ();
				string var = compiler.StandardOutput.ReadToEnd();
				compiler.Close ();

				Regex rgx = new Regex("[^a-zA-Z0-9 -]");
				var = rgx.Replace (var,"");

				if (var == "You said up") {
					up = 1;
					back = 0;
					moveVertical = 4.0f;
					if (left == 1) {
						left = 2;
						right = 0;
					}
					else if(right == 1){
							right = 2;
							left = 0;
						}
				}
				
				if (var == "You said back") {
					up = 0;
					back = 1;
					moveVertical = -4.0f;
					if (left == 1) {
						left = 2;
						right = 0;
					}
					else if(right == 1){
							right = 2;
							left = 0;
						}
				}
				
				if (var == "You said east") {
					right = 1;
					left = 0;
					moveHorizontal = 4.0f;
					if (up == 1) {
						up = 2;
						back = 0;
					}
					else if(back == 1){
							back = 2;
							up = 0;
						}
				}
				
				if (var == "You said west") {
					right = 0;
					left = 1;
					moveHorizontal = -4.0f;
					if (up == 1) {
						up = 2;
						back = 0;
					}
					else if(back == 1){
							back = 2;
							up = 0;
						}
				}
			}//outer most if ends

			if (right == 2) {
				if (moveHorizontal >= 2.0f) {
					moveHorizontal = moveHorizontal - 0.01f;
				}
				else {
					right = 0;
					moveHorizontal = 0.0f;
				}
			}

			if (left == 2) {
				if (moveHorizontal <= 2.0f) {
					moveHorizontal = moveHorizontal + 0.01f;
				}
				else {
					left = 0;
					moveHorizontal = 0.0f;
				}
			}

			if (up == 2) {
				if (moveVertical >= 2.0f) {
					moveVertical = moveVertical - 0.01f;
				}
				else {
					up = 0;
					moveVertical = 0.0f;
				}
			}

			if (back == 2) {
				if (moveVertical <= 2.0f) {
					moveVertical = moveVertical + 0.01f;
				}
				else {
					back = 0;
					moveVertical = 0.0f;
				}
			}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement);
	}//FixedUpdate ends



	/** This function is called whenever ball collides with any other object in the game.
	 * The collided object is passed as parameter to this function and we compare the tag 
	 * of the object to check if the object is the pick-up cube. If yes than we increment our 
	 * count and display it. We also check if all the cubes have been collected.
	 */
		void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag ("Pick Up")) {
				count = count + 1;
				other.gameObject.SetActive (false);
				countText.text = "Count : " + count.ToString ();
				if (count >= 6) {
					winText.text = "YOU WIN!!!!";
				}
			}
		}

	}

