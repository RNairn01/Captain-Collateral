using Godot;
using System;

public class BaseTaskPopup : Control
{
    protected PlayerMovement player;
    protected bool isTaskComplete = false;
    public override void _Ready()
    {
       player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
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
        player.InTask = false;
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        QueueFree();
    }
}
