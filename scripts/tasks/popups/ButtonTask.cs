using Godot;
using System;
using System.Collections.Generic;

public class ButtonTask : BaseTaskPopup
{
    private RandomNumberGenerator rng;
    private AudioStreamPlayer buttonClick;
    public override void _Ready()
    {
        rng = new RandomNumberGenerator();
        buttonClick = GetChild(0).GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        rng.Randomize();
        GetRandomButtonLabel().Text = "WIPE CCTV";
        RandomButtons();
    }

    protected override void PopupTask()
    {
    }

    public void _on_button1_button_down()
    {
        ButtonPressTimer(0.1f, 0);
        ResolveButton(0);
    }
    
    public void _on_button2_button_down()
    {
        ButtonPressTimer(0.1f, 1);
        ResolveButton(1);
    }
    
    public void _on_button3_button_down()
    {
        ButtonPressTimer(0.1f, 2);
        ResolveButton(2);
    }
    
    public void _on_button4_button_down()
    {
        ButtonPressTimer(0.1f, 3);
        ResolveButton(3);
    }
    
    public void _on_button5_button_down()
    {
        ButtonPressTimer(0.1f, 4);
        ResolveButton(4);
    }
    
    public void _on_button6_button_down()
    {
        ButtonPressTimer(0.1f, 5);
        ResolveButton(5);
    }
    
    public void _on_button7_button_down()
    {
        ButtonPressTimer(0.1f, 6);
        ResolveButton(6);
    }
    
    private async void ButtonPressTimer(float time, int index)
    {
        GetButton(index).Scale = new Vector2(0.99f, 1.02f);
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        GetButton(index).Scale = new Vector2(1f, 1f);
    }

    private Sprite GetButton(int index)
    {
        return GetChild(0).GetNode<Sprite>("Sprite").GetChild<Sprite>(index);
    }

    private Label GetRandomButtonLabel()
    {
        return GetButton(rng.RandiRange(0, GetChild(0).GetNode<Sprite>("Sprite").GetChildren().Count - 1))
            .GetChild<Label>(1);
    }

    private void RandomButtons()
    {
        var phrases = new List<string> {"TWIDDLE KNOBS", "RAISE TAXES", "DEAL", "FEEL SAD", "PARTY", "STOP", "GET LUCKY", "LOZENGE"};
        for (int i = 0; i < 7; i++)
        {
            if (GetButton(i).GetChild<Label>(1).Text != "WIPE CCTV")
            {
                int rand = rng.RandiRange(0, phrases.Count - 1);
                GetButton(i).GetChild<Label>(1).Text = phrases[rand];
                phrases.RemoveAt(rand);
            }
        }
    }

    private void ResolveButton(int index)
    {
        buttonClick.Play();
        if (GetButton(index).GetChild<Label>(1).Text == "WIPE CCTV")
        {
            GD.Print("right button");
            player.InTask = false;
            DelayThenFree(0.5f);
        }
        else
        {
            GD.Print("wrong button");
        }
    }
}
