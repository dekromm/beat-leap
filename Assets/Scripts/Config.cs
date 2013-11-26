using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour
{
	public Beat beatPrefab;
	public Enemy enemyPrefab;
	public Item itemPrefab;

		public static class View
		{	
				public static float CubeScale ()
				{
						return 10;
				}

				public static float GridLength ()
				{
						return Config.View.CubeScale () * Config.Logic.GridLength ();
				}

				public static float GridDepth ()
				{
						return Config.View.CubeScale () * Config.Logic.GridDepth ();
				}
		
		}

		public static class Logic
		{		
				public static int GridLength ()
				{
						return 17;
				}

				public static int GridDepth ()
				{
						return 9;
				}
		}
		
}