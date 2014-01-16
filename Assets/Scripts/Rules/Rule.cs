using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Rule
{
			
	public abstract Rule Step(List<Cube> field, ref LevelMap map, ref Beat beat);
	public abstract void GetPointsFromMoney (Cube c, Beat beat);

	public static bool IsItem(Cube c)
	{
		//controlla se il cubo passato è un powerup
		return  c is Item;
	}

	public static bool IsMoney(Cube c)
	{
		//controlla se il cubo passato è un powerup
		return  c is Money;
	}
			
	public static bool IsEnemy(Cube c)
	{
		//controlla se il cubo passato è un powerup
		return c is Enemy;
	}

	public static bool IsDetonation(Rule r)
	{
		//controlla se il cubo passato è un powerup
		return r is Detonation;
	}
			
	protected void AddRows(LevelMap map, List<Cube> field)
	{
		List<Cube> tmpLine;
		Cube cube;
				
		try {
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
		} catch (Exception) {
		}
	}

	protected List<Cube> DestroyThemAll (List<Cube> field)
	{
		List<Cube> deleteList = new List<Cube>();
		
		foreach (Cube c in field) {
			if (IsEnemy(c)) {
				deleteList.Add(c);
				c.Recycle();
			}
		}
		
		foreach (Cube c in deleteList) {
			field.Remove(c);
		}

		return field;
	}
}

