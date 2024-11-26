using Godot;
using System;

public partial class NodeMap : Node
{
	private string[] RANDOMIZATION_OPTIONS;
	private RoomNode[,] nodeMap;
	//private TextureButton testNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Could probably factor this out into file, but that's not a high priority.
		RANDOMIZATION_OPTIONS = new string[8]{
			"EXPLORATION 100;1 100",
			"EXPLORATION 80 WAVEDEFENSE 20;2 50 3 50",
			"EXPLORATION 70 WAVEDEFENSE 30;P 1",
			"EXPLORATION 60 WAVEDEFENSE 30 SHOP 10;P 1",
			"EXPLORATION 55 WAVEDEFENSE 35 SHOP 10;3 50 4 50",
			"EXPLORATION 45 WAVEDEFENSE 40 SHOP 15;2 50 3 50",
			"SHOP 100;2 100",
			"BOSS 100;1 100"
		};

		RandomizeNodeMap();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	//========================================================
	//            N O D E  M A P   M E T H O D S
	//
	//                  Proceed with Caution
	//========================================================
	public void SetCell(int x, int y, string type)
	{
		nodeMap[x,y].OfType(type).Refresh();
	}

	public void ClearNodeMap()
	{
		nodeMap = new RoomNode[8,5];
		int i = 0;

		for (int row = 0; row < 5; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				var newNode = (RoomNode) GD.Load<PackedScene>("res://scenes/nodemap/blank_node.tscn").Instantiate();
				newNode.OfType("empty")
						.At(col, row)
						.Refresh();
				
				nodeMap[col,row] = newNode;
				
				AddChild(newNode);
				i++;
			}
		}
	}

	//========================================================
	//       R A N D O M I Z A T I O N   M E T H O D S
	//
	//                  Proceed with Caution
	//========================================================
	public void RandomizeNodeMap()
	{
		ClearNodeMap();

		// First cell is always Exploration
		SetCell(0, 2, "exploration");

		// Second to last column has 1 shop and 1 exploration
		if (GD.Randi() % 2 == 1)
		{
			SetCell(6, 1, "shop");
			SetCell(6, 3, "exploration");
		}
		else
		{
			SetCell(6, 3, "shop");
			SetCell(6, 1, "exploration");
		}

		// Last cell is always the boss
		SetCell(7, 2, "boss");
	}
}
