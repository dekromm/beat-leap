using UnityEngine;
using System.Collections;

public static class Config
{
		public static class View
		{	
				public static float CubeScale ()
				{
						return 10;
				}

				public static float GridLength ()
				{
						return Config.View.CubeScale () * Config.Logic.GridLength;
				}

				public static float GridDepth ()
				{
						return Config.View.CubeScale () * Config.Logic.GridDepth ();
				}
		
		}

		public static class Logic
		{		
				public static float GridLength ()
				{
						return 17f;
				}

				public static float GridDepth ()
				{
						return 9f;
				}
		}
}