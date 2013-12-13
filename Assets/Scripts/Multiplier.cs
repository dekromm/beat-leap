using UnityEngine;
using System.Collections;

public class Multiplier : MonoBehaviour
{

	private TextMesh multiplier;
	private Beat beat;
	
	// Use this for initialization
	void Start()
	{
		multiplier = (TextMesh)gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update()
	{	
		if (beat != null) {
			multiplier.text = "x" + beat.getMultiplier().ToString();
		}
	}

	public void setBeatReference(Beat beat)
	{		
		this.beat = beat;
	}
}
