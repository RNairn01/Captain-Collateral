using Godot;
using System;

public class BaseTaskPopup : Control
{
    protected PlayerMovement player;
    private AudioStreamPlayer successSound;
    public bool isTaskComplete = false;
    public override void _Ready()
    {
       player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
       player.InTask = true;
    }

    public override void _EnterTree()
    {
       player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
       successSound = GetNode<AudioStreamPlayer>("Panel/SuccessSound");
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
            QueueFree();
        }
    }
    protected async void DelayThenFree(float time)
    {
        Visible = false;
        player.InTask = false;
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        successSound.Play();
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        QueueFree();
    }
    
    private float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
    
    public Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
    {
        float retX = Lerp(firstVector.x, secondVector.x, by);
        float retY = Lerp(firstVector.y, secondVector.y, by);
        return new Vector2(retX, retY);
    }
    
}
