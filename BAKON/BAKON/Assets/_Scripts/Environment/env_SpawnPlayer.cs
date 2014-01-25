using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class env_SpawnPlayer : MonoBehaviour {

	public bool dead;
	public float waitDuration;
	public GameObject[] players;
	public Transform[] spawnPoints;
	public float[] spawnTimers;
	public env_Bakon bakon;

	// Use this for initialization
	void Start () {
		GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag ("Spawn_player");
		spawnPoints = new Transform[spawnObjects.Length];
		for (int i = 0; i < spawnObjects.Length; i++)
		{
			spawnPoints[i] = spawnObjects[i].transform;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (players.Length == 0 && GameObject.FindGameObjectsWithTag("Player").Length > 0)
		{
			players = GameObject.FindGameObjectsWithTag("Player");
			spawnTimers = new float[players.Length];
		}
		if (GameObject.FindGameObjectsWithTag ("Player").Length < players.Length)
		{
			for (int i = 0; i < players.Length; i++)
			{
				if (!players[i].activeSelf && spawnTimers[i] < Time.time)
				{
					List<Transform> availableSpawns = new List<Transform>(spawnPoints);
					foreach (Transform spawn in spawnPoints)
					{
						foreach (GameObject player in players)
						{
							if (player.transform.position == spawn.position)
							{
								availableSpawns.Remove (spawn);
								break;
							}
						}
					}
					int index = Random.Range (0, availableSpawns.Count -1);
					Transform playerSpawn = availableSpawns[index];
					players[i].transform.position = playerSpawn.position;
					players[i].GetComponent<ent_Player>().IsRespawning = false;
					players[i].SetActive(true);
				}
			}
		}
		foreach (GameObject p in players)
		{
			ent_Player player = p.GetComponent<ent_Player>();
			ent_Statistics stats = p.GetComponent<ent_Statistics>();
			if (!stats.IsAlive () && !player.IsRespawning)
			{
				dead = true;
				PlayerDeath(p);
			}
		}
	}

	void PlayerDeath(GameObject player)
	{
		player.SetActive (false);
		for (int i = 0; i < players.Length; i++)
		{
			if (players[i] == player)
			{
				ent_Player playerP = player.GetComponent<ent_Player>();
				ent_Statistics playerS = player.GetComponent<ent_Statistics>();
				playerP.IsRespawning = true;
				playerS.Health = playerS.MaxHealth;
				spawnTimers[i] = Time.time + waitDuration;
			}
		}
	}
}
