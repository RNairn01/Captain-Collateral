using Godot;
using System;

public class AlienTask : BaseTaskPopup
{
    private Label counter;
    private AnimatedSprite anim;
    public override void _Ready()
    {
        counter = GetNode<Label>("Panel/Label2");
        GD.Print(counter.Text);
        anim = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click"))
        { 
            GD.Print(Int32.Parse(counter.Text) + 1);
            counter.Text = (Int32.Parse(counter.Text) + 1).ToString();
            anim.Frame++;
            GD.Print("different click");
        }

        if (Int32.Parse(counter.Text) >= 8)
        {
             GD.Print("finished");
             player.InTask = false;
             DelayThenFree(0.5f);
        }
    }
}
