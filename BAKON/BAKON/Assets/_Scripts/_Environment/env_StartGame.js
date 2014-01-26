#pragma strict

var hideGO : GameObject[];
var showGO : GameObject[];

function Start () {

}

function Update () {
	if (Input.GetKeyDown ("space")){
			print ("space key was pressed");
			
			for(var obj2:GameObject in showGO){
					obj2.SetActive(true);
			}	
			
			for(var obj:GameObject in hideGO){
					obj.SetActive(false);
			}
	}	
}