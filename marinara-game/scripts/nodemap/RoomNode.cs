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
	private bool connectedTo;
	
	private static root rootNode;

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
	
	public void LoadLevel()
	{
		
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
	
	public int GetX()
	{
		return x;
	}
	
	public int GetY()
	{
		return y;
	}
	
	public string GetNodeType()
	{
		return this.type;
	}

	public bool Exists()
	{
		return this.exists;
	}

	public bool HasConnectionTo(int rightY)
	{
		if (!Exists()) {
			return false;
		}
		
		for (int i = 0; i < connections.Count; i++) {
			if (connections[i].GetY() == rightY) {
				return true;
			}
		}
		return false;
	}
	
	public bool IsConnectedTo() {
		return connectedTo;
	}
	
	public bool HasConnectionFrom() {
		return connections.Count > 0;
	}

	public List<RoomNode> GetConnections() {
		return connections;
	}

	// Setters
	public void SetType(string _type)
	{
		this.type = _type;
	}
	
	public void SetConnectedTo(bool new_value) {
		connectedTo = new_value;
	}


	public void OnClick() {
		var tempNode = (NodeMap) GetParent();
		rootNode = (root) tempNode.GetParent();
		rootNode.LoadLevel(this.type);
	}

	public void ClearConnections() {
		connections = new List<RoomNode>();
	}
	
	public void ClearConnectedTo() {
		connectedTo = false;
	}
	
	// Dunder Zone
	public override string ToString()
	{
		return this.type + " (" + this.x + ", " + this.y + ")";
	}
}
