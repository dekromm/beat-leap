using UnityEngine;
using System.Collections;

public class LevelNavigable : Navigable {

	public string levelName;
	public AudioSource source;

	void Start(){
		Init();
	}

	override public void Select(){
		source.clip = Resources.Load("Songs/" + levelName, typeof(AudioClip)) as AudioClip;
		base.Select();
		source.Play();
	}

	override public void Deselect(){
		base.Deselect();
		source.Stop();
	}
	
	override public void Action(){
		Game.Current().SetLevel(levelName);
		Application.LoadLevel(Game.Current().gameScene);
	}

	override public void Init(){
		source = (AudioSource) GameObject.Find("Speaker").GetComponent<AudioSource>();
		base.Init();
	}
}
