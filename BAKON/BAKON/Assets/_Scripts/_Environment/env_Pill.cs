using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PillFunction {ChangeReality, SpeedUp, SlowDown, ReverseControls, BakonSnatch, Stun}

public class env_Pill : MonoBehaviour {

	public PillFunction function;
	public env_Level level;
	public env_SpawnPill spawner;
	public RealityState pillReality;

	private List<GameObject> effectTarget;
	private float originalValue;

	public float effectTimer = 3;
	private float effectInit;

	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Level").GetComponent<env_Level>();
		spawner = GameObject.FindGameObjectWithTag ("Level").GetComponent<env_SpawnPill> ();
		effectTarget = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (effectInit + effectTimer < Time.time)
		{
			switch (function)
			{
			case PillFunction.SpeedUp:
				effectTarget[0].GetComponent<ent_Statistics>().MoveSpeed *= 1/1.5f;
				break;
			case PillFunction.SlowDown:
				for (int i = 0; i < effectTarget.Count; i++)
				{
					effectTarget[i].GetComponent<ent_Statistics>().MoveSpeed *= 1.5f;
				}
				break;
			case PillFunction.Stun:
				for (int i = 0; i < effectTarget.Count; i++)
				{
					effectTarget[i].GetComponent<ent_Statistics>().MoveSpeed = 10;
				}
				break;
			default:
				spawner.DestroyPill(gameObject);
				break;
			}
			spawner.DestroyPill(gameObject);
		}
	}

	void Hide ()
	{
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			PerformFunction(coll.gameObject);
		}
	}

	void PerformFunction(GameObject caller)
	{
		switch (function)
		{
		case PillFunction.ChangeReality:
			AlterReality();
			break;
		case PillFunction.BakonSnatch:
			BakonSnatch();
			break;
		case PillFunction.SpeedUp:
			AffectAllSpeed(1.5f);
			break;
		case PillFunction.SlowDown:
			AffectAllSpeed(1/1.5f);
			break;
		case PillFunction.Stun:
			AffectAllSpeed(0);
			break;
		case PillFunction.ReverseControls:
			AffectAllSpeed(-1);
			break;
		default:
			spawner.DestroyPill (gameObject);
			break;
		}
	}

	void AlterReality()
	{
		level.currentReality = pillReality;
		level.OnRealityAltered();
		spawner.DestroyPill (gameObject);
	}

	void BakonSnatch()
	{
		env_Bakon bakon = GameObject.FindGameObjectWithTag ("Bakon").GetComponent<env_Bakon> ();
		bakon.Reset ();
		spawner.DestroyPill (gameObject);
	}

	void AffectAllSpeed(float multiplier)
	{
		effectTarget = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Player"));
		foreach (GameObject player in effectTarget)
		{
			originalValue = player.GetComponent<ent_Statistics>().MoveSpeed;
			player.GetComponent<ent_Statistics>().MoveSpeed *= multiplier;
		}
		effectInit = Time.time;
		Hide ();
	}
}
