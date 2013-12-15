using System;
using System.Collections;
using System.Collections.Generic;

		public abstract class Rule
{
	#region Beat aimed Methods
	
	public int getDamage(){
		return 1;
	}
	
	public int getMagnitude(){
		return 1;
	}
	
	public int getBaseMultiplier(){
		
		return 1;
	}
	#endregion
			
			#region GameField aimed Methods
			
	public abstract Rule Step (List<Cube> field, LevelMap map, Beat beat);
			
			
	public static bool IsItem(Cube c){
				//controlla se il cubo passato è un powerup
				return  c is Item;
			}
			
	public static bool IsEnemy(Cube c){
				//controlla se il cubo passato è un powerup
				return c is Enemy;
			}
			
			protected void AddRows(LevelMap map, List<Cube> field)
			{
				List<Cube> tmpLine;
				Cube cube;
				
				try{
					tmpLine = map.GetNewLine();
					
					int x = Config.Logic.GridLength();
					int y;
					for (y=0; y< tmpLine.Count; y++) {
						cube = tmpLine [y];
						if (cube != null) {
							cube.SetPosition(x, y);
							cube.gameObject.SetActive(false);
							field.Add(cube);
							
						}
					}
				}catch(Exception){
				}
				
			}
			
			#endregion
			
		}

