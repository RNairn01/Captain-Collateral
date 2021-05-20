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
            GlobalPosition = Lerp(GlobalPosition, GetGlobalMousePosition(), 25 * delta);
        }
    }

    public void _on_Area2D_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!businessCardTask.isHoldingCard && Input.IsActionPressed("click"))
        {
            isSelected = true;
            businessCardTask.isHoldingCard = true;
        }
        else
        {
            isSelected = false;
            businessCardTask.isHoldingCard = false;
        }
    }
   
    // In theory I will come back and put this somewhere more sensible, in practice?
    private float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
    
    private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
    {
        float retX = Lerp(firstVector.x, secondVector.x, by);
        float retY = Lerp(firstVector.y, secondVector.y, by);
        return new Vector2(retX, retY);
    }
}
