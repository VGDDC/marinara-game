using Godot;
using System;
using Godot.Collections;

public partial class ingredient : Node
{
	// list all ingredient options here
	public Array<ingredient> allIngredients;
	public int numOf;
	
	// returns a random ingredient object from full list of ingredients
	public ingredient randomIngredient() {
		int index;
		ingredient option;
		Random random = new Random();
		
		index = random.Next(0, allIngredients.Count);
		
		option = allIngredients[index];
		
		return option;
	}
	public void increment()
	{
		numOf ++;
	}
	
	// GETTERS
	public ingredient getIngredient(int index) {return allIngredients[index];}
}
