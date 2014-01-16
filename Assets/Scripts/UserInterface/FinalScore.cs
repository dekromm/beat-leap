﻿using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;

public class FinalScore : MonoBehaviour {

	private TextReader reader;
	private List<int> intScores = new List<int>();
	private List<TextMesh> scores = new List<TextMesh>();
	private List<TextMesh> players = new List<TextMesh>();
	private TextMesh titoloTraccia;
	private int yourPosition = 12;
	private int selectedLetter = 0;
	public GameObject form;
	// Use this for initialization
	void Start () {


		//these 2 lines have to be removed (they're for debug)
		//Game.Current().SetLevel("zarro");
		//Game.Current().setScore(1000);

		titoloTraccia = GameObject.Find("Titolo Traccia").GetComponent("TextMesh") as TextMesh;
		titoloTraccia.text = Game.Current().Level();

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
		TextAsset txt = (TextAsset)Resources.Load("Songs/"+level+"_Classifica" , typeof(TextAsset));	
		string content = txt.text;
		WriteScores(content);
	}

	void WriteScores(string content){
		string line;
		int i = 0;
		TextReader reader;
		reader = new StringReader(content);
		line = reader.ReadLine();
		while (line != null && i < 11) {
			if(line.Contains("@")){
				string[] slices = line.Split('@');
				scores[i].text = (slices[1]);
				players[i].text = (slices[0]);
				intScores.Add(int.Parse(slices[1]));
				//Debug.Log("pos." + i + " " + slices[0] + " " + slices[1]);
				if(intScores[i]<Game.Current().Score() && yourPosition>i){
					yourPosition = i;
					players[i].text = ("YOU");
					scores[i].text = (Game.Current().Score().ToString());
					intScores.Add(Game.Current().Score());
				} else {
					line = reader.ReadLine();
				}
				i++;
			}
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
		while (i<10 && i < intScores.Count-1) { //puzza parecchio
			Debug.Log(players[i].text + "@" + scores[i].text);
			i++;
		}
	}

}
