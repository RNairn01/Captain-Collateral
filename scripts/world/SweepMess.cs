using Godot;
using System;

public class SweepMess : Node2D
{
    private Area2D area;
    public override void _Ready()
    {
       area = GetChild<Area2D>(1); 
    }

    public override void _PhysicsProcess(float delta)
    {
    
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        GD.Print("entered");
        GD.Print(body.Name);
        if (body.Name == "player")
        {
            QueueFree();
        }
    }
}
