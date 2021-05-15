using Godot;
using System;

public class PlayerMovement : Godot.KinematicBody2D
{
    [Export] public float RunSpeed = 300;
    [Export] public float JumpSpeed = -400;
    [Export] public float DefaultGravity = 500;
    [Export] public float WallJumpHangTime = 0.5f;
    
    private float currentGravity;

    private bool isJumping;
    private bool canStick;
    private Vector2 velocity = new Vector2();
    private readonly Vector2 floorOrientation = new Vector2(0, -1);
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        isJumping = false;
        canStick = true;
        currentGravity = DefaultGravity;
    }

    public override void _Process(float delta)
    {
        GetInput();
    }

    public override void _PhysicsProcess(float delta)
    {
       Move();
       //GD.Print(isJumping + " : " + IsOnWall());
       velocity.y += currentGravity * delta;
       if (isJumping && IsOnFloor())
       {
           GD.Print("On floor");
           jumpCounter = 0;
           jumpCounter++;
           isJumping = false;
       }

       if (IsOnWall() && canStick)
       {
           GD.Print("On wall");
           isJumping = false;
           jumpCounter = 0;
           velocity.y = 0;
           WallJumpTimer(WallJumpHangTime);
           canStick = false;
       }

       velocity = MoveAndSlide(velocity, floorOrientation);
    }

    private bool jump;
    private bool right;
    private bool left;
    private int jumpCounter = 0;
    private void Move()
    {
        velocity.x = 0;

        if (jump)
        {
            currentGravity = DefaultGravity;
        }
        if (jump && jumpCounter < 2)
        {
            isJumping = true;
            GD.Print("jump");
            velocity.y = JumpSpeed;
            jumpCounter++;
        }

        if (right)
        {
            velocity.x += RunSpeed;
        }
        if (left)
        {
            velocity.x -= RunSpeed;
        }
    }

    private void GetInput()
    {
        jump = Input.IsActionJustPressed("ui_select");
        right = Input.IsActionPressed("ui_right");
        left = Input.IsActionPressed("ui_left");
    }

    private async void WallJumpTimer(float time)
    {
        GD.Print("timer started"); 
        currentGravity = 0;
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        GD.Print("timer ended");
        currentGravity = DefaultGravity;
        canStick = true;

    }
}
