﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class GameField
{
	
		private LevelMap RtoLmap;
		private int width;
		private int height;
		private List<Cube> field;
		private Beat beat;
	
		public GameField (string track)
		{
			width = Config.Logic.GridLength();
			height = Config.Logic.GridDepth();
			field = new List<Cube>();

			try {
					// Right to Left map
					RtoLmap = new LevelMap (track);
					CheckCompliance ();
			} catch (Exception) {
					throw;
			}
		}
	
		public void StepUpdate ()
		{
				Vector2 nextPosition;

				foreach (Cube c in field) {
						nextPosition = c.Move ();
						if (Collided (c)) {
								// TO-DO collisione!
						} else if (IsOutOfField (nextPosition)) {
								c.Recycle ();
						}

				}
				AddRows ();

		}


	#region private methods
		private void AddRows ()
		{
				List<Cube> tmpLine;
				tmpLine = RtoLmap.GetNewLine ();

				int x = width;
				int y;
				for (y=0; y< tmpLine.Count; y++) {
						// tmpLine[y].setPosition(x,y);
						field.Add (tmpLine [y]);
				}

		}

		private void CheckCompliance ()
		{
			
				if (RtoLmap.MapWidth () != this.height)
						throw new Exception ("Map/Field height not compliant");
				// 
			
		}

		private bool IsOutOfField (Vector2 position)
		{

				if (position.x > this.width + 1)
						return true;
				if (position.y > this.height + 1)
						return true;
				if (position.x < -1)
						return true;
				if (position.y < -1)
						return true;

				return false;
		}

		private bool Collided (Cube c)
		{
				if (c.logicPosition.Equals (beat.logicPosition)) {
						return true;
				} else {
						return false;
				}
		}
	#endregion

}