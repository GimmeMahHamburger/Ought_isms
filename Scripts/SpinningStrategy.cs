using Godot;
using System;

public partial class SpinningStrategy : Node2D{
	public EntityBase Parent;
	float currentDirection = 0.0f;
	public override void _Ready(){
		Parent = GetParent() as EntityBase;
		
	}
	public override void _Process(double delta){
		Parent.setCurrentDirection(currentDirection);
		currentDirection+=0.01f;
		if(currentDirection>Math.PI){currentDirection-=(float)Math.PI*2.0f;}
	}
}
