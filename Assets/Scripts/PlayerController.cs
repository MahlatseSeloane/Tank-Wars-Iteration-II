using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public float speed;
	public float rotAngle;
	public float trackAngle;

	public float normal;
	public float slowDownFactor;
	public int defense;

	bool start = false;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		movement ();
		rotation ();

		if (!start) {
			messingWithTime ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			messingWithTime ();
		} 
		else 
		{
			if (Input.GetKeyUp (KeyCode.DownArrow)) 
			{
				messingWithTime ();
			} 
		}
	}

	void movement()
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			Vector3 pos = transform.position;
			Vector3 velocity = new Vector3 (0f, 0f, speed * Time.deltaTime);
			pos += transform.rotation * velocity;
			transform.position = pos;
			normalTime ();
			start = true;
		}
		else {
			
			if (Input.GetKey (KeyCode.DownArrow)) 
			{
				Mathf.Clamp (transform.position.z, -50f, 50f);
				Mathf.Clamp (transform.position.x, -50f, 50f);
				Vector3 pos = transform.position;
				Vector3 velocity = new Vector3 (0f, 0f, -speed * Time.deltaTime);
				pos += transform.rotation * velocity;
				transform.position = pos;
				normalTime ();
				start = true;
			}
		}
	}

	void rotation()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0f, -rotAngle, 0f));
			trackAngle--;
		} else {
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (new Vector3 (0f, rotAngle, 0f));
				trackAngle++;
			}
		}
	}

	void messingWithTime()
	{
		Time.timeScale = slowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	void normalTime()
	{
	Time.timeScale = normal;
	Time.timeScale = Mathf.Clamp (Time.timeScale, 0f, 1f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Bullet") 
		{
			defense--;
			Destroy (col.gameObject);
			if (defense == 0) 
			{
				SceneManager.LoadScene ("Menu");
			} 
			else 
			{
				if(defense >= 1)
				{
					GameManager.instance.DecreaseImmunity();
				}
			}
		} 
		else 
		{
			if (col.gameObject.tag == "Shield")
			{
				GameManager.instance.Immunity ();
				Destroy (col.gameObject);
			} 
		}
	}
}
