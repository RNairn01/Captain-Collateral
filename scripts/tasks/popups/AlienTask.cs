using Godot;
using System;

public class AlienTask : BaseTaskPopup
{
    private Label counter;
    
    public override void _Ready()
    {
        counter = GetNode<Label>("Panel/Label2");
        GD.Print(counter.Text);
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click"))
        { 
            GD.Print(Int32.Parse(counter.Text) + 1);
            counter.Text = (Int32.Parse(counter.Text) + 1).ToString();
            GD.Print("different click");
        }

        if (Int32.Parse(counter.Text) >= 10)
        {
             GD.Print("finished");
             player.InTask = false;
             QueueFree();
        }
    }
}
