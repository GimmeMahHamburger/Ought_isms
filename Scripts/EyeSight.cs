using Godot;
using System;

public partial class EyeSight : RayCast2D{
	public delegate void call();
	[Signal]
	public delegate void EyeContactEventHandler();
	public override void _Process(double delta){
		if(GetCollider()!=null){
			if(((GetCollider() as Node).GetNode("EyeSight") as EyeSight).GetCollider()!=null){ //this looks horrendous
				//i will be fixing this as soon as i know how (im goin to office hours soon)
				//it works, and that's all an alpha needs to do rn
				//basically just check whether the two eyes can see eachother
				EmitSignal(SignalName.EyeContact);
			}

			
		}
	}
	
}
