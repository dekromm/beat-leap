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
		
	private const string baseUrl = "/Resources/Songs/";
	private const string beatUrl = "_Beats";

	private string extension = ".wav"; //al momento proviamo solo mp3, gestiremo in seguito altre estensioni

	private int index;
	private TextReader reader;
	
	//costruttore, a cui passare il solo nome della canzone (senza estensione)
	public BeatTimings(string src)
	{

		index = 0;

#if UNITY_IPHONE
		extension = ".mp3";
#endif
		Debug.Log(extension);

		SetTimestamps(src);
		Game.Current ().setLength (timeStamps.Count);

		deltaTime = 0.12f;
 
		audioSrc = GameObject.FindGameObjectWithTag("Speaker").GetComponent<AudioSource>();

//		WWW www = new WWW("file://" + Application.dataPath + "/Resources/Songs/" + src + extension);
//		audioSrc.clip = www.audioClip;


		audioSrc.clip = Resources.Load("Songs/" + src, typeof(AudioClip)) as AudioClip;
		//audioSrc.Play();
	}

	//legge da file i timestamp e li sistema nell'array
	private void SetTimestamps(string id)
	{
		songName += ""; // Si fottano i WARNING!
		float beatTimeValue;
		string beatString;

		TextAsset txt = (TextAsset)Resources.Load("Songs/"+id+beatUrl , typeof(TextAsset));		
		string content = txt.text;
		
		reader = new StringReader (content);

		//reader = new StreamReader(Application.dataPath + baseUrl + id + beatUrl);
		timeStamps = new List<float>();

		beatString = reader.ReadLine();

		while (beatString != null) {

			beatTimeValue = float.Parse(beatString, CultureInfo.InvariantCulture.NumberFormat);
			timeStamps.Add(beatTimeValue);
			beatString = reader.ReadLine();
		}	
	}

	//da chiamare quando il deltaTime rispetto al beat corrente è passato
	private bool Step()
	{
		index++;
		return true;
	}

	//controlliamo (ad ogni frame!) che il beat non sia già passato 
	public bool HasBeatPassed()
	{
		while (!IsOver()){
			if (audioSrc.time >= timeStamps [index] + deltaTime) 
				return Step();
			else
				return false;
		}
		Controller c = (Controller) GameObject.Find("Board").GetComponent("Controller");
		c.GameOver();

		return false;
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

	public bool IsOver(){
		if (index >= timeStamps.Count)
			return true;
		return false;
	}


}