using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown()
	{
		Debug.Log("menu presed");
		Application.LoadLevel("Title");
	}
}
