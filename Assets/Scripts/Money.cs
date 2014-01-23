using UnityEngine;
using System.Collections;

public class Money : Cube {

	public int amount;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		amount = 1000;

	}


}
