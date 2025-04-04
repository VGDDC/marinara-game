using Godot;
using System;

public partial class Player : CharacterBody3D
{
	public const float moveSpeed = 5.0f;
	//public const float jumpVelocity = 4.5f;
	[Export]
	public float health = 100;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y -= gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept")) {
			GD.Print("AHHHHHHHH");
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * moveSpeed * 1.2f;
			velocity.Z = direction.Z * moveSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, moveSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, moveSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	
	public void playerUpdate() {
		//
	}
	
	// use a negative/positive values in other parts of the program to modify
	public void updateHealth(float value) {
		health += value;
	}
	
	// GETTERS
	public float getHealth() {return health;}
	
	// SETTERS
}
