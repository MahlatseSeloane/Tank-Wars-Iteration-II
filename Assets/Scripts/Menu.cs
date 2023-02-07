using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public float move;	
	public bool play;	
	public bool quit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 2f)
		{
			transform.Translate (new Vector3 (0f,move,0f));
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > 0f)
			{
				transform.Translate (new Vector3 (0f,-move,0f));
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && play)
		{
			Debug.Log ("Play");
			SceneManager.LoadScene ("Gameplay");
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.Space) && quit)
			{
				Debug.Log ("Quit");
				Application.Quit ();
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Play") 
		{
			play = true;
			quit = false;
		} 
		else 
		{
			if (col.gameObject.tag == "Quit") 
			{
				play = false;
				quit = true;
			} 
		}
	}
}
