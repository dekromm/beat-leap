using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
		public Vector2 logicPosition;

		// Makes the cube advance according to its policy
		// Returns its new position
		public Vector2 Move ()
		{
				logicPosition = new Vector2 (logicPosition.x + 1, logicPosition.y);
				UpdatePosition ();
				return new Vector2 (logicPosition.x, logicPosition.y);
		}
	
		public void SetPosition (float x, float y)
		{
				logicPosition = new Vector2 (x, y);
				UpdatePosition ();
		}

		// TO-DO
		public void SetDirection (float x, float y)
		{
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
		void OnEnable ()
		{
				// Optimization vars
				scale = Config.View.CubeScale ();
				halvedLength = Config.View.GridLength ();
				halvedDepth = Config.View.GridDepth ();
			
		}

		void UpdatePosition ()
		{
				transform.position = new Vector3 (logicPosition.x * scale - halvedLength, 0, logicPosition.y * scale - halvedDepth);
		}
	#endregion
}
