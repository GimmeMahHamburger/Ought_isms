using Godot;
using System;

public partial class EyeSight : RayCast2D{
	public delegate void call();
	[Signal]
	public delegate void EyeContactEventHandler();
	public override void _Process(double delta){
		if(GetCollider()!=null){
			if(((GetCollider() as Node).GetNode("EyeSight") as EyeSight).GetCollider()!=null){
				EmitSignal(SignalName.EyeContact);
			}

			
		}
	}
	
}
