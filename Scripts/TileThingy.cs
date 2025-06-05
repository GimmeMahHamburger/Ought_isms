using Godot;
using System;
using Tiles;

public partial class TileThingy : Area2D{
	CollisionShape2D tileShape;
	public String ID;
	public override void _Ready(){
		tileShape = GetNode("TileShape") as CollisionShape2D;
		var texture = GD.Load<Texture2D>("res://Sprites/PlayerSprites/Foot.png"); //default is foot hehehe
		var sprite = GetNode<Sprite2D>("Sprite2D");
		sprite.Texture = texture;
		ID="NONE";
	}
	
	public void instantiate(TileTemplate template, Vector2 offset){ //take data from ideal version and reference it in flyweight
		var sprite = GetNode<Sprite2D>("Sprite2D");
		sprite.Texture = template.tex;
		Vector2 oldSize = template.tex.GetSize();
		Vector2 newSize = new Vector2(template.width, template.height)/oldSize;
		sprite.Scale=newSize;
		Position = offset;
		(tileShape.Shape as RectangleShape2D).Size = new Vector2(template.width,template.height);
		ID = template.identifier;
		(sprite.Material as ShaderMaterial).SetShaderParameter("offset",offset);
		(sprite.Material as ShaderMaterial).SetShaderParameter("size",newSize);
		
		
	}
	
	public void ShaderProc(Vector2 inputPos){
		//var pos = PlayerStatus.Status.playerInstance.GlobalPosition;
		//GD.Print("steppy at");
		//GD.Print(GlobalPosition);
		(GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("currentPos",GlobalPosition);
		//(GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("offset",inputPos-GlobalPosition);
		
	}
	
	public override void _Process(double delta){
		//var pos = PlayerStatus.Status.playerInstance.GlobalPosition;
		//(GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("offset",pos-GlobalPosition);
		//(GetNode<Sprite2D>("Sprite2D").Material as ShaderMaterial).SetShaderParameter("offset",pos-GlobalPosition);
		
	}
	
}
