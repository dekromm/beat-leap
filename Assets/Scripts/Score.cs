using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private TextMesh score;
	private Beat beat;

	// Use this for initialization
	void Start () {
	
		score = (TextMesh) gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(beat!=null)
			score.text = beat.getScore().ToString();
	}

	public void setBeatReference(Beat beat){
		
		this.beat = beat;
	}
}
