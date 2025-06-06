using Godot;
using System;

public partial class MovementTranslator : Node2D{ //only here right now as a test case
	protected Vector2 intent; //translating input to input, no change, while also just being a base class
	
	public virtual void setIntendedVector(Vector2 newIntent){
		intent=newIntent;
	}
	
	public virtual void moveParent(){
		(GetParent() as RigidBody2D).ApplyCentralImpulse(intent);
	}
	public override void _Process(double delta){
		moveParent();
	}
}
