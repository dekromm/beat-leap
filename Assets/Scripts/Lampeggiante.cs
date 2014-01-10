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
		} 
		if (hasToBlink && blinkCount < 0) {
			hasToBlink = false;
			renderer.enabled = false;
			Debug.Log(Time.deltaTime);
		}
	}

	public void Blink()
	{
		hasToBlink = true;
		blinkCount = blinkTime;
		Debug.Log("blink!");
	}
}
