using UnityEngine;
using System.Collections.Generic;



public class Navigation : MonoBehaviour {

	private List<Navigable> navigableItems;
	private Navigable selected;

	private bool verticalToggle;
	private bool enterToggle;

	private bool debug = false;

	void Start () {
		List<GameObject> navigableGameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Navigable"));
		navigableGameObjects.Sort(
			delegate(GameObject i1, GameObject i2){ 
				return i1.name.CompareTo(i2.name);
			}
		);
		Navigable tmp;
		navigableItems = new List<Navigable>();
		for(int i=0; i<navigableGameObjects.Count; i++){
			tmp = navigableGameObjects[i].GetComponent<Navigable>();
			navigableItems.Add(tmp);
		}

		if(debug){
			Debug.Log(navigableGameObjects.Count);
			Debug.Log(navigableItems.Count);
		}

		if(navigableItems.Count > 0){
			selected = navigableItems[0];
			selected.Init();
			selected.Select();
		}
	
		verticalToggle = false;
		enterToggle = true;
	}

	
	
	void Update () {

		if(Input.GetAxis("Vertical") == 0){
			verticalToggle = false;
		}
		if((Input.GetAxisRaw("Pause")==0 || !Input.GetButtonDown("JPause"))){
			enterToggle = false;
		}

		if(!verticalToggle && Input.GetAxis("Vertical")!=0){
			verticalToggle = true;
			if(Input.GetAxis("Vertical") > 0){
				Previous();
			}else if(Input.GetAxis("Vertical") < 0){
				Next();
			}
		}

		if(!enterToggle && (Input.GetAxisRaw("Pause")!=0 || Input.GetButtonDown("JPause"))){
			enterToggle = true;
			selected.Action();
		}
	}

	void OnEnable(){
		enterToggle = true;
	}

	private void Next(){
		if(navigableItems.Count > 1){
			if(selected != navigableItems[navigableItems.Count-1]){
				selected.Deselect();
				selected = navigableItems[navigableItems.IndexOf(selected)+1];
				selected.Select();
			}else{
				selected.Deselect();
				selected = navigableItems[0];
				selected.Select();
			}
		}
	}

	private void Previous(){
		if(navigableItems.Count > 1){
			if(selected != navigableItems[0]){
				selected.Deselect();
				selected = navigableItems[navigableItems.IndexOf(selected)-1];
				selected.Select();
			}else{
				selected.Deselect();
				selected = navigableItems[navigableItems.Count-1];
				selected.Select();
			}
		}
	}
}