using UnityEngine;
using System.Collections;

public class PreviewPlayer : MonoBehaviour {

	AudioSource audiosrc;
	string src;

	// Use this for initialization
	void Start () {

		audiosrc = (AudioSource) GameObject.Find("Speaker").GetComponent<AudioSource>();
		src = gameObject.name;	
	}

	void OnMouseEnter() {
		audiosrc.clip = Resources.Load("Songs/" + src, typeof(AudioClip)) as AudioClip;
		audiosrc.Play();	
	}

	void OnMouseExit() {
		audiosrc.Stop();	
	}
}
