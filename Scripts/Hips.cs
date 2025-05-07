using Godot;
using System;

public partial class Hips : Node2D{
	
	Node2D Foot1;
	Node2D Foot2;
	Area2D Area1;
	Area2D Area2;
	bool isStanding;
	bool movingFoot1;
	[Export]
	float maxDist;
	public Vector2 parentPos; //must be set by some ancestor directly
	bool inputFallingEdge; //for tracking whether a button is *newly* pressed
	bool MoveUp;
	bool MoveDown;
	bool MoveLeft;
	bool MoveRight;
	string tileWhichFootIsAbove;
	
	public override void _Ready(){
		Foot1=GetNode("Ankle1/Foot1") as Node2D;
		Foot2=GetNode("Ankle2/Foot2") as Node2D;
		Area1=GetNode("Ankle1/Foot1/Area2D") as Area2D;
		Area2=GetNode("Ankle2/Foot2/Area2D") as Area2D;
		isStanding = true;
		movingFoot1=false;
		inputFallingEdge = false;
		MoveRight = false;
		MoveLeft = false;
		MoveDown = false;
		MoveUp = false;
		Area1.AreaEntered+=HandleAreaEntered; //signals as of now aren't used, im just keeping them around jic
		Area2.AreaEntered+=HandleAreaEntered;
	}
	
	private void HandleAreaEntered(Area2D area){
		//GD.Print(area);
		if(area.Name=="TileThingy"){
			tileWhichFootIsAbove=(area as TileThingy).ID;
			//PlayerStatus.Status.tally((area as TileThingy).ID);
			//GD.Print((area as TileThingy).ID);
		} else {
			//GD.Print("nay\n");
		}
	}
	private void putFootDown(){ //toggles which foot is "on the floor"
		if((movingFoot1?Area1:Area2).GetOverlappingAreas().Count!=0){
			PlayerStatus.Status.tally(tileWhichFootIsAbove);
		}
		movingFoot1 = !movingFoot1;
	}
	
	private void HandleAreaExited(Area2D area){ //unused 
		if(area.Name=="TileThingy"){
			tileWhichFootIsAbove="NONE";
			//PlayerStatus.Status.tally((area as TileThingy).ID);
			//GD.Print((area as TileThingy).ID);
		} else {
			//GD.Print("nay\n");
		}
	}
	
	Vector2 getLiftedPos(){ //get the pos of the lifted foot
		Vector2 output = new Vector2(0,0);
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position; //use the right foot
		Vector2 difference = groundedFoot-parentPos;
		output=parentPos-difference;
		return output;
		
	}
	
	void checkBounds(){
		Vector2 groundedFoot = movingFoot1?Foot1.Position:Foot2.Position;
		Vector2 difference = groundedFoot-parentPos; //currently no protection from flip-flopping every frame when both are OOB
		if(difference.Length()>maxDist){ //will fix eventually. not critical right now
			putFootDown();
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
				//GD.Print((i as TileThingy).ID);
			} else {
				//GD.Print("nay\n");
			}
		} //here for debugging. will delete once tile system is done
		
		if(MoveRight || MoveLeft || MoveDown || MoveUp){
			inputFallingEdge=true;
		} else if (inputFallingEdge==true){
			inputFallingEdge=false;
			putFootDown(); //Swap feet when all keys are released
		}
		
		checkBounds();
		if(movingFoot1){
			Foot2.Position=getLiftedPos();
		}else{
			Foot1.Position=getLiftedPos();
		}
	}
	
}
