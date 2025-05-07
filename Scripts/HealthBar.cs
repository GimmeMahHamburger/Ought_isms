using Godot;
using System;

public partial class HealthBar : Sprite2D{
	public override void _Ready(){
		Scale=new Vector2(1.0f,2.0f);
	}
	public override void _Process(double Delta){
		float temp=(float)PlayerStatus.Status.healthValue/(float)PlayerStatus.Status.maxHealthValue; //simple health bar
		Scale = new Vector2(temp*5,1.0f);
	}
}
