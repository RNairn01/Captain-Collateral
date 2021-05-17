using Godot;
using System;

public class PlayerMovement : Godot.KinematicBody2D
{
    [Export] public float RunSpeed = 300;
    [Export] public float JumpSpeed = -400;
    [Export] public float DefaultGravity = 500;
    [Export] public float WallJumpHangTime = 0.5f;
    public bool IsSweeping;
    
    private float currentGravity;

    private bool onGround;
    private bool canStick;
    private Vector2 velocity = new Vector2();
    private readonly Vector2 floorOrientation = new Vector2(0, -1);

    private AnimatedSprite anim;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        onGround = false;
        canStick = true;
        currentGravity = DefaultGravity;
        anim = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _Process(float delta)
    {
       GetInput();
    }

    public override void _PhysicsProcess(float delta)
    {
       velocity = MoveAndSlide(velocity, floorOrientation);
       velocity.y += currentGravity;
       Move();
       Jump();
    }

    private bool jump;
    private bool right;
    private bool left;
    private int jumpCounter = 0;
    private int wallJumpCounter = 0;
    private void Move()
    {
        velocity.x = 0;

        if (right)
        {
            velocity.x += RunSpeed;
            anim.FlipH = false;
            
        }
        if (left)
        {
            velocity.x -= RunSpeed;
            anim.FlipH = true;
        }

        if ((right || left) && IsOnFloor() && IsSweeping)
        {
            anim.Animation = "sweep";
        }
        else if ((right || left) && IsOnFloor())
        {
            anim.Animation = "run";
        }
        else if (IsOnFloor())
        {
            anim.Animation = "idle";
        }
    }

    private void Jump()
    {
        if (IsOnFloor())
        {
            onGround = true;
            jumpCounter = 0;
            wallJumpCounter = 0;
        }
        else onGround = false;


        if (IsOnWall() && canStick && wallJumpCounter < 1)
        {
           GD.Print("On wall");
           jumpCounter = 0;
           velocity.y = 0;
           WallJumpTimer(WallJumpHangTime);
           canStick = false;
           velocity.x = 0;
        }
        
        if (jump)
        {
            currentGravity = DefaultGravity;
        }
        if (jump && jumpCounter < 2)
        {
            velocity.y = JumpSpeed;
            AudioStreamPlayer jump;
            GD.Print(jumpCounter);
            switch (jumpCounter)
            {
                case 0:
                    jump = GetChild<AudioStreamPlayer>(2);
                    anim.Animation = "jump1";
                    break;
                case 1:
                    jump = GetChild<AudioStreamPlayer>(3);
                    anim.Animation = "jump2";
                    break;
                default:
                    jump = new AudioStreamPlayer();
                    break;
            }
            jump.Play();
            jumpCounter++;
            onGround = false;
        }

        
    }
    private void GetInput()
    {
        jump = Input.IsActionJustPressed("jump");
        right = Input.IsActionPressed("move_right");
        left = Input.IsActionPressed("move_left");
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
