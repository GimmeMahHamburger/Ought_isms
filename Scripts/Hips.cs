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
	bool inputFallingEdge;
	bool MoveUp;
	bool MoveDown;
	bool MoveLeft;
	bool MoveRight;
	
	public override void _Ready(){
		Foot1=GetNode("Ankle1/Foot1") as Node2D;
		Foot2=GetNode("Ankle2/Foot2") as Node2D;
		isStanding = true;
		movingFoot1=false;
		Body = GetParent().GetParent() as Node2D;
		inputFallingEdge = false;
		MoveRight = false;
		MoveLeft = false;
		MoveDown = false;
		MoveUp = false;
	}
	
	Vector2 getLiftedPos(){
		Vector2 output = new Vector2(0,0);
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position;
		Vector2 difference = groundedFoot-Position;
		output=Position-difference;
		//GD.Print(output);
		return output;
		
	}
	
	void checkBounds(){
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position;
		Vector2 difference = groundedFoot-Position;
		if(difference.Length()>maxDist){
			movingFoot1 = !movingFoot1;
		}
	}
	
	public override void _Input(InputEvent @event){
		
		if (@event.IsAction("MoveRight")){
			MoveRight = @event.IsPressed();
		} 
		if (@event.IsAction("MoveLeft")) {
			MoveLeft = @event.IsPressed();
		} 
		if (@event.IsAction("MoveUp")) {
			MoveUp = @event.IsPressed();
		} 
		if (@event.IsAction("MoveDown")) {
			MoveDown = @event.IsPressed();
		}
	}
	
	public override void _Process(double delta){
		var temp = GetNode<Area2D>("Ankle1/Foot1/Area2D").GetOverlappingAreas();
		foreach(var i in temp){
			if(i.Name=="TileThingy"){
				GD.Print((i as TileThingy).ID);
			} else {
				GD.Print("nay\n");
			}
		}
		
		if(MoveRight || MoveLeft || MoveDown || MoveUp){
			inputFallingEdge=true;
		} else if (inputFallingEdge==true){
			inputFallingEdge=false;
			movingFoot1=!movingFoot1; //Swap feet when all keys are released
		}
		
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
