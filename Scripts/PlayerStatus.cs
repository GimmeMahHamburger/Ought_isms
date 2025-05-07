using Godot;
using System;

public partial class PlayerStatus : Node {
	public static PlayerStatus Status;
	public int maxHealthValue;
	public int healthValue;
	public override void _Ready()
	{
		Status = this;
		GD.Print("ey there");
		Status.healthValue=100;
		Status.maxHealthValue=100;
	}
	
}
