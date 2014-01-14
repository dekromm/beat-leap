using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour
{
	public GameObject beatPrefab;
	public Enemy enemyPrefab;
	public Item itemPrefab;
	public Money moneyPrefab;
	public GameObject timeLine;
	public TimeStick timeStickPrefab;
	public FlyingPoint pointPrefab; 

	public Material combo;
	public Material empty;
	public Material invincibility;
	public Material shield;
	public Material doubleJump;

	public static float TimeLineDelta()
	{
		return 7.0f; // 2 seconds length
	}

	public static class View
	{	
		public static float CubeScale()
		{
			return 10;
		}

		public static float GridLength()
		{
			return Config.View.CubeScale() * Config.Logic.GridLength();
		}

		public static float GridDepth()
		{
			return Config.View.CubeScale() * Config.Logic.GridDepth();
		}
		
	}

	public static class Logic
	{		
		public static int GridLength()
		{
			return 16;
		}

		public static int GridDepth()
		{
			return 8;
		}

		public static int InitialScore(){

			return 1000;
		}
	}

	public static class Direction
	{
		public static Vector2 Up()
		{
			return new Vector2(0, 1);
		}
				
		public static Vector2 Down()
		{
			return new Vector2(0, -1);
		}

		public static Vector2 Left()
		{
			return new Vector2(-1, 0);
		}
			
		public static Vector2 Right()
		{
			return new Vector2(1, 0);
		}
	}

	public static class Messages
	{

		public static string Miss()
		{
			return "MISS";
		}
		
		public static string Async()
		{
			return "ASYNC";
		}
		
		public static string Bad()
		{
			return "NOT GOOD AT ALL";
		}

		public static string Good()
		{	
			return "GOOD";
		}

		public static string LikeAGod()
		{
			return "LIKE A GOD";
		}

	}

	public enum Command
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		DAMAGE,
		MISS,
		NULL}
	;
}