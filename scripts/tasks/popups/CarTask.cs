using Godot;
using System;

public class CarTask : BaseTaskPopup
{
    private AnimatedSprite car;
    private HSlider slider;
    private int oldValue = 0;
    
    public override void _Ready()
    {
        GD.Print("task loaded"); 
        car = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
        slider = GetNode<HSlider>("Panel/Sprite/HSlider");
    }

    protected override void PopupTask()
    {
        HandleSlider();
    }
    private async void StrikeTimer(float time)
    {
        await ToSignal(GetTree().CreateTimer(time), "timeout");
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
