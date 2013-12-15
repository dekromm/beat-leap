using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {



	public void PlayBad(){
		particleSystem.startColor = Color.black;
		particleSystem.Play();
	}

	public void PlayGood(){
		particleSystem.startColor = Color.yellow;
		particleSystem.Play();
	}

	public void PlayGod(){
		particleSystem.startColor = Color.green;
		particleSystem.Play();
	}

	public void FollowBeat(Vector3 beatPos){
		gameObject.transform.position = beatPos;
	}

}
