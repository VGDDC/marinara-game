using Godot;
using System;

public partial class RoomNode : TextureButton
{
	public void Build()
	{
		TextureNormal = "res://sprites/map/map_node_white.png";
		//Position.X = x; //= new Vector2(x, y);
		GD.Print("NODE HAS BEEN BUILT");
	}
}
