using UnityEngine;
using System.Collections;

public class FinalScore : MonoBehaviour {

	private TextMesh score;

	// Use this for initialization
	void Start () {

		score = (TextMesh) gameObject.GetComponent<TextMesh>();
		score.text = Game.Current().Score().ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
