using Godot;
using System;

public partial class PlayerMovementStrategy : Node2D{
	public MovementTranslator Parent;

	Vector2 idealDir;
	bool MoveUp;
	bool MoveDown;
	bool MoveLeft;
	bool MoveRight;
	[Export]
	float SPEED = 20;
	
	
	public override void _Ready(){
		Parent = GetParent() as MovementTranslator;
		MoveRight = false;
		MoveLeft = false;
		MoveDown = false;
		MoveUp = false;
		
	}
	
	
	
	public override void _Input(InputEvent @event){
		Vector2 dir = new Vector2(0,0);
		if (@event.IsAction("MoveRight")){ MoveRight = @event.IsPressed(); } 
		if (@event.IsAction("MoveLeft")) { MoveLeft = @event.IsPressed(); } 
		if (@event.IsAction("MoveUp")) { MoveUp = @event.IsPressed(); } 
		if (@event.IsAction("MoveDown")) { MoveDown = @event.IsPressed(); }
		
		dir[0]+= -(MoveRight?1:0) + (MoveLeft?1:0); //the cleverness here is also attributed to the prof
		dir[1]+= (MoveUp?1:0) - (MoveDown?1:0);
		idealDir=dir.Normalized();
	}
	
	public override void _PhysicsProcess(double delta){
		
		//Vector2 dir = new Vector2(0,0);
		if(MoveDown || MoveUp ||MoveRight || MoveLeft){
			//GD.Print(Parent);
			Parent.setIntendedVector(idealDir*SPEED);
			Parent.moveParent();
			
			//Parent.ApplyCentralImpulse(new Vector2((float)Math.Cos(currentDirection)*SPEED,(float)Math.Sin(currentDirection)*SPEED));
		}
	
	}
}
