using Godot;
using System;

public partial class CameraMove : Camera3D
{
	public bool followCam; //Bool representing if the camera will follow targetNode at an offset
	
	[Export]
	public Node3D targetNode {get; set; } //Node object which the camera will follow at an offset
	
	[Export]
	public float x;
	[Export]
	public float y;
	[Export]
	public float z;
	
	public Vector3 offset; //Offset position from targetNode
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		offset = new Vector3(x, y, z);
		followCam = true;
		targetNode = (Node3D)GetParent().GetNode("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (followCam)
		{
			Vector3 offsetTest = new Vector3(x, y, z);
			Vector3 pos = targetNode.GlobalPosition + offset;
			GlobalPosition = pos;
		}
	}
}
