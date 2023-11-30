using Godot;
using System;

public partial class Weapon : GodotObject
{
	///VARIABLES
	Texture2D weaponSprite; //Sprite used to represent the weapon in menus and game world
	byte weaponType; //Value determining how a weapon will fire
	/*
	0 = melee? - May be irrelevant?
	1 = semi-automatic - Only attacks on button press
	2 = automatic - Attacks on button press and continues to do so after downTime has passed
	*/
	
	float damage; //Damage dealt by an individual projectile or swing of this weapon
	float downTime; //Downtime after using a weapon before the player can switch or attack again
	float lifeTime; //Amount of time before the hurt box for the weapon's attack despawns
	int attacks; //Number of hurtboxes/projectiles spawned by attacking a single time
	
	int maxUses; //Maximum number of times the player can attack with this weapon before it is destroyed
	int uses; //Number of times the player can attack with this weapon before it is destroyed
	
	///GETTERS
	
	///SETTERS
	
	///FUNCTIONS
	
	
	
}
