#pragma strict
var Highscore : UnityEngine.UI.Text;

function Update () {
	Screen.sleepTimeout = SleepTimeout.NeverSleep;
	Highscore.text = "H i g h s c o r e : " + PlayerPrefs.GetInt("Best").ToString();
}

function QuitGame ()  {
	Debug.Log ("Game is exiting...");
	Application.Quit ();
}

function MainMenu() {
	Application.LoadLevel("MainMenu");
	Time.timeScale = 1;
}

function PLAY() {
	Application.LoadLevel("Endless");
}