using Godot;
using System;
using Tiles;
using System.Collections.Generic;
namespace Tiles{
	public class TileTemplate{
		public Texture2D tex;
		public float width;
		public float height;
		public float rot;
		public String identifier;
	}
}

public partial class Floor : Node2D{
	List<TileTemplate> silo = new List<TileTemplate>();
	[Export]
	int Width;
	[Export]
	int Height;
	public override void _Ready(){
		TileTemplate temp = new TileTemplate();
		temp.tex = GD.Load<Texture2D>("res://Sprites/BST.png");
		temp.width = 100;
		temp.height = 80;
		temp.identifier = "no thank you";
		
		TileTemplate temp2 = new TileTemplate();
		temp2.tex = GD.Load<Texture2D>("res://Sprites/PlayerSprites/justHowILikeEm.png");
		temp2.width = 100;
		temp2.height = 80;
		temp2.identifier = "Yes thank you";
		
		TileTemplate temp3 = new TileTemplate();
		temp3.tex = GD.Load<Texture2D>("res://Sprites/PlayerSprites/Foot.png");
		temp3.width = 100;
		temp3.height = 80;
		temp3.identifier = "Yes thank you";
		
		AddToList(temp);
		AddToList(temp2);
		AddToList(temp3);
		GenerateFloor(Width,Height);

	}
	void AddToList(TileTemplate template){
		silo.Add(template);
	}
	
	void MakeTile(TileTemplate template, Vector2 offset){
		var scene = GD.Load<PackedScene>("res://Scenes/TileInstance.tscn");
		var instance = scene.Instantiate();
		AddChild(instance);
		TileThingy temp2 = instance.GetNode<TileThingy>("TileThingy");
		temp2.instantiate(template, offset);
	}
	
	void GenerateFloor(int rows, int columns){
		
		int numTiles = silo.Count;
		for(int i=0;i<rows;i++){
			
			for(int j=0;j<columns;j++){
				for(int k=numTiles;k>0;k--){
					if(j%Math.Pow(2,k-1)==0 || i%Math.Pow(2,k-1)==0){
						TileTemplate template = silo[k-1];
						float xOffset = template.width;
						float yOffset = template.height;
						MakeTile(template, new Vector2(xOffset*(float)i,yOffset*(float)j));
						break;
					}
				}
			}
		}
	}
	
}
