using Godot;
using System;

public partial class root : Node
{
	private Node inventory;
	
	[Export]
	public Node nodeMap;

	[Export]
	public Node currentLevel;

	public void LoadLevel(string id)
	{

		// Theoretically, put the scene inside the RoomNode, turned off
		// When it's wanted, send a reference to the room scene itself through this method and turn on
		currentLevel.QueueFree();
		currentLevel = GD.Load<PackedScene>(String.Format("res://scenes/rooms/{0}_blank.tscn", id)).Instantiate();
		AddChild(currentLevel);
		//currentLevel = 
		
	}

	public void ResetNodeMap()
	{
		nodeMap.QueueFree();
		nodeMap = GD.Load<PackedScene>(String.Format("res://scenes/nodemap/nodemap.tscn")).Instantiate();
		AddChild(nodeMap);
	}
}
