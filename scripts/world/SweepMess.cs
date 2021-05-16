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

    private bool hasBeenTriggered = false;
    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body.Name == "player" && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            GD.Print("yes");
            var children = GetChildren();
            foreach (var child in children)
            {
               GD.Print(child.ToString()); 
            }
            var sweep = GetChild<AudioStreamPlayer>(2);
            GD.Print(sweep.Filename);
            sweep.Play();
            Visible = false;
            RemovalTimer(0.8f);
        }
    }
    private async void RemovalTimer(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        QueueFree();
    }
}
