using Godot;
using System;

public partial class Npc : RigidBody2D{
	Node2D sight;
	BodySprite sprite;
	float currentDirection;
	public override void _Ready(){
		sight=GetNode("Sight") as Node2D;
		sprite=GetNode("BodySprite") as BodySprite;
		currentDirection=0.0f;
		(sight.GetNode("EyeBar/EyeSight") as EyeSight).EyeContact+=oops;
	}
	
	public void oops(){
		float temp1=(float)Math.Cos(currentDirection)*-50.0f;
		float temp2=(float)Math.Sin(currentDirection)*-40d.0f;
		ApplyImpulse(new Vector2(temp1,temp2));
	}
	
	public override void _Process(double delta){
		currentDirection+=0.01f;
		if(currentDirection>Math.PI){currentDirection=(float)Math.PI*-1;}
		sprite.currentDirection=currentDirection;
		
		sight.Rotation=currentDirection;
		
	}
}
