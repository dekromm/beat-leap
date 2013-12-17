using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	
	}

	void OnMouseDown()
	{
		Debug.Log("restart presed");
		Application.LoadLevel("Game");
	}
}
