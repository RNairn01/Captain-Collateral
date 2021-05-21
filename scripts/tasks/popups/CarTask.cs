using Godot;
using System;

public class CarTask : BaseTaskPopup
{
    private AnimatedSprite car;
    private HSlider slider;
    private int oldValue = 0;
    private GameManager gameManager;
    
    public override void _Ready()
    {
        car = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
        slider = GetNode<HSlider>("Panel/Sprite/HSlider");
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
    }

    protected override void PopupTask()
    {
        HandleSlider();

        if (!isTaskComplete && slider.Value == slider.MaxValue)
        {
            isTaskComplete = true;
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
