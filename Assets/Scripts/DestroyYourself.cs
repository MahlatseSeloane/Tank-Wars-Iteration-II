using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourself : MonoBehaviour {

	public float delay;
	public float limit;
	public float angle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		delay += Time.deltaTime;
		transform.Rotate (new Vector3(0f,angle,0f));

		if (delay > limit) 
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
