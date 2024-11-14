using Godot;
using System;

public partial class NodeMap : Node
{
	//private TextureButton testNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < (8*5); i++)
		{
			var testNode = (RoomNode) GD.Load<PackedScene>("res://scenes/nodemap/blank_node.tscn").Instantiate();
			testNode.Build();
			AddChild(testNode);
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
