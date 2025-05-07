using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerStatus : Node {
	public static PlayerStatus Status;
	public int maxHealthValue;
	public int healthValue;
	private Dictionary<string, int> TileTallier;
	public override void _Ready(){
		Status = this;
		GD.Print("ey there");
		Status.healthValue=100;
		Status.maxHealthValue=100;
		TileTallier = new Dictionary<string, int>();
	}
	void Ping(){
		healthValue-=1;
	}
	public void tally(string input){
		if(TileTallier.ContainsKey(input)){
			TileTallier[input]++;
		} else {
			TileTallier.Add(input,1);
		}
		foreach(var entry in TileTallier){
			if(TileTallier[input]-entry.Value>5){
				healthValue--;
			}
			//GD.Print(Math.Abs(entry.Value-TileTallier[input]));
		}
		
		//GD.Print(healthValue);
	}
	
}
