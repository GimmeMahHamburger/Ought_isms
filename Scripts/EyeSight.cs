using Godot;
using System;

public partial class EyeSight : RayCast2D{
	[Signal]
	public delegate void EyeContactEventHandler();
	public override void _Process(double delta){
		if(GetCollider()!=null){
			if(((GetCollider() as VisionLine).isColliding())){
				EmitSignal(SignalName.EyeContact);
			}
		}
	}
}
