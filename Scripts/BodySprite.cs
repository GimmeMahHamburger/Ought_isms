using Godot;
using System;

public partial class BodySprite : Sprite2D {
	Texture2D lookUp;
	Texture2D lookDown;
	Texture2D lookRight;
	Texture2D lookLeft;
	PlayerMovement parent;
	public override void _Ready(){
		//Rotation=0.0;
		lookUp=(Texture2D)GD.Load("res://Sprites/PlayerSprites/SpriteUp.png");
		lookDown=(Texture2D)GD.Load("res://Sprites/PlayerSprites/SpriteDown.png");
		lookRight=(Texture2D)GD.Load("res://Sprites/PlayerSprites/SpriteRight.png");
		lookLeft=(Texture2D)GD.Load("res://Sprites/PlayerSprites/SpriteLeft.png");
		parent = GetParent() as PlayerMovement;
	}
	public override void _Process(double delta){
		
		if(parent.currentDirection > -3*Math.PI/4 && parent.currentDirection < -1*Math.PI/4){
			Texture=lookUp;
		} else if(parent.currentDirection > -1*Math.PI/4 && parent.currentDirection < Math.PI/4){
			Texture=lookRight;
		} else if(parent.currentDirection > Math.PI/4 && parent.currentDirection < 3*Math.PI/4){
			Texture=lookDown;
		} else {
			Texture=lookLeft;
		}
		
	}
}
