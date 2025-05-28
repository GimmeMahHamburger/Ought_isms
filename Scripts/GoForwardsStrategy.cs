using Godot;
using System;

public partial class GoForwardsStrategy : Node2D{
	Node2D? target;
	public EntityBase Parent;
	[Export]
	public float SPEED;
	public override void _Ready(){
		target=null;
		Parent = GetParent() as EntityBase;
	}
	public void setTarget(Node2D newTarget){
		target=newTarget; 
	}
	public override void _Process(double delta){
		if(target!=null){
			float currentDirection=Parent.getCurrentDirection();
			Parent.ApplyCentralImpulse(new Vector2((float)Math.Cos(currentDirection)*SPEED,(float)Math.Sin(currentDirection)*SPEED));
		}
	}
	
	
}
