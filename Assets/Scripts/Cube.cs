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

}
