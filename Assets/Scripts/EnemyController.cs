using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public static EnemyController instance;
	public float speed;
	GameObject player;
	public GameObject shield;
	public float delay;
	public int rand;
	public bool move = true;
	public GameObject floatingText;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		instance = this;
	}

	// Update is called once per frame
	void Update ()
	{
		follow ();
	}

	void follow()
	{
		if (player != null)
		{
			if (move) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
			}
				
			transform.LookAt (player.transform);
		} 
	}
		

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "DontMove")
		{
			
			move = false;
		} 
		else
		{
			if (col.gameObject.tag == "Bullet")
			{
				Destroy (col.gameObject);
				GameManager.instance.increaseScore ();
				rand = Random.Range (1, 3);
				switch (rand) 
				{
				case 1:
					break;
				case 2:
				Instantiate (shield, new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
					break;
				case 3:
					break;
				}
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "DontMove" )
		{
			move = false;
		}
	}
		
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "DontMove")
		{
			move = true;
		}
	}
}

