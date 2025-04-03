using Godot;
using System;

public partial class Inv_UI : Control
{
	// Called when the node enters the scene tree for the first time.
	bool isOpen;
	public override void _Ready()
	{
		close();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("OpenInv"))
		{
			if(isOpen) close();
			else open();
		}
	}
	public void open()
	{
		Visible = true;
		isOpen = true;
	}
	public void close()
	{
		Visible = false;
		isOpen = false;
	}
}
