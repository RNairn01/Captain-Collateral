using Godot;
using System;

public class ScrubTask : BaseTaskPopup
{
    private GameManager gameManager;
    
    public override void _Ready()
    {
        GD.Print("task loaded"); 
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
    }

    protected override void PopupTask()
    {

    }

}
