using UnityEngine;
using System.Collections;

public class BeatLight : MonoBehaviour {

	private bool hasToFlash;
	private bool hasFlashed;
	private float maxLight;

	private float speed;
	private float flashDuration;

	// Use this for initialization
	void Start () {

		hasToFlash = false;
		hasFlashed = false;
		maxLight = light.intensity;

		flashDuration = 0.1f;
		speed = maxLight/flashDuration;

		light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(hasToFlash && !hasFlashed){
			light.intensity = maxLight;
			hasFlashed = true;
		}

		if(hasToFlash && this.light){
			light.intensity -= Time.deltaTime * speed;
			if(light.intensity <= 0){
				hasToFlash = false;
			}
		}
	}

	public void Flash(){
		hasToFlash = true;
		hasFlashed = false;
	}
}
