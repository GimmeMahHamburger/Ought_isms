using Godot;
using System;

public partial class Hips : Node2D{
	
	Node2D Foot1;
	Node2D Foot2;
	bool isStanding;
	bool movingFoot1;
	[Export]
	float maxDist;
	Node2D Body;
	
	public override void _Ready(){
		Foot1=GetNode("Ankle1/Foot1") as Node2D;
		Foot2=GetNode("Ankle2/Foot2") as Node2D;
		isStanding = true;
		movingFoot1=false;
		Body = GetParent().GetParent() as Node2D;
	}
	
	Vector2 getLiftedPos(){
		Vector2 output = new Vector2(0,0);
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position;
		Vector2 difference = groundedFoot-Position;
		output=Position-difference;
		GD.Print(output);
		return output;
		
	}
	
	void checkBounds(){
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position;
		Vector2 difference = groundedFoot-Position;
		if(difference.Length()>maxDist){
			movingFoot1 = !movingFoot1;
		}
	}
	
	public override void _Process(double delta){
		checkBounds();
		Position=Body.Position;
		//GD.Print(Body.Position);
		if(movingFoot1){
			Foot2.Position=getLiftedPos();
		}else{
			Foot1.Position=getLiftedPos();
		}
		
		//Foot1.Position+=new Vector2(0.1f,0.0f);
	}
	
}
