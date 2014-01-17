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
	public AudioSource snap;
	public AudioSource clap;
	public AudioSource explosion;
	public AudioSource shield;
	public AudioSource money;

	private bool powerupWasPlaying;
	
	void Start(){
		main = this;
		powerupWasPlaying = false;
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

	public void PlayClap(){
		clap.Play();
	}

	public void PlaySnap(){
		snap.Play();
	}

	public void PlayShield(){
		shield.Play();
	}

	public void PlayExplosion(){
		explosion.Play();
	}

	public void PlayMoney(){
		money.Play();
	}

	public void PauseResume(bool isGamePlaying){
		if(powerup.isPlaying && !isGamePlaying){
			powerupWasPlaying = true;
			powerup.Pause();
		}else if(isGamePlaying && powerupWasPlaying){
			powerupWasPlaying = false;
			powerup.Play();
		}
	}


}
