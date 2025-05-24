using Godot;
using System;

public partial class SpinningNpc : EntityBase{
	VisionLine vision;
	BodySprite sprite;
	public override void _Ready(){
		vision = GetNode("VisionLine") as VisionLine;
		sprite=GetNode("BodySprite") as BodySprite;
		currentDirection=0.0f;
		(vision.GetNode("EyeSight") as EyeSight).EyeContact+=oops;
	}
	public override void _Process(double delta){
		currentDirection+=0.01f;
		if(currentDirection>Math.PI){currentDirection=(float)Math.PI*-1;}
		sprite.currentDirection=currentDirection;
		
		vision.Rotation=currentDirection;
	}
	public void oops(){
		float temp1=(float)Math.Cos(currentDirection)*-50.0f;
		float temp2=(float)Math.Sin(currentDirection)*-40.0f; //just jump backwards to demonstrate two-way eye contact
		ApplyImpulse(new Vector2(temp1,temp2)); //boinggggg
	}
}
