using UnityEngine;
using System.Collections;

public class StatsLoad : MonoBehaviour {

	public TextMesh score;
	public TextMesh totalBeats;
	public TextMesh gotBeats;
	public TextMesh maxCombo;


	void Start () {
		maxCombo.text = Game.Current().MaxCombo().ToString();
		totalBeats.text = Game.Current().Length().ToString();
		gotBeats.text = Game.Current().CatchedBeats().ToString();
		score.text = Game.Current().Score().ToString();
	}

}
