using UnityEngine;
using System.Collections;

public class snd_Collider : MonoBehaviour {

	public string targetTag = "";
	public string soundName;
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == targetTag || targetTag == "")
		{
			print ( coll.gameObject.tag );
			snd_Manager.Instance.PlaySound(soundName);
		}
	}
}
