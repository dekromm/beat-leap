using UnityEngine;
using System.Collections;

public class Lampeggiante : MonoBehaviour
{
	
	public float blinkTime = 0.075f;
	private bool hasToBlink;
	private float blinkCount;
	// Use this for initialization
	void Start()
	{
		hasToBlink = false;
	}


	// Update is called once per frame
	void Update()
	{
		if (hasToBlink) {
			this.renderer.enabled = true;
			blinkCount -= Time.deltaTime;
			Color newColor = gameObject.renderer.material.color;
			if(blinkCount > blinkTime/2){
				newColor.a = 2-2*blinkCount/blinkCount;
			}else{
				newColor.a = 2*blinkCount/blinkCount;
			}

			gameObject.renderer.material.color = newColor;

		} 
		if (hasToBlink && blinkCount < 0) {
			hasToBlink = false;
			renderer.enabled = false;
			Color newColor = gameObject.renderer.material.color;
			newColor.a = 0;
			gameObject.renderer.material.color = newColor;
			//Debug.Log(Time.deltaTime);
		}
	}

	public void Blink()
	{
		hasToBlink = true;
		blinkCount = blinkTime;
		Debug.Log("blink!");
	}
}
