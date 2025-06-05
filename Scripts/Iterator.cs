using Godot;
using System;

public partial class Iterator : Area2D{
	Area2D target;
	float closestDistance;
	Node2D closestNode;
	public override void _Ready(){
		closestDistance=999999999.0f;
	}
	public void setTarget(Area2D newTarget){
		target=newTarget;
	}

	public float findAngleTouching(Vector2 input){
		//if(target=null){return 0.0f;}
		foreach(Node i in target.GetChildren()){
			Node2D temp = i as Node2D;
			float dist = temp.Position.DistanceTo(input);
				if(dist<closestDistance){
					closestDistance=dist;
					closestNode=temp;
				}
		}
		closestDistance=999999999.0f;
		return closestNode.Rotation;
	}
	
	public override void _Process(double delta){
		
	}
}
