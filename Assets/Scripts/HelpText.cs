using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	private TextMesh text;
	private float duration;
	private float time;

	void Start () {

		text = (TextMesh) gameObject.GetComponent<TextMesh>();
		text.text = " ";
		duration = 3.5f;
	}
	
	void Update () {
		if(time < duration){
			time +=Time.deltaTime;
		}else{
			if(gameObject.activeInHierarchy){
				gameObject.SetActive(false);
			}
		}
	}

	public void ShowHelpText(string txt){
		text.text = txt.Replace('&','\n');
		time = 0;
		gameObject.SetActive(true);
	}
}
