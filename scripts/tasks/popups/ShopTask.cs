using Godot;
using System;

public class ShopTask : BaseTaskPopup
{
    private GameManager gameManager;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
    }

    protected override void PopupTask()
    {
       if (!isTaskComplete && false)
       {
          isTaskComplete = true;
          gameManager.TaskDone++;
          DelayThenFree(0.5f);
       }
    }

}
