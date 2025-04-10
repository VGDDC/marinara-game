using Godot;
using System;

public partial class Enemy : CharacterBody3D
{
	public const float moveSpeed = 5.0f;
	//public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		/*if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;*/

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		//Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		//Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		Node3D node = (Node3D)GetParent().GetNode("Player");
		Vector3 direction = Position.DirectionTo((node.Position)); 
		
		float distance = 4.0f;
		
		if (direction != Vector3.Zero)
		{
			velocity.X = (direction.X) * moveSpeed * Math.Clamp((Position.DistanceTo(node.Position) - distance), -1, 1);
			velocity.Z = (direction.Z) * moveSpeed * Math.Clamp((Position.DistanceTo(node.Position) - distance), -1, 1);
		}
		/*else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, moveSpeed * (Position.DistanceTo(node.Position));
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, moveSpeed * (Position.DistanceTo(node.Position));
		}*/

		Velocity = velocity;
		MoveAndSlide();
	}
}
