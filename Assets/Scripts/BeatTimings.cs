using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class BeatTimings{

	public GameObject gameObject; // non necessariamente l'oggetto al quale è attaccato lo script

	private List<float> timeStamps;
	private AudioSource audioSrc;

	public float deltaTime;
	
	private const string baseUrl = "Assets/Songs/";
	private const string beatUrl = "_Beats.txt";
	private string extension = ".mp3"; //al momento proviamo solo mp3, gestiremo in seguito altre estensioni

	private int index;

	private StreamReader reader;

	//costruttore, a cui passare il solo nome della canzone (senza estensione)
	public BeatTimings(string src){

		index = 0;

		SetTimestamps(src);
		//deltaTime =           inizializzare il valore per l'intervallo di tempo

		audioSrc = gameObject.AddComponent<AudioSource>();
		audioSrc.clip = Resources.Load(baseUrl+src+extension) as AudioClip;

	}

	//legge da file i timestamp e li sistema nell'array
	private void SetTimestamps(string id){

		float beatTimeValue;
		string beatString;

		reader = new StreamReader(baseUrl+id+beatUrl);
		timeStamps = new List<float>();

		beatString = reader.ReadLine();

		while (beatString != null){

			beatTimeValue = float.Parse(beatString);
			timeStamps.Add(beatTimeValue);
			beatString = reader.ReadLine();

		}
	
	}

	//da chiamare quando il deltaTime rispetto al beat corrente è passato
	private void Step(){

		index++;

	}

	//controlliamo (ad ogni frame!) che il beat non sia già passato 
	public bool hasBeatPassed(){

		if (audioSrc.time > timeStamps[index] + deltaTime){
			Step();
			return true;
		}

		return false;

	}

	//restituisce un valore pari alla differenza del istante attuale con il beat corrente
	//GameMechanichs si occuperà di valutare modulo e segno, confrontando con un deltaTime noto
	public float GetAccuracy(){

		return audioSrc.time - timeStamps[index];

	}

	//metodo per fermare e riprendere la canzone
	// restituisce true, se l'audio è on
	public bool SwitchAudioPlayStop(){

		if(audioSrc.isPlaying){
		
			audioSrc.Stop();
			return false;
		}

		audioSrc.Play();
		return true;
	}

}