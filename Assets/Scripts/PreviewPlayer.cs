using UnityEngine;
using System.Collections;

public class PreviewPlayer : MonoBehaviour {

	AudioSource audiosrc;
	string src;

	// Use this for initialization
	void Start () {

		audiosrc = (AudioSource) gameObject.GetComponent<AudioSource>();

		src = gameObject.name;

		audiosrc.clip = Resources.Load("Songs/" + src, typeof(AudioClip)) as AudioClip;
	
	}

	void OnMouseEnter() {
		audiosrc.Play();	
	}

	void OnMouseExit() {
		audiosrc.Stop();	
	}
}
