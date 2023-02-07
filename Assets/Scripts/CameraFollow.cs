using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public static CameraFollow instance;

	[SerializeField]
	Transform player1;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private Space offsetPosition = Space.Self;

	[SerializeField]
	private bool lookAt = true;

	public float normal;
	public float slowDownFactor;

	public float delay;
	public float limit;

	void Start()
	{
		instance = this;
	}

	private void Update()
	{
		Refresh ();
	}

	public void Refresh()
	{
		if (player1 != null)
		{
			if (offsetPosition == Space.Self)
			{
				transform.position = player1.TransformPoint (offset);
			}
			else 
			{
				transform.position = player1.position + offset;
			}


			if (lookAt) 
			{
				transform.LookAt (player1);
			}
			else 
			{
				transform.rotation = player1.rotation;
			}

		} 
	}
}
