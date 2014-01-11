using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class AsynchVisualsEngine : MonoBehaviour {

	private List<float> blinks;
	private int blinksCount;
	private List<TimedText> warnings;
	private int warningsCount;

	private AudioSource reference;

	private Lampeggiante lampeggiante;

	void Start () {
		blinks = new List<float>();
		warnings = new List<TimedText>();
		blinksCount = 0;
		warningsCount = 0;

		reference = GameObject.Find("Speaker").GetComponent("AudioSource") as AudioSource;
		lampeggiante = GameObject.Find("Lampeggiante").GetComponent("Lampeggiante") as Lampeggiante;

		LoadData();
	}

	void Update () {
		if(reference!=null){
			float time = reference.time;
			CheckBlinks(time);
			CheckWarnings(time);
		}
	}

	public void SetTimeReference(AudioSource audioSrc){
		reference = audioSrc;
	}

	private void CheckBlinks(float time){
		if(blinks != null && blinks.Count > 0){
			while(blinksCount < blinks.Count-1 && blinks[blinksCount] < time){
				lampeggiante.Blink();
				SoundEffectManager.main.PlayWarn();
				blinksCount++;
			}
		}
	}

	private void CheckWarnings(float time){
		if(warnings != null && warnings.Count > 0){
			while(warningsCount < warnings.Count-1 && warnings[warningsCount].time < time){
				// mostra il testo
				SoundEffectManager.main.PlayWarn();
				warningsCount++;
			}
		}
	}

	private void LoadData(){
		TextReader reader;
		string level = Game.Current().Level();
		TextAsset txt = (TextAsset)Resources.Load("Songs/"+level+"_Asynch" , typeof(TextAsset));		
		string content = txt.text;
		string line;
		
		reader = new StringReader(content);
		line = reader.ReadLine();
		
		while (line != null){

			if(line.Contains("@")){
				string[] slices = line.Split('@');
				TimedText timedText = new TimedText();
				timedText.time = float.Parse(slices[0]);
				timedText.text = slices[1];
				warnings.Add(timedText);
			}else if(line.Contains("#")){
				string timeString = line.Replace("#","");
				float time = float.Parse(timeString);
				blinks.Add(time);
			}
			line = reader.ReadLine();
		}
	}
}
