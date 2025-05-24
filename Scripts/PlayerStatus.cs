using Godot;
using System;
using System.Collections.Generic;

public class TileTallier{
	private Dictionary<string, int> Tally = new Dictionary<string, int>();
	public bool internalTally(string input){ 
		if(Tally.ContainsKey(input)){ //don't mess up the keys
			Tally[input]++;
		} else {
			Tally.Add(input,1);
		}
		foreach(var entry in Tally){
			if(Tally[input]-entry.Value>5){ //"algorithm" subject to change, the only thing that matters...
				return true; //is that the player is punished for stepping on one tile type too many times
			}
		}
		return false;
		
	}
}

public partial class PlayerStatus : Node {
	public static PlayerStatus Status; //providing, not enforcing, a singleton instance
	public int maxHealthValue;
	public int healthValue;
	TileTallier tallier;
	private PlayerStatus(){
		GD.Print("you're not supposed to use this");
		tallier=new TileTallier();
	}
	public override void _Ready(){
		Status = this;
		Status.healthValue=100;
		Status.maxHealthValue=100;
	}
	public void Ping(){
		healthValue-=1;
	}
	public void tally(string input){ //part of tally functionality
		if(tallier.internalTally(input)){Ping();};
		
	}
	
}
