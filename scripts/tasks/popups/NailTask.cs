using Godot;
using System;

public class NailTask : BaseTaskPopup
{
    //private Label counter;
    
    public override void _Ready()
    {
      //  counter = GetChild<Label>(2);
        GD.Print("task loaded"); 
        player = GetTree().Root.GetNode<PlayerMovement>("Node2D/player");
        GD.Print(player.Name);
        player.InTask = true;
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click"))
        {
          //  counter.Text = (Int32.Parse(counter.Text) + 1).ToString();
          GD.Print("nail click");
          Visible = true;
        }

        //if (Int32.Parse(counter.Text) >= 10)
        //{
         //   GD.Print("finished");
           // player.InTask = false;
           // QueueFree();
        //}
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
