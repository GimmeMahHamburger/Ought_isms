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
	Node2D Sight;
	BodySprite Sprite;
	Hips hips;
	[Export]
	float rotSpeed;
	
	public override void _Ready(){
		SightLine = GetNode("Sightline") as Node2D;
		Sprite = GetNode("BodySprite") as BodySprite;
		hips = GetNode("Hips/Hips") as Hips;
		Sight = GetNode("Sight") as Node2D;
		(Sight.GetNode("EyeBar/EyeSight") as EyeSight).EyeContact+=temp;
		MoveRight = false;
		MoveLeft = false;
		MoveDown = false;
		MoveUp = false;
	}
	
	void temp(){
		PlayerStatus.Status.healthValue-=1; //stand-in until playerstatus can more robustly handle damage requests
	}
	
	void rotateTowards(Vector2 dir){
		if(dir == new Vector2(0,0)){return;}
		
		double dirAngle = Math.Atan2(dir[1],dir[0]); //adapted from help from the prof (thanks man)
		double tempDiff = dirAngle-currentDirection; //ideally, just "rotate towards the right position"
		if(tempDiff>Math.PI){tempDiff-=2*Math.PI;} //but that was a complicated problem to solve
		if(tempDiff<-Math.PI){tempDiff+=2*Math.PI;}
		if(tempDiff > Math.PI || (tempDiff < 0 && tempDiff > -Math.PI)){
			currentDirection += (Math.Abs(tempDiff)<0.5 || Math.Abs(tempDiff+Math.PI)>0.02)?rotSpeed:/*(rotSpeed*0.25)*/0;

		}
		if(tempDiff < -Math.PI || (tempDiff > 0 && tempDiff < Math.PI)){
			currentDirection -= (Math.Abs(tempDiff)<0.5 || Math.Abs(tempDiff-Math.PI)>0.02)?rotSpeed:/*(rotSpeed*0.25)*/0;

		}
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
		
		dir[0]+= -(MoveRight?1:0) + (MoveLeft?1:0); //the cleverness here is also attributed to the prof
		dir[1]+= (MoveUp?1:0) - (MoveDown?1:0);
		idealDir=dir;
		
	}
	
	public override void _PhysicsProcess(double delta){
		
		Vector2 dir = new Vector2(0,0);
		if(MoveDown || MoveUp ||MoveRight || MoveLeft){
			rotateTowards(idealDir);
			ApplyCentralImpulse(new Vector2((float)Math.Cos(currentDirection)*SPEED,(float)Math.Sin(currentDirection)*SPEED));
		}
		SightLine.Rotation = (float) currentDirection;
		Sight.Rotation = (float) currentDirection;
		hips.parentPos=Position; //make sure named children are rotated correctly *in spirit* and not *in value*
		
		Sprite.currentDirection = (float) currentDirection;
	}
}
