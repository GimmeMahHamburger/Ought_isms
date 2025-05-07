using Godot;
using System;

public partial class PlayerMovement : RigidBody2D
{
	[Export]
	public double currentDirection = 0;
	Vector2 idealDir;
	bool MoveUp;
	bool MoveDown;
	bool MoveLeft;
	bool MoveRight;
	[Export]
	float SPEED = 20;
	Node2D SightLine;
	Node2D BodySprite;
	Hips hips;
	[Export]
	float rotSpeed;
	
	public override void _Ready(){
		SightLine = GetNode("Sightline") as Node2D;
		BodySprite = GetNode("BodySprite") as Node2D;
		hips = GetNode("Hips/Hips") as Hips;
		MoveRight = false;
		MoveLeft = false;
		MoveDown = false;
		MoveUp = false;
	}
	
	void rotateTowards(Vector2 dir){
		if(dir == new Vector2(0,0)){return;}
		
		double dirAngle = Math.Atan2(dir[1],dir[0]);
		double tempDiff = dirAngle-currentDirection;
		if(tempDiff>Math.PI){tempDiff-=2*Math.PI;}
		if(tempDiff<-Math.PI){tempDiff+=2*Math.PI;}
		if(tempDiff > Math.PI || (tempDiff < 0 && tempDiff > -Math.PI)){
			currentDirection += (Math.Abs(tempDiff)<0.5 || Math.Abs(tempDiff+Math.PI)>0.02)?rotSpeed:/*(rotSpeed*0.25)*/0;

		}
		if(tempDiff < -Math.PI || (tempDiff > 0 && tempDiff < Math.PI)){
			currentDirection -= (Math.Abs(tempDiff)<0.5 || Math.Abs(tempDiff-Math.PI)>0.02)?rotSpeed:/*(rotSpeed*0.25)*/0;

		}
		/*double delta = 0;
		if(Math.Abs(tempDiff)<2*Math.PI-Math.Abs(tempDiff)){
			delta = tempDiff;
		} else if (tempDiff>0){
			delta = tempDiff-2*Math.PI;
		} else {
			delta = Math.PI*2-tempDiff;
		}
		if(Math.Abs(delta)<0.06){return;}
		currentDirection+=0.05*Math.Sign(delta);
		*/
		//GD.Print(dirAngle);
		if(currentDirection>Math.PI){ currentDirection-=2*Math.PI;}
		if(currentDirection<-Math.PI){ currentDirection+=2*Math.PI;}
	}
	
	public override void _Input(InputEvent @event){
		Vector2 dir = new Vector2(0,0);
	
		if (@event.IsAction("MoveRight")){
			MoveRight = @event.IsPressed();
			
		} 
		if (@event.IsAction("MoveLeft")) {
			MoveLeft = @event.IsPressed();
			
		} 
		if (@event.IsAction("MoveUp")) {
			MoveUp= @event.IsPressed();
			
		} 
		if (@event.IsAction("MoveDown")) {
			MoveDown = @event.IsPressed();
			
		}
		
		dir[0]+= -(MoveRight?1:0) + (MoveLeft?1:0);
		dir[1]+= (MoveUp?1:0) - (MoveDown?1:0);
		idealDir=dir;
		
	}
	
	public override void _PhysicsProcess(double delta){
		
		Vector2 dir = new Vector2(0,0);/*
		if(Input.IsActionPressed("MoveRight")){
			dir[0]-=1;
			MoveRight = true;
		}
		if(Input.IsActionPressed("MoveLeft")){
			dir[0]+=1;
			MoveLeft = true;
		}
		if(Input.IsActionPressed("MoveUp")){
			dir[1]+=1;
			MoveUp= true;
		}
		if(Input.IsActionPressed("MoveDown")){
			dir[1]-=1;
			MoveDown = true;
		}
		*/
		//idealDir=dir;
		if(MoveDown || MoveUp ||MoveRight || MoveLeft){
			rotateTowards(idealDir);
			ApplyCentralImpulse(new Vector2((float)Math.Cos(currentDirection)*SPEED,(float)Math.Sin(currentDirection)*SPEED));
		}
		SightLine.Rotation = (float) currentDirection;
		hips.parentPos=Position;
		//BodySprite.spriteRotation = (float) currentDirection;
	}
}
