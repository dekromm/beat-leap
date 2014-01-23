using UnityEngine;
using System.Collections.Generic;

public class PauseScriptEnable : MonoBehaviour {

	private List<Navigable> navigableItems;

	void Start(){
		navigableItems = new List<Navigable>(gameObject.GetComponentsInChildren<Navigable>());
		Debug.Log(navigableItems.Count);
	}

	public void Show(){
		transform.position += new Vector3(0, -1000, 0);
		gameObject.SetActive(true);
		for(int i=0; i<navigableItems.Count;i++){
			navigableItems[i].enabled = true;
		}

	}

	public void Hide(){
		transform.position += new Vector3(0, 1000, 0);
		for(int i=0; i<navigableItems.Count;i++){
			navigableItems[i].enabled = false;
		}
		gameObject.SetActive(false);
	}

	public void Init(){
		Hide();
		transform.position += new Vector3(0, -1000, 0);
	}

}
