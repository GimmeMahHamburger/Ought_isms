using Godot;
using System;

public partial class TrailSegment : CollisionShape2D
{
	
	public static TrailSegment Create(){
		
		var scene = GD.Load<PackedScene>("res://Scenes/TrailSegment.tscn");
		TrailSegment temp = scene.Instantiate() as TrailSegment;
		(temp.Shape as CapsuleShape2D).Height=0; //make sure it wont show up until done
		temp.Disabled=true; //then make sure again
		return temp;
	}
	public TrailSegment RadiusIs(float rad){
		if(!Disabled){return this;}
		(Shape as CapsuleShape2D).Radius=rad;
		
		return this;
	}
	public TrailSegment Between(Vector2 in1, Vector2 in2){
		if(!Disabled){return this;}
		Position=(in1+in2)/2.0f;
		(Shape as CapsuleShape2D).Height=0.5f*in1.DistanceTo(in2); //gotta remember the midpoint isn't the "origin"
		Rotation=(float) Math.Atan((in2[1]-in1[1])/(in2[0]-in1[0])); //high school math really helped me here
		return this;
	}
	public TrailSegment WithSprite(Texture2D input){ //just loads the sprite
		if(!Disabled){return this;}
		
		Sprite2D temp= GetNode<Sprite2D>("Sprite2D");
		temp.Texture=input;
		
		return this;
	}
	public TrailSegment Finish(){
		Sprite2D temp= GetNode<Sprite2D>("Sprite2D");
		Vector2 newSize = new Vector2((Shape as CapsuleShape2D).Height*2, (Shape as CapsuleShape2D).Radius)/temp.Texture.GetSize();
		temp.Scale=newSize;
		Disabled=false;
		return this;
	}
	
	
	public override void _Ready(){
		//Disabled=true; //I could use a separate object as a real "Builder" but that was rather cumbersome
	} //so instead of holding the object hostage until I call "make" or smth
	//I just hold the functionality hostage
	//^^^ I ended up not applying it in the Ready func because Ready is called much later than the object is made
	//Dunno why I didn't think of that first
	
	public override void _Process(double delta){
		
	}
}
