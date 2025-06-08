using Godot;
using System;

public partial class LookTowardsStrategy : Node2D {
	Node2D? target;
	public EntityBase Parent;
	public override void _Ready(){
		target=null;
		Parent = GetParent() as EntityBase;
	}
	public void setTarget(Node2D newTarget){
		target=newTarget; 
	}
	public override void _Process(double delta){
		if(target!=null){
			float temp = (float)Math.Atan((target.GlobalPosition-Parent.GlobalPosition)[1]/(target.GlobalPosition-Parent.GlobalPosition)[0]);
			if(target.GlobalPosition[0]<=Parent.GlobalPosition[0]){temp-=(float)Math.PI;}
			Parent.setCurrentDirection(temp); //not connected to the looktowardsstrategy due to only providing direction sometimes. should change tho
		}
	}
}
