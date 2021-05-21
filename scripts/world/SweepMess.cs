using Godot;
using System;

public class SweepMess : Node2D
{
    private Area2D area;
    private PlayerMovement player;
    private GameManager gameManager;
    public override void _Ready()
    {  
        player = GetNode<PlayerMovement>("../player");
        area = GetChild<Area2D>(1); 
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
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
            var sweep = GetChild<AudioStreamPlayer>(2);
            sweep.Play();
            gameManager.SweepDone++;
            player.IsSweeping = true;
            Visible = false;
            RemovalTimer(0.8f);
        }
    }
    private async void RemovalTimer(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        player.IsSweeping = false;
        QueueFree();
    }
}
