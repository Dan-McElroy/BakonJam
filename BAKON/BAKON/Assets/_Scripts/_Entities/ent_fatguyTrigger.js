#pragma strict
var animator : Animator;

function Start () {
	animator = GetComponent(Animator);
}

function Update () {

}

function OnTriggerEnter2D( coll : Collider2D){
	if(animator && coll.tag == "Bakon")
		{
				animator.SetTrigger("burp");
		}
}