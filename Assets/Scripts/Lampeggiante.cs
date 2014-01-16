using UnityEngine;
using System.Collections;

public class Lampeggiante : MonoBehaviour
{
	
	public float blinkTime = 4.0f;
	private bool hasToBlink;
	private float blinkCount;

	void Start()
	{
		hasToBlink = false;
	}


	void Update()
	{
		Color newColor = gameObject.renderer.material.color;
		if (hasToBlink) {
			blinkCount -= Time.deltaTime;
			if(blinkCount > blinkTime/2){
				newColor.a = 2-2*blinkCount/blinkTime;
			}else{
				newColor.a = 2*blinkCount/blinkTime;
			}

			gameObject.renderer.material.color = newColor;

		} 
		if (hasToBlink && blinkCount < 0) {
			hasToBlink = false;
			renderer.enabled = false;
			newColor.a = 0;
			gameObject.renderer.material.color = newColor;
		}
	}

	public void Blink()
	{
		this.renderer.enabled = true;
		hasToBlink = true;
		blinkCount = blinkTime;
	}
}
