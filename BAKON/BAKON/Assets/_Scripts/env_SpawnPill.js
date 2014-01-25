#pragma strict
var pills : Transform[];
var pillspawnpoints : GameObject[];
var nextspawn : float = 0;

function Start () {
	pillspawnpoints = GameObject.FindGameObjectsWithTag("Spawn_pill");
}

function Update () {
	if( GameObject.FindGameObjectsWithTag("Pills").Length<3){
		if (nextspawn<Time.time){
			
			nextspawn = Time.time + Random.Range(2,7);
		}else{
			//WORK OUT AT WITCH SPAWNPOINT TO SPAWN THE PILL


		}
	}
	
	
}