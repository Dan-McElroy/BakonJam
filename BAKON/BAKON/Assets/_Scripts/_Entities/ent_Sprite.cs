using UnityEngine;
using System.Collections;

public class ent_Sprite : MonoBehaviour {
	
	protected ent_Statistics Statistics { get; set; }
	
	// Use this for initialization
	void Start () {
		Statistics = new ent_Statistics ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetStatistics(int health, int moveSpeed, float runMultiplier)
	{

		this.Statistics.SetHealth (health);
		this.Statistics.SetSpeed (moveSpeed);
		this.Statistics.SetMultiplier (runMultiplier);
	}
	
}
