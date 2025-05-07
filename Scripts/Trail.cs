using Godot;
using System;
//unused as of now
//didn't have time to pour into its development
//ideally leaves a trail of area2ds behind the player
//and if the player crosses over their own path, "does something"
//proportional to the angle (relative to perpendicular) of their approach
public partial class Trail : Area2D{
	//List<Vector2> points = new List<Vector2>();
	float radius;
	
	public override void _Ready(){
		
	}
	void addCircle(Vector2 input){
		//CollisionObject2D tempCircle = new CollisionObject2D();
	}
}
