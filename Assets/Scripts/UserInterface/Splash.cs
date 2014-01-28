using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	
	public GameObject collectiveLogo;
	public GameObject waveLogo;
	public GameObject mentezeroLogo;
	public GameObject sfondo;

	private bool sfuma;
	private float sfumaTime; 

	void Start () {
		Invoke("Wave",0.5f);
		sfuma = false;
		sfumaTime = 0.75f;
	}

	void Collective(){
		Blank();
		collectiveLogo.renderer.enabled = true;
		Invoke("Zero",2.0f);
	}
	
	void Wave(){
		Blank();
		waveLogo.renderer.enabled = true;
		Invoke("Collective",2.0f);
	}
	
	void Zero(){
		Blank();
		mentezeroLogo.renderer.enabled = true;
		Invoke("Sfuma",2.0f);
	}

	void Sfuma(){
		Blank();
		sfuma = true;
	}

	void Blank(){
		collectiveLogo.renderer.enabled = false;
		waveLogo.renderer.enabled = false;
		mentezeroLogo.renderer.enabled = false;
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
