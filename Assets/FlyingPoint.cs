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
		//Debug.Log(scale);

		if(mat.color.a <= 0.0f){
			this.Recycle();
		}
	}

	public void SetStartingPoint(Vector3 pos){
		gameObject.transform.position = new Vector3(pos.x, pos.y + 25, pos.z);
	}

	public void SetScore(int score){
		string txtScore;
		Color txtColor;
		TextMesh text = gameObject.GetComponent<TextMesh>() as TextMesh;

		if(score>0){
			txtScore = "+"+score.ToString();
			txtColor = Color.green;
		}else{
			txtScore = "-"+score.ToString();
			txtColor = Color.red;
		}
	
		text.text = txtScore;
		text.color = txtColor;
	}
}
