using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerStatus : Node {
	public static PlayerStatus Status; //providing, not enforcing, a singleton instance
	//I don't fully understand godot's autoload feature but i believe an enforcement of singleton is redundant here
	public int maxHealthValue;
	public int healthValue;
	private Dictionary<string, int> TileTallier; //will be abstracted into a seperate class later
	public override void _Ready(){
		Status = this;
		Status.healthValue=100;
		Status.maxHealthValue=100;
		TileTallier = new Dictionary<string, int>();
	}
	void Ping(){
		healthValue-=1;
	}
	public void tally(string input){ //part of tally functionality
		if(TileTallier.ContainsKey(input)){ //don't mess up the keys
			TileTallier[input]++;
		} else {
			TileTallier.Add(input,1);
		}
		foreach(var entry in TileTallier){
			if(TileTallier[input]-entry.Value>5){ //"algorithm" subject to change, the only thing that matters...
				healthValue--; //is that the player is punished for stepping on one tile type too many times
			}
		}
		
	}
	
}
