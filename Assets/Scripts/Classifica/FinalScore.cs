using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.IO;
using System;

public class FinalScore : MonoBehaviour {

	private TextReader reader;
	private List<int> intScores = new List<int>();
	private List<TextMesh> scores = new List<TextMesh>();
	private List<TextMesh> players = new List<TextMesh>();
	private TextMesh titoloTraccia;
	private int yourPosition;
	public GameObject form;
	public GameObject classifica;
	public GameObject bigScore;

	// Use this for initialization
	void Start () {


		//these 2 lines have to be removed (they're for debug)
		//Game.Current().SetLevel("zarro");
		//Game.Current().setScore(1000);
		
		TextMesh combo = GameObject.Find("Max Combo").GetComponent("TextMesh") as TextMesh;
		TextMesh accuracy = GameObject.Find("Accuracy").GetComponent("TextMesh") as TextMesh;
		combo.text = "Max Combo: " + Game.Current().MaxCombo();
		accuracy.text = "Accuracy : " + (100f * Game.Current().CatchedBeats() / Game.Current().Length()).ToString("F2");

		titoloTraccia = GameObject.Find("Titolo Traccia").GetComponent("TextMesh") as TextMesh;
		titoloTraccia.text = Game.Current().Level();
		
		Debug.Log("compilo la lista dei giocatori");
		for (int i=1; i<12; i++) {
			scores.Add( GameObject.Find("Score " + i).GetComponent("TextMesh") as TextMesh );
			players.Add( GameObject.Find("G" + i).GetComponent("TextMesh") as TextMesh );
		}
		LoadScores();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void LoadScores(){
		string level = Game.Current().Level();
		//TextAsset txt = (TextAsset)Resources.Load("Songs/"+level+"_Classifica" , typeof(TextAsset));	
		//string content = txt.text;

		WWW www;
		try{
			www = new WWW("http://beatleap.altervista.org/" + level + ".txt");
			//www = new WWW("file://" + Application.dataPath + "/Resources/Songs/asd.txt");
			while (!www.isDone) {
				}
			Debug.Log("error: " + www.error);
			if(www.error != null){
				classifica.SetActive(false);
				bigScore.SetActive(true);
				(bigScore.GetComponent("TextMesh") as TextMesh).text = Game.Current().Score().ToString();
			} else{
				Debug.Log("Contacted: " + www.text);
				string content = www.text;
				WriteScores(content);
			}
		} catch (Exception e) {
			Debug.LogError(e);
			classifica.SetActive(false);
			bigScore.SetActive(true);
			(bigScore.GetComponent("TextMesh") as TextMesh).text = Game.Current().Score().ToString();
		}
	}

	void WriteScores(string content){
		string line;
		int i = 0;
		yourPosition = 10;
		TextReader reader;
		reader = new StringReader(content);
		line = reader.ReadLine();
		while (line != null && i < 11) {
			if(line.Contains("@")){
				string[] slices = line.Split('@');
				//Debug.Log("pos." + i + " " + slices[0] + " " + slices[1]);
				if(int.Parse(slices[1])<Game.Current().Score() && yourPosition>i){
					yourPosition = i;
					players[i].text = ("YOU");
					scores[i].text = (Game.Current().Score().ToString());
					intScores.Add(Game.Current().Score());
					i++;
				}
				scores[i].text = (slices[1]);
				players[i].text = (slices[0]);
				intScores.Add(int.Parse(slices[1]));
				i++;
			}
			line = reader.ReadLine();
		}
		if (yourPosition == 10) {	// sei il primo a settare lo score o sei l'ultimo della classifica
			yourPosition = i;
			Debug.Log("you're: " + yourPosition);
			players [yourPosition].text = ("YOU");
			scores [yourPosition].text = (Game.Current().Score().ToString());
			intScores.Add(Game.Current().Score());
		}

		if (yourPosition < 10) { //yourposition = 10 -> undicesima posizione
			EnableSigning();
		}
	}

	void EnableSigning(){
		form.SetActive(true);
	}

	public void SignScore(string sign){
		players [yourPosition].text = sign;
		int i = 0;
		string classifica = "";
		while (i<10 && i < intScores.Count) { //puzza parecchio
			classifica += players[i].text + "@" + scores[i].text + "\n";
			i++;
		}
		Debug.Log(classifica);
		WWWForm postData = new WWWForm();
		postData.AddField("level",Game.Current().Level());
		postData.AddField("classifica",classifica);
		Debug.Log(postData.headers["level"]);
		Debug.Log(postData.headers["classifica"]);
		WWW scriviClassifica = new WWW("http://beatleap.altervista.org/classifica.php", postData);
		while (!scriviClassifica.isDone) {
		}
		Debug.Log(scriviClassifica.text);
	}

}
