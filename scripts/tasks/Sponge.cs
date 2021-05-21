using Godot;
using System;

public class Sponge : Sprite
{
    private bool isSelected = false;
    private ScrubTask scrubTask;
    public override void _Ready()
    {
        scrubTask = GetTree().Root.GetNode<ScrubTask>("BasePopup");
    }

    public override void _Process(float delta)
    {
        if (isSelected)
        {
            GlobalPosition = scrubTask.Lerp(GlobalPosition, GetGlobalMousePosition(), 25 * delta);
        }
    }

    public void _on_Area2D_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (Input.IsActionPressed("click"))
        {
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }
    }
}
