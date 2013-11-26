﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class LevelMap {

	// Contiene le linee di mappa
	private List<string> map;
	private Vector2 direction;

	private int mapLength;
	private int lineSize;
	private int position;

	private const string okChar = "wie";

	private string trackFileName;

	static Enemy enemyPrefab;
	static Item itemPrefab;

	public LevelMap(string track){
		trackFileName = track+"map.txt";
		position = 0;
		mapLength = 0;
		try{
			LoadMap();
		}catch(Exception e){
			Debug.LogError(e.Message);
		}

		// initialize cube pools
		Config config = (Config) GameObject.Find("Config").GetComponent("Config");
		itemPrefab = config.itemPrefab;
		itemPrefab.CreatePool();
		enemyPrefab = config.enemyPrefab;
		enemyPrefab.CreatePool();
	}


	public List<Cube> GetNewLine(){

		if(position >= mapLength)
			throw new Exception("Reached End of Map");

		List<Cube> cubeList = new List<Cube>(lineSize);
		string currentLine = map[position];
		Cube cube;

		for(int i=0; i<lineSize; i++){
			cube = CubeForChar(currentLine[i]);
			cubeList.Add(cube);
		}

		position++;

		return cubeList;
	}

	public int MapWidth(){
		return lineSize;
	}

	public Vector2 GetMapDirection(){
		return new Vector2(direction.x, direction.y);
	}

	#region privateMethods

	private Cube CubeForChar(char car){
		Cube cube = null;
		switch(car){
			case 'i':
				// Per ora non abbiamo item da istanziare
				cube = itemPrefab.Spawn();
				break;
			case 'e':
				cube = enemyPrefab.Spawn();
				break;
			default:
				cube = null;
				break;
		}

		return cube;
	}

	private void LoadMap(){
		StreamReader reader = new StreamReader(trackFileName);
		if(reader != null){
			string parameterString = reader.ReadLine();
			try{
				readParameters(parameterString);
			}catch(Exception){
				throw;
			}

			map = new List<string>(mapLength);
			string line = reader.ReadLine();

			while(line != null){
				line = line.ToLower();
				if( OkLine(line) && map.Count <= mapLength ){
					map.Add(line);
				}else{
					Debug.LogError("Discarded Line: \""+line+"\"");
				}
				line = reader.ReadLine();
			}

			mapLength = map.Count;
		}else{
			throw new Exception("File "+trackFileName+" do not Exist");
		}
	
	}

	private void readParameters(string parameterString){
		if(parameterString == null){
			throw new Exception("Map Parameters Format Error");
		}

		string [] parameters = parameterString.Split(' ');
		if(parameters.Length >=2){
			string lineSizeString = parameters[0];
			string mapLengthString = parameters[1];

			lineSize = int.Parse(lineSizeString);
			mapLength = int.Parse(mapLengthString);

			if(lineSize < 1 || mapLength < 1){
				throw new Exception("Map Parameters Format Error");
			}
			if(parameters.Length == 2){
				direction = new Vector2(-1,0);
			}else{
				int dirX, dirY;
				dirX = int.Parse(parameters[2]);
				dirY = int.Parse(parameters[3]);
				direction = new Vector2(dirX, dirY);
			}
			
			Debug.Log("Line size: "+lineSize+" | Map lenght: "+mapLength);
		}else{
			throw new Exception("Map Parameters Format Error");
		}
	}

	private bool OkLine(string line){

		if(line.Length != lineSize)
			return false;

		foreach (char c in line){
			if( !okChar.Contains(c.ToString()) )
				return false;
		}

		return true;
	}

#endregion
}
