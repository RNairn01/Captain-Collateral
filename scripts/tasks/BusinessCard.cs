using Godot;
using System;

public class BusinessCard : Sprite
{
    private bool isSelected = false;
    private BusinessCardTask businessCardTask;
    public override void _Ready()
    {
        businessCardTask = GetTree().Root.GetNode<BusinessCardTask>("BasePopup");
    }

    public override void _Process(float delta)
    {
        if (isSelected)
        {
            GlobalPosition = businessCardTask.Lerp(GlobalPosition, GetGlobalMousePosition(), 50 * delta);
        }
    }

    public void _on_Area2D_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!businessCardTask.isHoldingCard && Input.IsActionPressed("click"))
        {
            isSelected = true;
            businessCardTask.pickUpCard.Play();
            businessCardTask.isHoldingCard = true;
        }
        else
        {
            isSelected = false;
            businessCardTask.isHoldingCard = false;
        }
    }
   
}
