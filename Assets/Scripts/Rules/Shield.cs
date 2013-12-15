using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Rule{

	
	public override Rule Step(List<Cube> field, LevelMap map, Beat beat){
		Debug.Log ("Shielded!");
		return this;
	}
}
