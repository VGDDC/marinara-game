using Godot;
using System;

public partial class inventory : Node3D
{
	Godot.Collections.Array<ingredient> ingredientList;
	Godot.Collections.Array<Weapon> weaponsList
	public bool isFull; // bool to check if weapon list is full
	
	public void addIngredient(ingredient ing, int num) // add num of ingredient
	{
		int find = ingredientList.find(ing);
		if(find == -1)
		{
			ingredientList.Add(ing);
			inredientList[find].increment(num);
		}
		else
		{
			inredientList[find].increment(num);
		}
	}
	public bool addWeapon(Weapon wep) // add weapon to list, return false if already has 4 weapons
	{
		if(weaponList.size() < 4) {
			weaponList.Add(wep);
			return true;
			//Other weapon adding stuff
		}
		return false;
	}
	public Array<ingredient> getIngredients() // return ingredient list
	{
		return ingredientList;
	}
	public Array<Weapon> getWeapons() // return weapon list
	{
		return weaponList;
	}
	public void setWeaponList(Array<Weapon> wepList) // overwrite weapon list
	{
		weaponList = wepList;
	}
	public void setIngredientList(Array<ingredient> ingList) // overwrite ingredient list
	{
		ingredientList = ingList;
	}
	public Weapon getWeapon(int key) // return weapon at index, useful for hotkeys
	{
		if(key < weaponList.size())
		{
			return weaponList[key];
		}
		return null;
	}
	public bool removeWeapon(Weapon wp) // remove weapon from list
	{
		int ind = weaponList.find(wp);
		if(ind != -1)
		{
			weaponList.remove_At(wp);
			return true;
		}
		return false;
	}
	public bool removeIngredient(ingredient ig) // remove all of ingredient
	{
		int ind = ingredientList.find(ig);
		if(ind != -1)
		{
			ingredientList.remove_At(ind);
			return true;
		}
		return false;
	}
	public bool removeIngredient(ingredient ig, int num) // remove num of ingredient
	{
		int ind = ingredientList.find(ig);
		if(ind != -1)
		{
			if(ingredientList[ind] > num) ingredientList[ind].increment(-num);
			else ingredientList.remove_At(ind);
			return true;
		}
		return false;
	}
	public int findIngredient(ingredient ig) // return index of ingredient
	{
		return ingredientList.find(ig);
	}
	public int findWeapon(Weapon wp) // return index of weapon
	{
		return weaponList.find(wp);
	}
}
