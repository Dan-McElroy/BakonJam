#pragma strict

function Start () {

}

function Update () {

	if (Input.GetKeyDown ("space")){
			Application.LoadLevel(Application.loadedLevel);
	}
}