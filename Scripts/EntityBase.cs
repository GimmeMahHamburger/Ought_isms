using Godot;
using System;

public partial class EntityBase : RigidBody2D {
	protected float currentDirection;
	public override void _Ready(){
		currentDirection=0.0f;
		
	}
	public void setCurrentDirection(float input){
		currentDirection = input;
		if(currentDirection>Math.PI){ currentDirection-=2*(float)Math.PI; }
		if(currentDirection<-Math.PI){ currentDirection+=2*(float)Math.PI; }
	}
	public float getCurrentDirection(){
		return currentDirection;
	}
}
