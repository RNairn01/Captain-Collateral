using Godot;
using System;

public class BaseTaskPopup : Control
{
    protected PlayerMovement player;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    //   GD.Print("task loaded"); 
       player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
    //   GD.Print(player.Name);
       player.InTask = true;
    }

    public override void _EnterTree()
    {
       player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
       player.InTask = true;
    }

    public override void _Process(float delta)
    {
        PopupTask();
    }

    protected virtual void PopupTask()
    {
        if (Input.IsActionJustPressed("click"))
        {
            player.InTask = false;
            GD.Print("click");
            QueueFree();
        }
    }
    protected async void DelayThenFree(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        QueueFree();
    }
}
