﻿using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	public Vector2 logicPosition;
	public Vector2 direction;
	
	private Vector3 direction3D;
	public Vector3  target;
	private float transitionTime;
	public float transitionTotalTime = 0.0f;
	
	private bool jumping;
	private float jumpTime;
	private float jumpSpeedFactor = 20f;
	
	// Makes the cube advance according to its policy
	// Returns its new position

	protected virtual void Start(){
		target = transform.localPosition;
	}

	void Update(){
		if (jumping) {
			jumpTime += Time.deltaTime;
			transform.localPosition = new Vector3(transform.localPosition.x,
			                                 Config.View.CubeScale()*Mathf.Sin(jumpTime*jumpSpeedFactor)/2f + Config.View.CubeScale()/2,
			                                 transform.localPosition.z);
			if(jumpTime>Mathf.PI/jumpSpeedFactor){
				jumping = false;
				transform.localPosition = new Vector3(transform.localPosition.x,Config.View.CubeScale()/2,transform.localPosition.z);
			}
		}
		if(target.x != transform.localPosition.x ||
		   target.z!= transform.localPosition.z){
			transitionTime += Time.deltaTime;
			if(transitionTime>=transitionTotalTime){
				transform.localPosition = target;
			} else {
				transform.localPosition += (Time.deltaTime / transitionTotalTime ) * direction3D;
			}
		}
	}
	public void Jump(){
		jumpTime = 0;
		jumping = true;
	}
	public Vector2 Move()
	{
		logicPosition += direction;
		UpdatePosition();
		return new Vector2(logicPosition.x, logicPosition.y);
	}
	
	public Vector2 Move(Vector2 direction)
	{
		logicPosition += direction;
		UpdatePosition();
		return new Vector2(logicPosition.x, logicPosition.y);
		/*SetDirection(direction.x, direction.y);
		return Move();*/
	}
	
	public void SetPosition(float x, float y)
	{
		logicPosition = new Vector2(x, y);
		UpdatePosition();
	}
	
	// TO-DO
	public void SetDirection(float x, float y)
	{
		// Controllo che possa permettere solo spostamenti interi
		if ((x % 1 == 0) && (y % 1 == 0)) {
			direction = new Vector2(x, y);
		} else {
			Debug.LogError("Direction Update FAILED");
		}
		return;
	}
	
	#region Monobehaviour implementation
	
	/*
 	* This region manages to translate logic state into visual state
	*/
	float scale;
	float halvedLength;
	float halvedDepth;
	// Use this for initialization
	void OnEnable()
	{
		// Optimization vars
		scale = Config.View.CubeScale();
		halvedLength = Config.View.GridLength() / 2;
		halvedDepth = Config.View.GridDepth() / 2;
		
	}
	
	void UpdatePosition()
	{
		float x, y, z;
		x = logicPosition.x * scale - halvedLength + scale / 2;
		//y = transform.localPosition.y;
		y = scale / 2f;
		z = logicPosition.y * scale - halvedDepth + scale / 2;
		direction3D = Config.View.CubeScale() * (new Vector3(direction.x, 0, direction.y) );
		//transform.localPosition = new Vector3(x, y, z);
		transitionTime = 0f;
		target = new Vector3(x, y, z);
	}
	#endregion
}
