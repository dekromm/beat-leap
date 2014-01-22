using UnityEngine;
using System.Collections;

public class SongTime : MonoBehaviour {

	private AudioSource audioSrc;
	private TextMesh min;
	private TextMesh sec;
	private int count;

	// Use this for initialization
	void Start () {
	
		audioSrc = GameObject.Find("Speaker").GetComponent ("AudioSource") as AudioSource;

		min = (TextMesh)GameObject.Find("min").GetComponent<TextMesh>();
		sec = (TextMesh)GameObject.Find("sec").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

		float time = audioSrc.time;
		if (time != 0) {
						min.text = ((int)(time / 60)).ToString ();
						sec.text = ((int)(time % 60)).ToString ("00");
				}

	
	}
}
