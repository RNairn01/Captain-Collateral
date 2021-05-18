using Godot;
using System;

public class NailTask : BaseTaskPopup
{
    private Label counter;
    private bool canStrike = true;
    
    public override void _Ready()
    {
        counter = GetNode<Label>("Panel/Label2");
        GD.Print("task loaded"); 
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click") && canStrike)
        {
          counter.Text = (Int32.Parse(counter.Text) + 1).ToString();
          canStrike = false;
          StrikeTimer(1);
          GD.Print("nail click");
        }

        if (Int32.Parse(counter.Text) >= 5)
        {
           GD.Print("finished");
            player.InTask = false;
            QueueFree();
        }
    }
    private async void StrikeTimer(float time)
    {
        GD.Print("strike timer start"); 
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        canStrike = true;
        GD.Print("strike timer end");
    }
}
