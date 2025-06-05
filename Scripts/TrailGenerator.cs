using Godot;
using System;

public partial class TrailGenerator : Node2D {
	Vector2 oldPos;
	Trail trail;
	Iterator iterator;
	[Export]
	float maxDist;
	public override void _Ready(){
		trail = GetNode<Trail>("Decoupler/Trail");
		iterator = GetNode<Iterator>("Decoupler/Iterator");
		iterator.setTarget(trail);
		trail.AreaEntered+=TrailEntered;
	}
	
	void TrailEntered(Area2D area){

		float temp=getCollisionAngle(area.GlobalPosition)-area.Rotation;
		GD.Print(temp);
		GD.Print(getCollisionAngle(area.GlobalPosition));
		GD.Print(area.Rotation);
		
		
	}
	
	void tooFar(){
		oldPos=GlobalPosition;
		trail.addPoint(oldPos);
	}
	bool checkIfTooFar(){
		if(maxDist<oldPos.DistanceTo(GlobalPosition)){
			return true;
		}
		return false;
	}
	float getCollisionAngle(Vector2 input){
		GD.Print("yayyyy");
		return iterator.findAngleTouching(input);
	}
	public override void _Process(double delta){
		
		if(checkIfTooFar()){tooFar();}
	}
}
