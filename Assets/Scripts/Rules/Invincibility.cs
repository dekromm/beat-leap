using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Invincibility : Rule{

	public override Rule Step(List<Cube> field, LevelMap map, Beat beat){
		Debug.Log ("Invincibbile!!");
		return this;
	}
}
