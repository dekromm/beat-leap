using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	public Vector2 logicPosition;
	public Vector2 direction;

	// Makes the cube advance according to its policy
	// Returns its new position
	public Vector2 Move()
	{
		logicPosition += direction;
		UpdatePosition();
		return new Vector2(logicPosition.x, logicPosition.y);
	}
	
	public void SetPosition(float x, float y)
	{
		logicPosition = new Vector2(x, y);
		UpdatePosition();
	}

	// TO-DO
	public void SetDirection(float x, float y)
	{
		// Controllo che possa permettere solo spostamenti interi
		if((x%1 == 0) && (y%1 == 0)){
			direction = new Vector2(x, y);
		}else{
			Debug.LogError("Direction Update FAILED");
		}
		return;
	}

	#region Monobehaviour implementation
		
	/*
 	* This region manages to translate logic state into visual state
	*/
	float scale;
	float halvedLength;
	float halvedDepth;
	// Use this for initialization
	void OnEnable()
	{
		// Optimization vars
		scale = Config.View.CubeScale();
		halvedLength = Config.View.GridLength()/2;
		halvedDepth = Config.View.GridDepth()/2;
			
	}

	void UpdatePosition()
	{
		transform.position = new Vector3(logicPosition.x * scale - halvedLength+scale/2, scale/2, logicPosition.y * scale - halvedDepth+scale/2);
	}
	#endregion
}
