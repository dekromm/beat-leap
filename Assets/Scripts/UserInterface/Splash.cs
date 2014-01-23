using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	
	public GameObject collectiveLogo;
	public GameObject waveLogo;
	public GameObject sfondo;

	private bool sfuma;
	private float sfumaTime; 

	void Start () {
		Invoke("Collective",0.5f);
		sfuma = false;
		sfumaTime = 0.75f;
	}

	void Collective(){
		collectiveLogo.renderer.enabled = true;
		Invoke("Wave",2.0f);
	}

	void Wave(){
		waveLogo.renderer.enabled = true;
		collectiveLogo.renderer.enabled = false;
		Invoke("Sfuma",2.0f);
	}

	void Sfuma(){
		waveLogo.renderer.enabled = false;
		collectiveLogo.renderer.enabled = false;
		sfuma = true;
	}


	void Update(){
		if(sfuma){
			Color color = sfondo.renderer.material.color;
			color.a +=Time.deltaTime/sfumaTime;
			sfondo.renderer.material.color = color;
			if(color.a >=1){
				Application.LoadLevel("Main");
			}
		}

	}
}
