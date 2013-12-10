using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeLine{

	private List<float> beats;
	public static bool isActive;
	private int position;
	private TimeStick timeStickPrefab;

	public TimeLine(List<float> timings) {
		Config config = (Config)GameObject.Find("Config").GetComponent("Config");

		TimeStick.deltaTime =  Config.TimeLineDelta();
		TimeStick.parent = config.timeLine.transform;
		TimeStick.distanceToRun = Config.View.GridLength();
		beats = timings;
		isActive = false;

		timeStickPrefab = config.timeStickPrefab; 
		timeStickPrefab.CreatePool();
	}

	public void FireSticks(float time){
		while(beats[position] < time+Config.TimeLineDelta()/2){
			TimeStick stick = timeStickPrefab.Spawn();
			stick.SetUpStick();
			// qui magari sarebbe intelligente posizionare lo stick per maggiore precisione
			position++;
		}
	}
}
