using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public static Spawner instance;
	public int PhaseCounter;
	public int limit;
	public GameObject Enemy;
	public int WhichPhase = 1;
	public int a = 2;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		PhaseCounter = Mathf.RoundToInt( GameManager.instance.PhaseCounter);
		limit = Mathf.RoundToInt( GameManager.instance.limit);

		WhichPhase = limit / 30;
		if (WhichPhase == a)
		{
			
			for(int i = 0; i < a;i++)
			{
				Instantiate (Enemy, transform.position + Vector3.right * i, Quaternion.identity);
			}
			a++;
		}
	}
}
