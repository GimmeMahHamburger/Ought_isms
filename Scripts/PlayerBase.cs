using Godot;
using System;

public partial class PlayerBase : EntityBase {
	[Export]
	float SPEED = 20;
	Node2D SightLine;
	Node2D Sight;
	BodySprite Sprite;
	Hips hips;
	Area2D marker;
	[Export]
	float rotSpeed;
	public override void _Ready(){
		//SightLine = GetNode("Sightline") as Node2D;
		Sprite = GetNode("BodySprite") as BodySprite;
		hips = GetNode("Hips/Hips") as Hips;
		Sight = GetNode("VisionLine") as Node2D;
		marker = GetNode("TrailMarker") as Area2D;
		(Sight.GetNode("EyeSight") as EyeSight).EyeContact+=temp;
		//(GetNode("PlayerMovementStrategy") as PlayerMovementStrategy).Parent=this;
		PlayerStatus.Status.playerInstance=this;
	}
	
	void temp(){
		PlayerStatus.Status.Ping(); //stand-in until playerstatus can more robustly handle damage requests
	}
	
	public override void _Process(double delta){
		//SightLine.Rotation = (float) currentDirection;
		Sight.Rotation = (float) currentDirection;
		hips.parentPos=Position; //make sure named children are rotated correctly *in spirit* and not *in value*
		
		Sprite.currentDirection = (float) currentDirection;
		marker.Rotation = (float) currentDirection;
	}
}
