using UnityEngine;
using System.Collections;

public class HelpText : MonoBehaviour {

	private TextMesh text;
	//private OggettoIvanGestoreMessaggiVideo oigmv;

	// Use this for initialization
	void Start () {
	
		text = (TextMesh) gameObject.GetComponent<TextMesh>();
		//oigmv = (OggettoIvanGestoreMessaggiVideo) GameObject.FindGameObjectWithTag("OggettoIvanGestoreMessaggiVideo").GetComponent("OggettoIvanGestoreMessaggiVideo");

	}
	
	// Update is called once per frame
	void Update () {
	
		//text = oigmv.getText();

	}
}
