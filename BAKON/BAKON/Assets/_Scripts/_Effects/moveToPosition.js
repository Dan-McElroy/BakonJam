var delay : float = 0;
var speed :float  =  0.2f;
var from : float = -50;
var delaystart : boolean =  false;
var orignalposition : Vector3;

function Start(){
		orignalposition = transform.position;
}

function OnEnable() {
	delaystart = true;
}

function Update(){
	
	//orignalposition = transform.position;
	if(delaystart){
		transform.position = orignalposition;
		iTween.MoveFrom(gameObject,iTween.Hash(
										"position",Vector3(orignalposition.x,orignalposition.y-from,orignalposition.z),
										"time",0.5f,
										"delay",delay,
										"easetype","easeOutElastic",
										"islocal",true
		));							
		delaystart = false;
	}
}