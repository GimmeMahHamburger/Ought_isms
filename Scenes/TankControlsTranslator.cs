using Godot;
using System;

public partial class TankControlsTranslator : MovementTranslator {
	//the content of this class is mostly taken from the playerbase class
	//I wanted to make other things move like the player
	//it works the same, I just don't have enough variety in my npcs to use it well
	
	[Export]
	float rotSpeed;
	public double currentDirection = 0;
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
	
	public override void moveParent(){
		rotateTowards(intent);
		(GetParent() as PlayerBase).setCurrentDirection((float)currentDirection);
		float speed = intent.Length();
		(GetParent() as PlayerBase).ApplyCentralImpulse(new Vector2((float)Math.Cos(currentDirection)*speed,(float)Math.Sin(currentDirection)*speed));
	}
	
	public override void _Process(double delta){
		//necessary empty def to override base class's "always move parent" stuff
	}
}
