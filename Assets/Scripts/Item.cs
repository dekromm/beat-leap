using UnityEngine;
using System.Collections;

public class Item : Cube
{
	private static List<Item> ItemPool;
	
	// Power Enum
	public enum Power
	{
		Shield,
		Explosion,
		Other
	}
	public Power power;
	
	public static Item GetItem(){
		//implementare la pool!
		return null;
	}
	
	public static Item StoreItem(){
		//implementare la pool!
		return null;		
	}

}