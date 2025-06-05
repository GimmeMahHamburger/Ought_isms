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
	int arbitraryCounter;
	Vector2 lastPos;
	Vector2 thisPos;
	
	public override void _Ready(){
		arbitraryCounter=0;
	}
	public void addPoint(Vector2 input){
		arbitraryCounter=(arbitraryCounter+1)%3; //these are here to demonstrate that not all the build methods are mandatory
		if(arbitraryCounter==0){ //its a rather inefficient solution, though, so it still looks sketchy
			AddChild(TrailSegment.Create()
			.RadiusIs(radius)
			.Between(lastPos,thisPos)
			.WithSprite(GD.Load<Texture2D>("res://Sprites/PlayerSprites/Foot.png"))
			.Finish());
		} else if(arbitraryCounter==1){
			AddChild(TrailSegment.Create()
			.RadiusIs(radius)
			.Between(lastPos,thisPos)
			.Finish());
		} else if(arbitraryCounter==2){
			AddChild(TrailSegment.Create()
			.RadiusIs(radius)
			.Between(lastPos,thisPos)
			.WithSprite(GD.Load<Texture2D>("res://Sprites/Hort.png"))
			.Finish());
		}
		lastPos=thisPos;
		thisPos=input;
	}
	public override void _Process(double delta){
		//GD.Print(GetOverlappingAreas());
	}
}
