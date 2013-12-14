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
		float stickSpeed;
		while(beats[position] < time+Config.TimeLineDelta()/2.0f){
			TimeStick stick = timeStickPrefab.Spawn();
			stickSpeed = TimeStick.distanceToRun/(2.0f*Mathf.Abs(beats[position] - time));
			stick.SetUpStick(stickSpeed);
			if(position < beats.Count -1){
				position++;
			}
		}
	}
}
