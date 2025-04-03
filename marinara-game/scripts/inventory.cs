using Godot;
using System;
using System.Collections.Generic;

public partial class inventory : Node3D
{
	List<ingredient> mainIngList;
	List<ingredient> subIngList;
	List<Weapon> weaponList;
	public int goldCarrots, maxGoldCarr;
	public RichTextLabel txtLbl;
	public bool isFull; // bool to check if weapon list is full
	public override void _Ready()
	{
		mainIngList = new List<ingredient>();
		subIngList = new List<ingredient>();
		weaponList = new List<Weapon>();
		goldCarrots = 0; maxGoldCarr = 100000;
	}
	public int getCarrots() { return goldCarrots; } // methods for gold carrots (money)
	public void setCarrots(int i) { 
		goldCarrots = i;
		updateCounter();
	}  
	public void incrementCarrots(int i) { 
		goldCarrots += i;
		updateCounter();
	}  
	void updateCounter()
	{
		txtLbl.Text = "AGGGG Golden Carrots: " + goldCarrots + "/" + maxGoldCarr;
	}
	public bool addWeapon(Weapon wep) // add weapon to list, return false if already has 4 weapons
	{
		if(weaponList.Count < 4) {
			weaponList.Add(wep);
			return true;
			//Other weapon adding stuff
		}
		return false;
	} 
	public List<Weapon> getWeapons() { return weaponList; } // return weapon list
	public List<ingredient> getMainList() { return mainIngList; }
	public List<ingredient> getSublist() { return subIngList; }
	public void setWeaponList(List<Weapon> wepList) { weaponList = wepList; } // overwrite weapon list
	public void setMainList(List<ingredient> mainList) { mainIngList = mainList; }
	public void setSubList(List<ingredient> subList) { subIngList = subList; }
	public Weapon getWeapon(int key) { // return weapon at index, useful for hotkeys
		if(key < weaponList.Count)
		{
			return weaponList[key];
		}
		return null;
	}
	public bool removeWeapon(Weapon wp) { // remove weapon from list
		int ind = weaponList.IndexOf(wp);
		if(ind != -1)
		{
			weaponList.Remove(wp);
			return true;
		}
		return false;
	}
	public int findWeapon(Weapon wp) { return weaponList.IndexOf(wp); } // return index of weapon
	public int findSubIngredient(ingredient ig) { return subIngList.IndexOf(ig); } // returns index of an ingredient
	public int findMainIngredient(ingredient ig) { return mainIngList.IndexOf(ig); } // returns index of an ingredient
	public void addIngredient(ingredient i, int num) {
		if(mainIngList.Contains(i))
		{
			mainIngList[mainIngList.IndexOf(i)].increment(num);
		}
		else
		{
			subIngList[subIngList.IndexOf(i)].increment(num);
		}
	}
	public void removeIngredient(ingredient i) { // removes all of an ingredient
		if(mainIngList.Contains(i))
		{
			mainIngList[mainIngList.IndexOf(i)].removeAll();
		}
		else
		{
			subIngList[subIngList.IndexOf(i)].removeAll();
		}
	}
	public void removeIngredient(ingredient i, int num) // removes num amount of an ingredient
	{
		if(mainIngList.Contains(i))
		{
			mainIngList[mainIngList.IndexOf(i)].increment(-num);
		}
		else
		{
			subIngList[subIngList.IndexOf(i)].increment(-num);
		}
	}
	public ingredient getMainIngredient(int key) { // gets a main ingredient based of it's index
		if(mainIngList.Count < key) return mainIngList[key];
		return null;
	}
	public ingredient getSubIngredient(int key) { // gets a sub ingredient based of it's index
		if(subIngList.Count < key) return subIngList[key];
		return null;
	}
	public List<int> getMainNums() { // returns how many of each main ingredient you have in a list of integers
		List<int> nums = new List<int>();
		for(int i = 0; i < mainIngList.Count; i ++)
		{
			nums.Add(mainIngList[i].getNumOf());
		}
		return nums;
	}
	public List<int> getSubNums() { // returns how many of each sub ingredient you have in a list of integers
		List<int> nums = new List<int>();
		for(int i = 0; i < subIngList.Count; i ++)
		{
			nums.Add(subIngList[i].getNumOf());
		}
		return nums;
	}
	public List<string> getMainNames() // returns the name of every main ingredient in the list
	{
		List<string> names = new List<string>();
		for (int i = 0; i < mainIngList.Count; i ++)
		{
			names.Add(mainIngList[i].getName());
		}
		return names;
	}
	public List<string> getSubNames() // returns the name of every sub ingredient in the list
	{
		List<string> names = new List<string>();
		for (int i = 0; i < subIngList.Count; i ++)
		{
			names.Add(subIngList[i].getName());
		}
		return names;
	}
}
