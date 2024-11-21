using Godot;
using System;

public partial class Weapon : GodotObject
{
	///VARIABLES
	private string name; //The display name for this weapon
	private Texture2D weaponSprite; //Sprite used to represent the weapon in menus and game world
	
	private bool autoFire; //Determines if a weapon is automatic (1) or semi-automatic (0)
	private float downTime; //Downtime after using a weapon before the player can switch or attack again
	private int projectileCount; //Number of hurtboxes/projectiles spawned by attacking a single time

	private PackedScene bullet; //Scene object with the default projectile fired by this weapon.
	private float damage; //Damage dealt by an individual projectile or swing of this weapon
	private float lifeTime; //Amount of time before the hurt box for the weapon's attack despawns
	private float instantVelocity; //Velocity applied to each bullet when created
	
	private float healMod; //Modifier that affects the amount of health healed by eating this weapon

	private int useCost; //Number of uses consumed each time the weapon is used.
	private int maxUses; //Maximum number of times the player can attack with this weapon before it is destroyed
	private int uses; //Number of times the player can attack with this weapon before it is destroyed
	
	//Ingredient secondaryList[]; //Secondary ingredients used in the creation of this weapon - commented until Ingredient is more fleshed out
	
	///Constructors/Destructors
	
	///<summary>	Constructor that reads in all relevant stats for a weapon.
	///<param name="_name"> string passed in for the weapon's name </param>
	///<param name="_autoFire"> bool passed in for the weapon's "autoFire" </param>
	///<param name="_downTime"> float passed in for the weapon's "downTime" </param>
	///<param name="_projectileCount"> int passed in for the weapon's "projectileCount" </param>
	///<param name="_damage"> float passed in for the weapon's damage value </param>
	///<param name="_lifeTime"> float passed in for the weapon's "lifeTime" </param>
	///<param name="_instantVelocity"> float passed in for the weapon's "instantVelocity" </param>
	///<param name="_useCost"> int passed in for the weapon's "useCost" </param>
	///<param name="_maxUses"> int passed in for the weapon's "maxUses" </param>
	///<param name="iList[]"> array of ingredients passed in when creating a weapon. These are the Secondary Ingredients used to craft the weapon. </param>
	///<param name="spritePath"> string representation of file path leading to the texture that will be used for "weaponSprite" </param>
	///<param name="bulletPath"> string representation of file path leading to the scene that will be used for "bullet" </param>
	///</summary>
	Weapon(string _name, bool _autoFire, float _downTime, int _projectileCount, float _damage, float _lifeTime, float _instantVelocity, int _useCost, int _maxUses, /*Ingredient[] iList,*/ string spritePath, string bulletPath) {
		//Instantiate variables
		name = _name;
		autoFire = _autoFire;
		downTime = _downTime;
		projectileCount = _projectileCount;
		damage = _damage;
		lifeTime = _lifeTime;
		instantVelocity = _instantVelocity;
		healMod = 0.15f; //0.15 is the default value for all weapons except Pistols
		useCost = _useCost;
		maxUses = _maxUses;

		weaponSprite = GD.Load<Texture2D>("res://scenes/weapons/"+spritePath);
		bullet = GD.Load<PackedScene>("res://sprites//prefabs/weapons/"+bulletPath);

		//Apply Secondary Ingredient modifiers
		//SUGGESTION: each Secondary Ingredient class/struct should have a "applyStats()" type of function that modifies the weapon's stats.
		/*
		foreach(Ingredient i in iList) {
			//code goes here
			healMod += 0.05;
		}
		*/
		//Instantiate "living" variables
		uses = maxUses;
	}

	///GETTERS
	public string getName() {return name;}
	//TO-DO: get weaponSprite?
	public bool getAutoFire() {return autoFire;}
	public float getDownTime() {return downTime;}
	public int getProjectileCount() {return projectileCount;}
	//TO-DO: get bullet?
	public float getDamage() {return damage;}
	public float getLifeTime() {return lifeTime;}
	public float getInstantVelocity() {return instantVelocity;}
	public float getHealMod() {return healMod;}
	public int getUseCost() {return useCost;}
	public int getMaxUses() {return maxUses;}
	public int getUses() {return uses;}
	
	///SETTERS
	//NOTE: may need setters specifically so that Secondary Ingredients can modify the stats of the weapon.

	///FUNCTIONS
	
	///<summary>	Function where player will "eat" part of their weapon in order to heal.
	///<returns> The amount of health the player should heal from eating the weapon. </returns>
	///</summary>
	public float eatWeapon() {
		expendUse(maxUses/4);
		return 10*healMod; //10 is an arbitrary number. Will be changed as health stats are finalized
	}

	//TO-DO: Shoot function - Prerequisite: bullet Scene needs to be made properly.
	/*public void fireWeapon() {
		expendUse(useCost);
		Node newBullet = instantiate(bullet);
		newBullet.Bullet.setStats([INSERT PARAMETERS BEING PASSED]);
	}*/
	
	///<summary>
	///<param name="value"=1> Number of uses being expended by an action of this weapon
	///</summary>
	private void expendUse(int value = 1) {
		uses -= value;
		//if (uses<=0)
		//Destroy or otherwise delete this item? Probably will need to call a delete function in a parent class or something?
	}

}
