using UnityEngine;
using System.Collections;

public class Item : Cube
{
	public Rule rule;
	public static Config config;

	// Power Enum
	public enum Power
	{
		Shield,
		Explosion,
		Other
	}
	public Power power;

	public void LoadRule(Rule rule)
	{
		//if (this.rule.GetType() != rule.GetType()) {
			if (rule is Invincibility) {
				renderer.material = config.invincibility;
			} else if (rule is ComboBoost) {
				renderer.material = config.combo;
			} else if (rule is Shield) {
				renderer.material = config.shield;
			} else if (rule is DoubleMovement) {
				renderer.material = config.doubleJump;
			} else if(rule is DefaultRule){
				renderer.material = config.empty;
			}
		//}
		this.rule = rule;
	}

}