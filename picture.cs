using Godot;
using System;

public partial class picture : Sprite2D
{

	//This is creating a new signal.
	//it MUST end with "WithArgumentEventHandler" if you are using parameters otherwise it must end with "EventHandler"
	[Signal]
	public delegate void MovedWithArgumentEventHandler(float newx, float newy);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Timer timer = this.GetNode<Timer>("Clock");
		timer.WaitTime = 1;
		
		//this connects the signal of the timer to the "on_timeout" method
		timer.Timeout += on_timeout;
		timer.Start();

		//Note that the "EventHandler" ending of the signal is not written here
		this.MovedWithArgument += on_moved;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void on_timeout() 
	{
		float randX = GD.RandRange(0, 500);
        float randY = GD.RandRange(0, 500);
		this.Position = new Vector2(randX, randY);

		this.EmitSignal("MovedWithArgument", randX, randY);
    }

	void on_moved(float newx, float newy)
	{
		GD.Print("moved ", newx, ",", newy);
	}
}
