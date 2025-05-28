using Godot;
using System;

public partial class FollowingNpc : EntityBase{
	VisionLine vision;
	BodySprite sprite;
	public override void _Ready(){
		vision = GetNode("VisionLine") as VisionLine;
		sprite = GetNode("BodySprite") as BodySprite;
		currentDirection=0.0f;
		(vision.GetNode("EyeSight") as EyeSight).EyeContact+=changeTarget;
	}
	public void changeTarget(){
		
		(GetNode("LookTowardsStrategy") as LookTowardsStrategy).setTarget(vision.collidingWith());
		(GetNode("GoForwardsStrategy") as GoForwardsStrategy).setTarget(vision.collidingWith());
	}
	public override void _Process(double delta){
		//if(currentDirection>Math.PI){currentDirection=(float)Math.PI*-1;}
		sprite.currentDirection=currentDirection;
		
		vision.Rotation=currentDirection;
	}
	
}
