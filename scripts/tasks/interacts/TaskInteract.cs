using Godot;
using System;

public class TaskInteract : Node2D
{
    private bool canInteract;
    [Export] public PackedScene task;
    private PlayerMovement player;
    private BaseTaskPopup childTask;
    
    public override void _Ready()
    {
        childTask = new BaseTaskPopup();
        task = GD.Load<PackedScene>(task.ResourcePath);
        canInteract = false;
    }

    public override void _Process(float delta)
    {
        if (canInteract && Input.IsActionJustPressed("interact"))
        {
            GetTree().Root.AddChild(task.Instance());
            //This is a very silly solution, but I am running out of time and it technically works
            childTask = GetTree().Root.GetNode<BaseTaskPopup>("BasePopup");
        }

        if (childTask.isTaskComplete)
        {
            QueueFree();
        }
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        if (body.Name == "player")
        {
            canInteract = true;
        }
    }
    
    public void _on_Area2D_body_exited(PhysicsBody2D body)
    {
        canInteract = false;
    }
}
