using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	private AudioSource song;
	private AudioClip audio;
	private float length;
	private float currentTime;

	private const float sizeX = 40;
	private float startOffset = 35;
	
	void Start () {
	
		song = GameObject.Find("Speaker").GetComponent ("AudioSource") as AudioSource;
		audio = Resources.Load("Songs/" + Game.Current().Level(), typeof(AudioClip)) as AudioClip;
		length = audio.length;
		startOffset = transform.position.x;
	}

	void Update () {

		currentTime = song.time;
		Vector3 old = gameObject.transform.position;
		gameObject.transform.position = new Vector3(GetX (),old.y,old.z);
	}

	private float GetX(){

		float ratio = currentTime / length;

		return ratio*sizeX + startOffset;
	}
}
