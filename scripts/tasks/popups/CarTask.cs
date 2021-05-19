using Godot;
using System;

public class CarTask : BaseTaskPopup
{
    private AnimatedSprite car;
    private HSlider slider;
    private int oldValue = 0;
    private bool taskComplete = false;
    private GameManager gameManager;
    
    public override void _Ready()
    {
        GD.Print("task loaded"); 
        car = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
        slider = GetNode<HSlider>("Panel/Sprite/HSlider");
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
    }

    protected override void PopupTask()
    {
        HandleSlider();

        if (!taskComplete && slider.Value == slider.MaxValue)
        {
            taskComplete = true;
            gameManager.TaskDone++;
            DelayThenFree(0.5f);
        }
    }

    private void HandleSlider()
    {
        int value = Int32.Parse(slider.Value.ToString());

        if (value < oldValue)
        {
            slider.Value = oldValue;
            GD.Print(slider.Value);
        }
        else
        {
            oldValue = value;
        }
        car.Frame = oldValue;
    }
}
