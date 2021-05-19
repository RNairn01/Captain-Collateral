using Godot;
using System;

public class AlienTask : BaseTaskPopup
{
    private Label counter;
    private AnimatedSprite anim;
    private GameManager gameManager;
    public override void _Ready()
    {
        counter = GetNode<Label>("Panel/Label2");
        GD.Print(counter.Text);
        anim = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click"))
        { 
            GD.Print(Int32.Parse(counter.Text) + 1);
            counter.Text = (Int32.Parse(counter.Text) + 1).ToString();
            anim.Frame++;
        }

        if (Int32.Parse(counter.Text) >= 8)
        {
             player.InTask = false;
             gameManager.TaskDone++;
             DelayThenFree(0.5f);
        }
    }
}
