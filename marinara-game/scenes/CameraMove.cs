using Godot;
using System;

public partial class CameraMove : Camera3D
{
	public bool followCam; //Bool representing if the camera will follow targetNode at an offset
	
	[Export]
	public Node targetNode {get; set; } //Node object which the camera will follow at an offset
	
	public Vector3 offset = new Vector3(1.0f,1.0f,1.0f); //Offset position from targetNode
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		followCam = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (followCam)
		{
			Vector3 pos = targetNode.position + offset;
			position = pos;
		}
	}
}
