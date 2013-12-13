using UnityEngine;
using System.Collections;

public class TimeStick : MonoBehaviour
{

	public static float deltaTime;
	public static Transform parent;
	public static float distanceToRun;
	private static float scaleIncrement;

	private float speed;

	void Start()
	{
		SetUpStick(distanceToRun/deltaTime);
	}

	public void SetUpStick(float speed){
		this.speed = speed;
		transform.parent = parent;
		transform.rotation = parent.rotation;
		transform.localPosition = new Vector3(TimeStick.distanceToRun/2, 0, 0);
		transform.localScale = new Vector3(1.0f, 3.5f, 0.1f);
		scaleIncrement = 0.5f;
	}

	void Update()
	{
		if (TimeLine.isActive) {
			float delta_x = speed * Time.deltaTime;

			transform.localPosition = new Vector3(transform.localPosition.x - delta_x, transform.localPosition.y, transform.localPosition.z);

			if (Mathf.Abs(transform.localPosition.x) < distanceToRun / 10.0f) {
				float increasingRate = Mathf.Abs(transform.localPosition.x / distanceToRun/10.0f);
				float increment = scaleIncrement * Mathf.Pow(increasingRate-1, 6);
				transform.localScale = new Vector3(transform.localScale.x, 3.5f + increment, transform.localScale.z);
			} else {
				transform.localScale = new Vector3(1.0f, 3.5f, 0.1f);
			}

			if (transform.localPosition.x < -distanceToRun / 2.0f) {
				this.Recycle();
			}
		}
	}
}