using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class env_SpawnPill : MonoBehaviour {

	public GameObject[] prefabs;
	public GameObject[] pills;
	public Transform[] spawnPoints;
	public float[] spawnTimers;

	// Use this for initialization
	void Start () {
		// pills should point to the in-game pill objects
		//pillSpawn
		// note: spawnTimers should have size set in editor

		List<Transform> availableSpawns = new List<Transform> (spawnPoints);

		for (int i = 0; i < pills.Length; i++)
		{
			int index = Random.Range (0, availableSpawns.Count -1);
			pills[i] = (GameObject) Instantiate (prefabs[i], availableSpawns[index].position, Quaternion.identity);
			availableSpawns.RemoveAt(index);
		}
		print (availableSpawns.Count);

		for (int i = 0; i < spawnTimers.Length; i++)
		{
			spawnTimers[i] = Time.time + Random.Range (2, 7);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Pills").Length < pills.Length)
		{
			for (int i = 0; i < pills.Length; i++)
			{
				if (pills[i] == null && spawnTimers[i] < Time.time)
				{
					// pick an unused spawn point

					List<Transform> availableSpawns = new List<Transform>();
					for (int j = 0; j < spawnPoints.Length; j++)
					{
						bool empty = true;
						foreach (GameObject activePill in GameObject.FindGameObjectsWithTag("Pills"))
						{
							if (activePill.transform == spawnPoints[j])
								empty = false;
						}
						if (empty)
						{
							availableSpawns.Add (spawnPoints[j]);
						}
					}
					if (availableSpawns.Count > 0)
					{
						Transform newSpawn = availableSpawns[Random.Range(0, (availableSpawns.Count-1))];
						pills[i] = (GameObject) Instantiate(prefabs[i], newSpawn.position, Quaternion.identity);
					}
				}
			}
		}
	}

	public void DestroyPill(GameObject pill)
	{
		for (int i = 0; i < pills.Length; i++)
		{
			if (pills[i] == pill)
			{
				spawnTimers[i] = Time.time + Random.Range (2, 7);
			}
		}
		Destroy(pill);
	}
}
