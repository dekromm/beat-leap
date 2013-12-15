using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComboBoost : Rule{
	
	public int getBaseMultiplier(){
		
		return 2;
	}
	
	public override Rule Step(List<Cube> field, LevelMap map, Beat beat){
		Debug.Log ("ComboStep!");
		return this;
	}

}
