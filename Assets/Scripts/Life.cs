using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Life : MonoBehaviour {

	private List<GameObject> lifeIndicator;
	int life;
	private Beat beat;

	// Use this for initialization
	void Start () {

		lifeIndicator = new  List<GameObject>(Config.Logic.Life());
		GameObject gm;
		life = Config.Logic.Life();

		for(int i=1;i<life+1;i++){
			gm = GameObject.Find("LifeIndicator" + i.ToString());
			lifeIndicator.Add(gm);
		}
	}
	
	// Update is called once per frame
	void Update () {

		int beatLife = beat.getLife();

		if(life>beatLife){
			GameObject.Destroy(lifeIndicator[beatLife]);
			life--;
		}
	
	}

	public void setBeatReference(Beat beat){
		
		this.beat = beat;
	}
}
