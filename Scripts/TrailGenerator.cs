using Godot;
using System;

public partial class TrailGenerator : Node2D {
	Vector2 oldPos;
	Trail trail;
	Iterator iterator;
	[Export]
	float maxDist;
	public override void _Ready(){
		trail = GetNode<Trail>("Decoupler/Trail"); //decoupler's purpose is to keep children at a constant pos
		iterator = GetNode<Iterator>("Decoupler/Iterator"); //like the player's "ankles" do
		iterator.setTarget(trail);
		trail.AreaEntered+=TrailEntered;
	}
	
	void TrailEntered(Area2D area){

		float temp=getCollisionAngle(area.GlobalPosition)-area.Rotation; // i was gonna use the rotation diff
		//but ran out of time to meaninfully contribute to the punishment
		if(Math.Abs(temp)>1.5){
			PlayerStatus.Status.Ping();
			PlayerStatus.Status.Ping();
			PlayerStatus.Status.Ping();
			PlayerStatus.Status.Ping(); //gotta make it a little more punishing and noticeable
		} else {
			PlayerStatus.Status.Ping();
		}
		
		
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
		
		if(checkIfTooFar()){tooFar();} //just check
	}
}
