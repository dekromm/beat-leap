using UnityEngine;
using System.Collections;

public class Navigable : MonoBehaviour {

	private GameObject select;

	private bool initialized;

	void Start () {
		if(!initialized){
			Init();
		}
	}

	virtual public void Select(){
		if(select!=null){
			select.SetActive(true);
		}else{
			Init();
		}
	}

	virtual public void Deselect(){
		select.SetActive(false);
	}

	virtual public void Action(){

	}

	virtual public void Init(){

		if(!initialized){
			Transform childSelectTransform = gameObject.transform.FindChild("selection");
			select = childSelectTransform.gameObject;
			Deselect();
			initialized = true;
		}
	}
}
