#pragma strict
import System.Collections.Generic;

var CTime : UnityEngine.UI.Text;
var HTime : UnityEngine.UI.Text;
var paused : boolean = false;
var Tpaused : GameObject;
var Ball : GameObject;
var cameras : GameObject;
var Sides : GameObject; // The Walls
var Score : int;
var setter : float; //para background
var Speeder : float = 1;

var MaxBlocks : int;
var BlockNumber : int;
var SpawnBlock : GameObject;
var AmountArray = new List.<float>();
var original : GameObject;
var YLocation : float;
var Rando : float;

function Start () {
	PlayerPrefs.SetInt("paused", 1);
	Time.timeScale = PlayerPrefs.GetInt("paused");
	YLocation = -2;
}

function Update () {
	//Score Stuff
	Score = Ball.transform.position.y * -1;
	CTime.text = " Current Score: " + Score;
	PlayerPrefs.SetInt("Score", Score);
	HTime.text = "High Score: " + PlayerPrefs.GetInt("Best");
	if(Score > PlayerPrefs.GetInt("Best")) {
		PlayerPrefs.SetInt("Best", Score);
	}

	if (PlayerPrefs.GetInt("paused") != 0) {
		Speeder = Speeder * 1.0001;
		cameras.transform.position.y = cameras.transform.position.y - .01 * Speeder;
		Sides.transform.position.y = Ball.transform.position.y;
	}
	
	if (Input.GetKeyDown("escape")) {
		if (PlayerPrefs.GetInt("paused") == 1) {
        	Debug.Log ("Pausing...");
            PlayerPrefs.SetInt("paused", 0);
            Time.timeScale = PlayerPrefs.GetInt("paused");
            Tpaused.SetActive (true);
        } else if (PlayerPrefs.GetInt("paused") == 0) {
        	Debug.Log ("Pausing...");
            PlayerPrefs.SetInt("paused", 1);
            Time.timeScale = PlayerPrefs.GetInt("paused");
            Tpaused.SetActive (false);
        }
	}

	var Amount = 8.0f;
	if (Ball.transform.position.y < YLocation + 15) {
		while (Amount > 0) { //CREATING THE BLOCKS
			Rando = (-27.0f + (Random.Range(0,9) * 6.0f)) / 4.0f; //MATH BIOTCH!!
			while (AmountArray.Contains(Rando)) {
				Rando = (-27.0f + (Random.Range(0,9) * 6.0f)) / 4.0f;
			}
			AmountArray.Add (Rando);
   			SpawnBlock = Instantiate(original, new Vector3 (Rando, YLocation, -.5),  Quaternion.identity);
   			BlockNumber++;
   			SpawnBlock.name = "Block #" + BlockNumber;
   			Amount--;
 		}
   	AmountArray.Clear();
	YLocation = (YLocation * 2.0 - 9.0) / 2.0f;
   	}
   	
	Time.timeScale = PlayerPrefs.GetInt("paused"); // Set pause or naw
}

function MainMenu() {
	Application.LoadLevel("MainMenu");
	paused = false;
	Time.timeScale = 1;
}
