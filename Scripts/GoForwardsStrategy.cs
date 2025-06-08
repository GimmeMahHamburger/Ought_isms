using Godot;
using System;

public partial class GoForwardsStrategy : Node2D{
	Node2D? target;
	[Export]
	public EntityBase Parent;
	[Export]
	public float SPEED;
	MovementTranslator intermediate;
	public override void _Ready(){
		target=null;
		intermediate = GetParent() as MovementTranslator;
	}
	public void setTarget(Node2D newTarget){
		target=newTarget; 
	}
	public override void _Process(double delta){
		if(target!=null){
			float currentDirection=Parent.getCurrentDirection();
			intermediate.setIntendedVector(new Vector2((float)Math.Cos(currentDirection)*SPEED,(float)Math.Sin(currentDirection)*SPEED));
			intermediate.moveParent(); //changed to provide an intent instead of a product
			
			//Parent.ApplyCentralImpulse();
		}
	}
	
	
}
