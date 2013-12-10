using UnityEngine;
using System.Collections;

public class TimeStick : MonoBehaviour
{

	public static float deltaTime;
	public static Transform parent;
	public static float distanceToRun;
	private static float scaleIncrement;

	void Start()
	{
		SetUpStick();
	}

	public void SetUpStick(){
		transform.parent = parent;
		transform.position = new Vector3(80.0f, 58.0f, 4.0f);
		transform.localScale = new Vector3(0.00625f, 1.1f, 0.1f);
		scaleIncrement = 4.0f;
	}

	void Update()
	{
		if (TimeLine.isActive) {
			float delta_x = distanceToRun * Time.deltaTime / deltaTime;

			transform.position = new Vector3(transform.position.x - delta_x, transform.position.y, transform.position.z);

			if (Mathf.Abs(transform.position.x) < distanceToRun / 10.0f) {
				float increasingRate = 0.5f - Mathf.Abs(transform.position.x / (distanceToRun / 10.0f));
				float increment = scaleIncrement * Mathf.Pow(2 * increasingRate, 6);
				transform.localScale = new Vector3(transform.localScale.x, 1.1f + increment, transform.localScale.z);
			} else {
				transform.localScale = new Vector3(0.00625f, 1.1f, 0.1f);
			}

			if (transform.position.x < -distanceToRun / 2) {
				this.Recycle();
			}
		}
	}
}