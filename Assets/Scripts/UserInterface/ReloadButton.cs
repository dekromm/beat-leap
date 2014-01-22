using UnityEngine;
using System.Collections;

public class ReloadButton : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	
	}

	void OnMouseDown()
	{
		Application.LoadLevel(Game.Current().gameScene);
	}
}
