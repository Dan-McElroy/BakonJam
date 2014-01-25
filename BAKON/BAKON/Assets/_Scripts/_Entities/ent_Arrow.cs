using UnityEngine;
using System.Collections;

public class ent_Arrow : MonoBehaviour {

	public float MoveSpeed = 10f;
	public Vector3 Direction = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 velocity = Vector3.Scale(Direction, new Vector3(MoveSpeed*Time.deltaTime, MoveSpeed*Time.deltaTime, 0f));
		this.transform.position += velocity;
	
	}

	void OnBecameInvisible () {
		ent_Statistics statistics = this.gameObject.GetComponent<ent_Statistics> ();
		statistics.Kill ();
	}
}
