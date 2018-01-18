#pragma strict

function Update () {
	if (PlayerPrefs.GetInt("Score") * -1 < gameObject.transform.position.y - 10) {
		Destroy (gameObject);
	}
}