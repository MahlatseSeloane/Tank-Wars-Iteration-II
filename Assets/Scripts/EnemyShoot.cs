using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	float range = 100f;
	public float delay;
	public Rigidbody bullet;
	public float force;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Shooting ();
	}

	void Shooting()
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, range)) 
		{
			if(hit.collider.name == "Player")
			{
				delay += Time.deltaTime;
				if(delay > 1f)
				{
					Rigidbody bulletInstance;
					bulletInstance = Instantiate (bullet, gameObject.transform.position, transform.rotation) as Rigidbody;
					bulletInstance.AddForce (transform.forward * force);
					delay = 0f;
				}
			}
		}
	}
}
