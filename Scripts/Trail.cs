using Godot;
using System;
//unused as of now
//didn't have time to pour into its development
//ideally leaves a trail of area2ds behind the player
//and if the player crosses over their own path, "does something"
//proportional to the angle (relative to perpendicular) of their approach
public partial class Trail : Area2D{
	//List<Vector2> points = new List<Vector2>();
	[Export]
	float radius;
	Vector2 lastPos;
	Vector2 thisPos;
	
	public override void _Ready(){
		
	}
	public void addPoint(Vector2 input){
		AddChild(TrailSegment.Create()
		.RadiusIs(radius)
		.Between(lastPos,thisPos)
		.WithSprite(GD.Load<Texture2D>("res://Sprites/PlayerSprites/Foot.png"))
		.Finish());
		lastPos=thisPos;
		thisPos=input;
	}
	public override void _Process(double delta){
		GD.Print(GetOverlappingAreas());
	}
}
