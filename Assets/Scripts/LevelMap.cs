using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class LevelMap
{

	// Contiene le linee di mappa
	private List<string> map;
	private Vector2 direction;
	private int mapLength;
	private int lineSize;
	private int position;
	// Const CODE strings
	private const string UpCode = "UP";
	private const string DownCode = "DOWN";
	private const string LeftCode = "LEFT";
	private const string RightCode = "RIGHT";
	private const string okChar = "_eicdsm";
	private string trackFileName;
	// Prefabs
	static Enemy enemyPrefab;
	static Item itemPrefab;
	static Money moneyPrefab;

	public LevelMap(string track)
	{
		trackFileName = track + "_Map";
		position = 0;
		mapLength = 0;
		try {
			LoadMap();
		} catch (Exception e) {
			Debug.LogError(e.Message);
		}

		// initialize cube pools
		Config config = (Config)GameObject.Find("Config").GetComponent("Config");
		itemPrefab = config.itemPrefab;
		itemPrefab.CreatePool();
		enemyPrefab = config.enemyPrefab;
		enemyPrefab.CreatePool();
		moneyPrefab = config.moneyPrefab;
		moneyPrefab.CreatePool();
	}

	public List<Cube> GetNewLine()
	{

		if (position >= mapLength)
			throw new Exception("Reached End of Map");

		List<Cube> cubeList = new List<Cube>(lineSize);
		string currentLine = map [position];
		Cube cube;

		for (int i=0; i<lineSize; i++) {
			cube = CubeForChar(currentLine [i]);
			if (cube != null)
				cube.SetDirection(direction.x, direction.y);
			cubeList.Add(cube);
		}

		position++;

		return cubeList;
	}

	public int MapWidth()
	{
		return lineSize;
	}

	public Vector2 GetMapDirection()
	{
		return new Vector2(direction.x, direction.y);
	}

	#region privateMethods

	private Cube CubeForChar(char car)
	{
		Cube cube = null;
		switch (car) {

			case 'e':
				cube = enemyPrefab.Spawn();
				break;
			case 'm':
				cube = moneyPrefab.Spawn();
				break;
			case 'c':								//COMBO BOOST
				cube = itemPrefab.Spawn();
				Item itemC = (Item) cube;
				itemC.LoadRule( new ComboBoost());
				break;
			case 'd':								//DOUBLE MOVEMENT
				cube = itemPrefab.Spawn();
				Item itemD = (Item) cube;
				itemD.LoadRule( new DoubleMovement());
				break;
			case 's':								//SHIELD  - protezione contro gli ostacoli
				cube = itemPrefab.Spawn();
				Item itemS = (Item) cube;
				itemS.LoadRule( new Shield());
				break;
			case 'i':								//INVINCIBILITY - protezione sul beat (tempo)
				cube = itemPrefab.Spawn();
				Item itemI = (Item) cube;
				itemI.LoadRule( new Invincibility());
				break;
			default:
				cube = null;
				break;
		}

		return cube;
	}

	private void LoadMap()
	{
		//string basePath = "/Resources/Songs/";
		//StreamReader reader = new StreamReader(Application.dataPath + basePath + trackFileName);

		TextAsset txt = (TextAsset)Resources.Load("Songs/"+trackFileName , typeof(TextAsset));		
		string content = txt.text;

		TextReader txr = new StringReader (content);

	//	if (reader != null) {
		if(txr != null){
			//string parameterString = reader.ReadLine();
			string parameterString = txr.ReadLine();
			try {
				readParameters(parameterString);
			} catch (Exception) {
				throw;
			}

			map = new List<string>(mapLength);
			//string line = reader.ReadLine();
			string line = txr.ReadLine();

			while (line != null) {
				line = line.ToLower();
				if (OkLine(line) && map.Count <= mapLength) {
					map.Add(line);
				} else {
					Debug.LogError("Discarded Line: \"" + line + "\"");
				}
				line = txr.ReadLine();
			}

			mapLength = map.Count;
		} else {
			throw new Exception("File " + trackFileName + " do not Exist");
		}
	
	}

	private void readParameters(string parameterString)
	{
		if (parameterString == null) {
			throw new Exception("Map Parameters Format Error");
		}

		string [] parameters = parameterString.Split(' ');
		if (parameters.Length >= 2) {
			string lineSizeString = parameters [0];
			string mapLengthString = parameters [1];

			lineSize = int.Parse(lineSizeString);
			mapLength = int.Parse(mapLengthString);

			if (lineSize < 1 || mapLength < 1) {
				throw new Exception("Map Parameters Format Error");
			}
			if (parameters.Length == 2) {
				direction = new Vector2(-1, 0);
			} else {
				string dirString = parameters [2];
				if (dirString.Equals(UpCode)) {
					direction = Config.Direction.Up();
				} else if (dirString.Equals(DownCode)) {
					direction = Config.Direction.Down();
				} else if (dirString.Equals(LeftCode)) {
					direction = Config.Direction.Left();
				} else if (dirString.Equals(RightCode)) {
					direction = Config.Direction.Right();
				} else {
					throw new Exception("Unknow Direction");
				}
			}
			
			Debug.Log("Line size: " + lineSize + " | Map lenght: " + mapLength + " | Direction: " + direction);
		} else {
			throw new Exception("Map Parameters Format Error");
		}
	}

	private bool OkLine(string line)
	{

		if (line.Length != lineSize)
			return false;

		foreach (char c in line) {
			if (!okChar.Contains(c.ToString()))
				return false;
		}

		return true;
	}

#endregion
}
