using UnityEngine;
using System.Collections;

public class SoundEffectManager : MonoBehaviour {

	public static SoundEffectManager main;

	public AudioSource error;
	public AudioSource powerup;
	public AudioSource warn;
	public AudioSource powerupON;
	public AudioSource powerupOFF;
	public AudioSource destruction;
	public AudioSource hitEnemy;
	
	void Start(){
		main = this;
		//error.audio.volume = 0.5f;
	}

	public void PlayError(){
		error.Play();
	}

	public void PlayPoweupON(){
		powerupON.Play();
		powerup.Play();
	}
	public void PlayPoweupOFF(){
		powerupOFF.Play();
		powerup.Stop();
	}

	public void PlayWarn(){
		warn.Play();
	}

	public void PlayDestrucion(){
		destruction.Play();
	}

	public void PlayHit(){
		hitEnemy.Play();
	}


}
