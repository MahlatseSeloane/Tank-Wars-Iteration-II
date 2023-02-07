using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Text kills;
	public Text Instructions;
	public Text Health;
	public Text phases;

	public int scoreCounter;

	public int defense = 7;

	public bool gameplay;
	int c = 2;

	public float PhaseCounter;
	public int limit = 0;
	public float y;
	public int e = 30;

	// Use this for initialization
	void Start () 
	{
		instance = this;
	}

	void Update()
	{
		PhaseCounter += Time.deltaTime;

		int a = (int)(PhaseCounter);

		if(a == 3)
		{
			phases.text = " ";
		}

		if(a == e-2)
		{
			y = e - PhaseCounter;
			phases.text = "Phase " + c + "\nin " + y.ToString("F");
		}

		if(a == e-1)
		{
			y = e - PhaseCounter;
			phases.text = "Phase " + c + "\nin " + y.ToString ("F");
		}

		if(a == e)
		{
			limit = e;
			phases.text = " ";
			c++;
			e = e + 30;
		}

		switch (a) {
		case 0:
			Instructions.text = "Move forward by pressing the up arrow and move backwards by pressing the down arrow.\n"+"Rotate left or right by pressing the left and right arrow respectively";
			break;
		case 10:
			Instructions.text ="Time moves slow when you are standing still and moves normally when you move."+ "By positioning yourself at a particular position, you can make enemies kill" +
			" each other.";
			break;
		case 20:
			Instructions.text = "Sometimes when enemies die, they drop loot in the form of health.\n" + "if health has been collected, you can take 5 shots from enemies before dying.";
			break;
		case 30:
			Instructions.text = " ";
			break;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene ("Menu");
		}

		if(Input.GetKeyDown(KeyCode.R) && gameplay)
		{
			SceneManager.LoadScene ("Gameplay");
		}
			
	}

	public void increaseScore()
	{
		scoreCounter++;
		kills.text = "Kills: " + scoreCounter;
	}

	public void Immunity()
	{
		defense = 7;
		Health.text = "Health: " + defense;
	}

	public void DecreaseImmunity()
	{
		if(defense >= 1)
		{
			defense--;
		}
		Health.text = "Health: " + defense;
	}
}