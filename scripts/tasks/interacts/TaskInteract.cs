using Godot;
using System;

public class TaskInteract : Node2D
{
    private bool canInteract;
    [Export] public PackedScene task;
    private PlayerMovement player;
    
    public override void _Ready()
    {
        canInteract = false;
        task = GD.Load<PackedScene>(task.ResourcePath);
      //  GD.Print(task.Instance().Filename + " 1");
      //  GD.Print(task.ResourcePath + " 2");
    }

    public override void _Process(float delta)
    {
        if (canInteract && Input.IsActionJustPressed("interact"))
        {
            GetTree().Root.AddChild(task.Instance());
        //    GD.Print(this.Name);
        }
    }

    public void _on_Area2D_body_entered(PhysicsBody2D body)
    {
        canInteract = true;
       // GD.Print(this.Name);
       // GD.Print(GetTree().Root.GetChildren());
    }
    
    public void _on_Area2D_body_exited(PhysicsBody2D body)
    {
        canInteract = false;
    }
}
