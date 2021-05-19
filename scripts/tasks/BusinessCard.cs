using Godot;
using System;

public class BusinessCard : Sprite
{
    private bool isSelected = false;
    public override void _Ready()
    {
        
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
        GD.Print("card input");
        if (Input.IsActionPressed("click"))
        {
            isSelected = true;
            GD.Print("cardclick");
        }
        else isSelected = false;
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
