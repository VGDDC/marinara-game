using Godot;
using System;
using System.Collections.Generic;

public partial class NodeMap : Node
{
	private string[] RANDOMIZATION_OPTIONS;
	private RoomNode[,] nodeMap;

	public float CONNECTIONCHANCE;

	//private TextureButton testNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CONNECTIONCHANCE = 0.85f;
		// Could probably factor this out into file, but that's not a high priority.
		RANDOMIZATION_OPTIONS = new string[8] {
			"exploration 100;1 100",
			"exploration 80 wavedefense 20;2 50 3 50",
			"exploration 70 wavedefense 30;P 1",
			"exploration 60 wavedefense 30 shop 10;P 1",
			"exploration 55 wavedefense 35 shop 10;3 50 4 50",
			"exploration 45 wavedefense 40 shop 15;2 50 3 50",
			"shop 100;2 100",
			"boss 100;1 100"
		};

		RandomizeNodeMap();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("primary_action"))
		{
			RandomizeNodeMap();
		}
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

	public int CountNodesInColumn(int col)
	{
		var amount = 0;

		// Just adding up the assigned nodes in a given column
		for (int i = 0; i < 5; i++)
		{
			if (nodeMap[col, i].Exists())
			{
				amount++;
			}
		}
		
		return amount;
	}

	//========================================================
	//       R A N D O M I Z A T I O N   M E T H O D S
	//
	//                  Proceed with Caution
	//                    ~It's very iffy~
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

		// Randomize nodes in the rest of the columns
		for (int col = 1; col < 6; col++)
		{
			RandomizeColumn(col);
			// And make sure they are all valid
			while (!ValidateColumn(col))
			{
				RandomizeColumn(col);
			}
		}

		RandomizeConnections();
	}

	public void RandomizeColumn(int col)
	{
		// Parse Weights
		string[] weights = RANDOMIZATION_OPTIONS[col].Split(";");
		string[] room_weights = weights[0].Split(" ");
		string[] amount_weights = weights[1].Split(" ");

		var amount = 0;

		// A 'P' means that you take the previous columns amount,
		// and randomly add 0 - Given to it for this column
		if (amount_weights[0].Equals("P"))
		{
			amount = CountNodesInColumn(col - 1) + (int) (GD.Randi() % (int.Parse(amount_weights[1]) + 1));
		}
		else
		{
			amount = ChooseRandomIntegerFromWeights(amount_weights);
		}

		var possible_idxs = new List<int>();

		// The second column should only have nodes in the middle 3 rows
		if (col == 1)
		{
			possible_idxs = new List<int>{1, 2, 3};
		}
		else
		{
			possible_idxs = new List<int>{0, 1, 2, 3, 4};
		}
		
		// Add nodes until an 'amount' amount have been added
		while (amount > 0)
		{
			// the index from possible_idxs that will be passed to SetCell
			var idx = 0;

			// Items are removed, so if there is one last item it is by default added
			if (possible_idxs.Count > 1)
			{
				var choice = (int) (GD.Randi() % possible_idxs.Count);
				idx = possible_idxs[choice];
				possible_idxs.RemoveAt(choice);
			}
			else
			{
				idx = possible_idxs[0];
			}
			
			// Finally, add the cell
			if (CheckValidityOfCell(col, idx))
			{
				SetCell(col, idx, ChooseRandomStringFromWeights(room_weights));
				amount--;
			}
		}
	}

	public bool ValidateColumn(int col)
	{
		return true;
	}

	public void RandomizeConnections()
	{

	}

	public bool CheckValidityOfCell(int col, int idx)
	{
		var toCheck = new int[2];

		// Make sure we stay in bounds
		if (idx == 0)
		{
			toCheck = new int[] {0, 1};
		}
		else if (idx == 4)
		{
			toCheck = new int[] {3, 4};
		}
		else
		{
			toCheck = new int[] {idx - 1, idx, idx + 1};
		}
		
		foreach (int i in toCheck)
		{
			if (nodeMap[col-1, i].Exists())
			{
				return true;
			}
		}

		return false;
	}


	public int ChooseRandomIntegerFromWeights(string[] weights)
	{
		var total  = 0;
		var amount = 0;

		// [1 - 100], Inclusive
		// Rolling a 1d100 here
		var choice = GD.Randi() % 100 + 1;

		// The weights come in pairs (Choice, Odds)
		for (int i = 0; i < (weights.Length / 2); i++)
		{
			// Keep adding the weights until the total is over the rolled number
			total = total + int.Parse(weights[i*2+1]);
			if (choice <= total)
			{
				// Once it is over, you have found your random integer.
				return int.Parse(weights[i*2]);
			}
		}

		// Default to the first option if the above logic breaks
		// Not added yet for testing purposes
		// TODO
		return -1;
	}

	// As above but with a little less integer parsing
	public string ChooseRandomStringFromWeights(string[] weights)
	{
		var total  = 0;
		var amount = 0;

		// [1 - 100], Inclusive
		// Rolling a 1d100 here
		var choice = GD.Randi() % 100 + 1;

		// The weights come in pairs (Choice, Odds)
		for (int i = 0; i < (weights.Length / 2); i++)
		{
			// Keep adding the weights until the total is over the rolled number
			total = total + int.Parse(weights[i*2+1]);
			if (choice <= total)
			{
				// Once it is over, you have found your random string.
				return weights[i*2];
			}
		}

		// Default to the first option if the above logic breaks
		// Not added yet for testing purposes
		// TODO
		return "AHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
	}
}
