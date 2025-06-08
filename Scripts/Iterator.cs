using Godot;
using System;

public partial class Iterator : Area2D{
	//the reason it extends area2d is because I had a pipe dream of making it the parent of each
	//little trail element in sequence, then check for collisions
	//that's not how area2d's work. I found this out too late.
	//nevertheless the "incorrect" (really doesn't matter) base class stays to remind me of my arrogance
	Area2D target;
	float closestDistance;
	Node2D closestNode;
	public override void _Ready(){
		closestDistance=999999999.0f; //this is funnier than the integer limit
	} //if i thought this was feasible or even playable I'd change it
	public void setTarget(Area2D newTarget){
		target=newTarget;
	}

	public float findAngleTouching(Vector2 input){
		//if(target=null){return 0.0f;}
		foreach(Node i in target.GetChildren()){//Iterate through. check distance. find least.
			Node2D temp = i as Node2D; //not very complex
			float dist = temp.Position.DistanceTo(input);
				if(dist<closestDistance){
					closestDistance=dist;
					closestNode=temp;
				}
		}
		closestDistance=999999999.0f;
		return closestNode.Rotation; //the rotation is all it cares about
	}
	
	public override void _Process(double delta){
		
	}
}
