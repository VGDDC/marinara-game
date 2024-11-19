using Godot;
using System;
using Godot.Collections;

public partial class ingredient : Node
{
	// list all ingredient options here
	public Array<ingredient> allIngredients;
	
	// returns a random ingredient object from full list of ingredients
	public ingredient randomIngredient() {
		int index;
		ingredient option;
		Random random = new Random();
		
		index = random.Next(0, this.allIngredients.Count);
		
		option = this.allIngredients[index];
		
		return option;
	}
	
	// GETTERS
	public ingredient getIngredient(int index) {return allIngredients[index];}
}
