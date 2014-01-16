using UnityEngine;
using System.Collections;

public class BeatFollower : MonoBehaviour {

	private static GameObject beat;

	void Start () {

	}
	
	void Update () {
		if(beat == null){
			beat = GameObject.Find("Beat") as GameObject;
		}
		if(beat!=null){
			if(!beat.transform.position.Equals(transform.position)){
				transform.position = beat.transform.position;
			}
		}
	}
}
