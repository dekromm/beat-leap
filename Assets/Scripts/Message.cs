using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour
{

	private TextMesh message;
	private Beat beat;
	
	// Use this for initialization
	void Start()
	{
		message = (TextMesh) gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(beat!=null){
			message.text = beat.getMessage();
			setColor();
		}
	}

	private void setColor()
	{

		if (message.text == Config.Messages.LikeAGod()) {
			message.color = Color.green;
		} else if (message.text == Config.Messages.Good()) {
			message.color = Color.yellow;
		} else if (message.text == Config.Messages.Async()) {			
			message.color = Color.red;
		} else if (message.text == Config.Messages.Miss()) {
			message.color = Color.red;
		}
	}

	public void setBeatReference(Beat beat){
		
		this.beat = beat;
	}
}