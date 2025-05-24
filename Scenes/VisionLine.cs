using Godot;
using System;

public partial class VisionLine : StaticBody2D
{
	RayCast2D Sight;
	public override void _Ready(){
		Sight = GetNode("EyeSight") as RayCast2D;
	}
	public override void _Process(double delta){
		
	}
	public bool isColliding(){
		//GD.Print("hey there");
		return Sight.GetCollider()!=null;
		
	}
}
