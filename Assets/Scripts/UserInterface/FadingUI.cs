using UnityEngine;
using System.Collections;

public class FadingUI : MonoBehaviour {

	private static float visibleTime = 3.0f;
	private static float deltaAlfa = 0;
	private bool doneFading = false;

	// Use this for initialization
	void Start () {
		if (deltaAlfa == 0){
			deltaAlfa = 1/visibleTime;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!doneFading){
			Color color = gameObject.renderer.material.color;
			color.a -= deltaAlfa*Time.deltaTime;
			if(color.a < 0){
					//gameObject.SetActive(false);
					gameObject.renderer.enabled = false;
					doneFading = true;
			}
			gameObject.renderer.material.color = color;
		}
	}
}
