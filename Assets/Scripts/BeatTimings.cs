using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;

public class BeatTimings
{

	public GameObject gameObject; // non necessariamente l'oggetto al quale è attaccato lo script

	private List<float> timeStamps;
	private AudioSource audioSrc;
	private string songName;   //nome della canzone da eseguire (senza estensione)

	public float deltaTime;
	private float timeToUpdate; //quanto manca al prossimo aggiornamento della view
	
	private const string baseUrl = "/Resources/Songs/";
	private const string beatUrl = "_Beats.txt";
	private string extension = ".wav"; //al momento proviamo solo mp3, gestiremo in seguito altre estensioni

	private int index;
	private StreamReader reader;
	
	//costruttore, a cui passare il solo nome della canzone (senza estensione)
	public BeatTimings(string src)
	{

		index = 0;

		SetTimestamps(src);
		deltaTime = 0.12f;
 
		audioSrc = GameObject.FindGameObjectWithTag("Speaker").GetComponent<AudioSource>();

		songName = baseUrl + src;

		WWW www = new WWW("file://" + Application.dataPath + "/Resources/Songs/" + src + extension);
		audioSrc.clip = www.audioClip;

		/*
		audioSrc.clip = Resources.Load(songName + extension) as AudioClip;*/
		//audioSrc.Play();
	}

	//legge da file i timestamp e li sistema nell'array
	private void SetTimestamps(string id)
	{
		songName += ""; // Si fottano i WARNING!
		float beatTimeValue;
		string beatString;

		reader = new StreamReader(Application.dataPath + baseUrl + id + beatUrl);
		timeStamps = new List<float>();

		beatString = reader.ReadLine();

		while (beatString != null) {

			beatTimeValue = float.Parse(beatString, CultureInfo.InvariantCulture.NumberFormat);
			timeStamps.Add(beatTimeValue);
			beatString = reader.ReadLine();
		}	
	}

	//da chiamare quando il deltaTime rispetto al beat corrente è passato
	private void Step()
	{

		index++;
		timeToUpdate = timeStamps [index] - deltaTime - audioSrc.time;  // set how much time for the next invocation of this metod
	
	}

	//controlliamo (ad ogni frame!) che il beat non sia già passato 
	public bool HasBeatPassed()
	{
		if (audioSrc.time >= timeStamps [index] + deltaTime) {

			Step();
			return true;
		}

		return false;
	}

	public float GetTimeToUpdate()
	{

		return timeToUpdate;
	}

	//restituisce un valore pari alla differenza del istante attuale con il beat corrente
	//GameMechanichs si occuperà di valutare modulo e segno, confrontando con un deltaTime noto
	//restituisco -1 se sono completamente fuori tempo
	public float GetAccuracy()
	{

		float accuracy = audioSrc.time - timeStamps [index];
		accuracy = Math.Abs(accuracy);

		if (accuracy < deltaTime)
			return accuracy;

		return -1;

	}

	//metodo per fermare e riprendere la canzone
	// restituisce true, se l'audio è on
	public bool SwitchAudioPlayStop()
	{

		if (audioSrc.isPlaying) {
		
			audioSrc.Pause();
			return false;
		}

		audioSrc.Play();
		return true;
	}

	//metodo per mettere in muto la canzone
	// restituisce true, se l'audio è mute
	public bool SwitchAudioMuteOnOff()
	{
		
		if (audioSrc.mute) {
			
			audioSrc.mute = false;
			return false;
		}
		
		audioSrc.mute = true;
		return true;
	}

	public List<float> GetTimings(){
		return timeStamps; // sbagliato dovrei restituire una copia
	}

	public float GetTime(){
		return audioSrc.time;
	}


}