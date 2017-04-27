#pragma strict
private var isFalling = false;
var gravity : float = -50;
var canJump;
var stopdumbass;
var previousx;

function Start () {
	PlayerPrefs.SetFloat("Swing", 0);
	PlayerPrefs.SetFloat("isFalling", 0); 
	stopdumbass = false;
}

function Update () {
	//transform.Rotate(Vector3.right * PlayerPrefs.GetFloat("Swing"));
	GetComponent.<Rigidbody>().velocity.x = PlayerPrefs.GetFloat("Swing");
	GetComponent.<Rigidbody>().velocity.y += gravity * Time.deltaTime;
	
	Time.timeScale = PlayerPrefs.GetInt("paused");
	

	if (Input.GetMouseButtonDown(0)) {
		if (Input.mousePosition.x < (Screen.width / 2)) {
			PlayerPrefs.SetFloat("Swing", -4.0);
		}else if (Input.mousePosition.x >= (Screen.width / 2)) {
			PlayerPrefs.SetFloat("Swing", 4.0);
		}
	}else if (Input.GetMouseButtonDown(1)) {
		PlayerPrefs.SetFloat("Swing", 0);
	}
	previousx = transform.position.x;
}

function OnCollisionEnter (col : Collision) {
	if (col.collider.name == "spikes") {
		PlayerPrefs.SetInt("Score", 0);
		Application.LoadLevel("MainMenu");
		Time.timeScale = 1;
	}
}
