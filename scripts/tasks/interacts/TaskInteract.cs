using Godot;
using System;

public class TaskInteract : Node2D
{
    private bool canInteract;
    [Export] public BaseTaskPopup task;
    private PackedScene testing;
    
    public override void _Ready()
    {
        canInteract = false;
        testing = GD.Load<PackedScene>("res://world-entities/tasks/popups/BaseTaskPopup.tscn");
        GD.Print(testing.Instance().Filename);
        
    }

    public override void _Process(float delta)
    {
        if (canInteract && Input.IsActionJustPressed("interact"))
        {
            GD.Print("interacted with task");
            GetTree().Root.AddChild(testing.Instance());
        }
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        canInteract = true;
        GD.Print("entered");
    }
    
    public void _on_Area2D_body_exited(PhysicsBody2D body)
    {
        GD.Print("exited");
        canInteract = false;
    }
}
