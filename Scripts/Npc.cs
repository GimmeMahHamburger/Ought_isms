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
		float temp2=(float)Math.Sin(currentDirection)*-40.0f; //just jump backwards to demonstrate two-way eye contact
		ApplyImpulse(new Vector2(temp1,temp2)); //boinggggg
	}
	
	public override void _Process(double delta){
		currentDirection+=0.01f; //you spin my head right round
		if(currentDirection>Math.PI){currentDirection=(float)Math.PI*-1;} //right round
		sprite.currentDirection=currentDirection; //like a record baby
		
		sight.Rotation=currentDirection; //when you go down down
		
	}
}
