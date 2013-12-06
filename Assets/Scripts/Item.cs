using UnityEngine;
using System.Collections;

public class Item : Cube
{
	public Rule rule;
	
	// Power Enum
	public enum Power
	{
		Shield,
		Explosion,
		Other
	}
	public Power power;

}