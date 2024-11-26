using Godot;
using System;
using System.Collections.Generic;

public partial class RoomNode : TextureButton
{
	private int x;
	private int y;
	private bool exists;
	private string type;

	private List<RoomNode> connections;
	
	// Build
	public RoomNode OfType(string _type)
	{
		this.type = _type;
		return this;
	}

	public RoomNode At(int _x, int _y)
	{
		this.x = _x;
		this.y = _y;

		Position = new Vector2(x*80+20, y*80);

		return this;
	}
	
	public void Refresh()
	{
		TextureNormal = (Texture2D) GD.Load("res://sprites/map/map_node_" + type + ".png");
		connections = new List<RoomNode>();

		// Empty nodes do not "exist" and will not be rendered
		if (type.Equals("empty"))
		{
			exists = false;
			Visible = false;
		}
		else
		{
			exists = true;
			Visible = true;
		}
	}

	// Setters
	public void AddConnection(RoomNode node)
	{
		connections.Add(node);

		
	}

	// Getters
	public Vector2 GetPos()
	{
		return Position;
	}
	
	public float GetX()
	{
		return Position[0];
	}
	
	public float GetY()
	{
		return Position[1];
	}
	
	public string GetNodeType()
	{
		return this.type;
	}

	public bool Exists()
	{
		return this.exists;
	}

	// Setters
	public void SetType(string _type)
	{
		this.type = _type;
	}

	
	// Dunder Zone
	public override string ToString()
	{
		return this.type + " (" + this.x + ", " + this.y + ")";
	}
}