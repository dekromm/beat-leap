using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	public Vector2 position;

	// Makes the cube advance according to its policy
	// Returns its new position
	public Vector2 Move ()
	{
		position = new Vector2 (position.x + 1, position.y);
		return new Vector2 (position.x, position.y);
	}

	#region Monobehaviour implementation
		
	/*
	 * This region manages to translate logic state into visual state
 	*/
	float scale;
	float halvedLength;
	float halvedDepth;
	// Use this for initialization
	void Start ()
	{
			scale = Config.View.CubeScale ();
			halvedLength = Config.View.GridLength ();
			halvedDepth = Config.View.GridDepth ();
	}
	
	// Update is called once per frame
	void Update ()
	{
			transform.position.x = position.x * scale - halvedLength;
			transform.position.z = position.x * scale - halvedDepth;
	}
	#endregion
}
