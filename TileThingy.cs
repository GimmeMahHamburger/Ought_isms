using Godot;
using System;
using Tiles;

public partial class TileThingy : Area2D{
	CollisionShape2D tileShape;
	public String ID;
	public override void _Ready(){
		tileShape = GetNode("TileShape") as CollisionShape2D;
		
		var texture = GD.Load<Texture2D>("res://Foot.png");
		var sprite = GetNode<Sprite2D>("Sprite2D");
		sprite.Texture = texture;
	}
	
	public void instantiate(TileTemplate template, Vector2 offset){
		var sprite = GetNode<Sprite2D>("Sprite2D");
		sprite.Texture = template.tex;
		Vector2 oldSize = template.tex.GetSize();
		Vector2 newSize = new Vector2(template.width, template.height)/oldSize;
		sprite.Scale=newSize;
		Position = offset;
		(tileShape.Shape as RectangleShape2D).Size = new Vector2(template.width,template.height);
		ID = template.identifier;
		
	}
	
	public override void _Process(double delta){

		//GD.Print(GetOverlappingAreas());
		
	}
	
}
