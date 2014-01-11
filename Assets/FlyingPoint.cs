using UnityEngine;
using System.Collections;

public class FlyingPoint : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
		Material mat = this.renderer.material;
		float dt = Time.deltaTime;

		Color tmpColor = mat.color;
		tmpColor.a -= 1.0f * dt;
		mat.color = tmpColor;

		Vector3 tmpPos = transform.position;
		tmpPos.y +=  dt * 40.0f;
		transform.position = tmpPos;

		Vector3 tmpScale = transform.localScale;
		float scale = tmpScale.x- 0.5f* dt;
		tmpScale = new Vector3(scale, scale, scale);
		transform.localScale = tmpScale;
		Debug.Log(scale);

		if(mat.color.a <= 0.0f){
			this.Recycle();
			Debug.Log("MORTO");
		}
	}

	void SetStartingPoint(Vector3 pos){
		gameObject.transform.position = pos;
	}
}
