using Godot;
using System;

public partial class TrailGenerator : Node2D {
	Vector2 oldPos;
	Trail trail;
	[Export]
	float maxDist;
	public override void _Ready(){
		trail = GetNode<Trail>("Decoupler/Trail");
	}
	void tooFar(){
		oldPos=GlobalPosition;
		//GD.Print("woah too far at");
		//GD.Print(oldPos);
		trail.addPoint(oldPos);
		
		
	}
	bool checkIfTooFar(){
		if(maxDist<oldPos.DistanceTo(GlobalPosition)){
			return true;
		}
		return false;
	}
	public override void _Process(double delta){
		
		if(checkIfTooFar()){tooFar();}
	}
}
