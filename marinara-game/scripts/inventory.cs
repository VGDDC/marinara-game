using Godot;
using System;

public partial class inventory : Node3D
{
	Godot.Collections.Array<ingredient> ingredientList;
	Godot.Collections.Array<Weapon> weaponsList
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void addIngredient(ingredient ing)
	{
		int find = ingredientList.find(ing)
		if(find == -1)
		{
			ingredientList.Add(ing);
		}
		else
		{
			inredientList[find].increment();
		}
	}
	public void addWeapon(Weapon wep)
	{
		if(weaponList.size() < 4) {
			weaponList.Add(wep);
			//Other weapon adding stuff
		}
		else
		{
			//fail pickup
		}
	}
	public Array<ingredient> getIngredients()
	{
		return ingredientList;
	}
	public Array<Weapon> getWeapons()
	{
		return weaponList;
	}
	public void setWeaponList(Array<Weapon> wepList)
	{
		weaponList = wepList;
	}
	public void setIngredientList(Array<ingredient> ingList)
	{
		ingredientList = ingList;
	}
	
}
