#pragma strict
var prevPos : Vector3;
var animator: Animator;

function Start () {
	

}

function Update () {
	var movSpeed : float = 0;
	movSpeed = Vector3.Distance(prevPos,transform.position);
	
	animator.SetFloat("MoveSpeed", movSpeed);
	
	//FLIP CHARACTER
	if(movSpeed>0.01){
		if(prevPos.x>transform.position.x ){
			//MOVING LEFT
			transform.localScale.x =Mathf.Abs(transform.localScale.x);
		}else{
			//MOVING RIGHT
			transform.localScale.x =Mathf.Abs(transform.localScale.x)*-1;
		}
	}
	
	prevPos=transform.position;
	
}