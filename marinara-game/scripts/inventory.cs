using Godot;
using System;

public partial class inventory : Node3D
{
	Godot.Collections.Array<ingredient> mainIngList;
	Godot.Collections.Array<ingredient> subIngList;
	Godot.Collections.Array<Weapon> weaponsList;
	public int goldCarrots;
	public bool isFull; // bool to check if weapon list is full
	public int getCarrots() { return goldCarrots; }
	public void setCarrots(int i) { goldCarrots = i; }
	public void incrementCarrots(int i) { goldCarrots += i; }
	public bool addWeapon(Weapon wep) // add weapon to list, return false if already has 4 weapons
	{
		if(weaponList.size() < 4) {
			weaponList.Add(wep);
			return true;
			//Other weapon adding stuff
		}
		return false;
	}
	public Array<Weapon> getWeapons() { return weaponList; } // return weapon list
	public void setWeaponList(Array<Weapon> wepList) { weaponList = wepList; } // overwrite weapon list
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
	public int findWeapon(Weapon wp) { return weaponList.find(wp); } // return index of weapon
}
