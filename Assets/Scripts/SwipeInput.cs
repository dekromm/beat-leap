﻿using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour
{
	public float comfortZone = 70.0f;
	public float minSwipeDist = 14.0f;
	public float maxSwipeTime = 0.5f;
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;

	public enum SwipeDirection
	{
		None,
		Up,
		Down,
		Left,
		Right
	}
		
	public SwipeDirection lastSwipe = SwipeDirection.None;
	public float lastSwipeTime;

	Controller controller;
	
	void Start () {
		controller = GameObject.Find("Board").GetComponent<Controller>();
	}
		
	void  Update()
	{
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];

			switch (touch.phase) {
			
				case TouchPhase.Began:
					lastSwipe = SwipeDirection.None;
					lastSwipeTime = 0;
					couldBeSwipe = true;
					startPos = touch.position;
					startTime = Time.time;
					break;
						
				case TouchPhase.Moved:
//					if (Mathf.Abs(touch.position.x - startPos.x) > comfortZone) {
//						Debug.Log("Not a swipe. Swipe strayed " + (int)Mathf.Abs(touch.position.x - startPos.x) + 
//							"px which is " + (int)(Mathf.Abs(touch.position.x - startPos.x) - comfortZone) + 
//							"px outside the comfort zone.");
//						couldBeSwipe = false;
//					}
					break;
						
				case TouchPhase.Ended:
					if (couldBeSwipe) {
						float swipeTime = Time.time - startTime;
						float swipeDist = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
						Vector2 deltaPos = touch.position - startPos;
								
						if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) {

							if(Mathf.Abs(deltaPos.x/deltaPos.y) < 0.176f){
								if(deltaPos.y > 0){
									lastSwipe = SwipeDirection.Up;
									controller.gameMechanics.MoveUp();
								}else{
									lastSwipe = SwipeDirection.Down;
									controller.gameMechanics.MoveDown();
								}
							}else if(Mathf.Abs(deltaPos.y/deltaPos.x) < 0.176f){
								if(deltaPos.x > 0){
									lastSwipe = SwipeDirection.Right;
									controller.gameMechanics.MoveRight();
								}else{
									lastSwipe = SwipeDirection.Left;
									controller.gameMechanics.MoveLeft();
								}
							}
			
							lastSwipeTime = Time.time;
						}
					}
					break;
			}
		}			
	}
}
