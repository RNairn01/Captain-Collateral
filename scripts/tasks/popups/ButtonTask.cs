using Godot;
using System;
using System.Collections.Generic;

public class ButtonTask : BaseTaskPopup
{
    
    public override void _Ready()
    {
    }

    protected override void PopupTask()
    {
    }

    public void _on_button1_button_down()
    {
        GD.Print("button 1");
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(0).Name);
        ButtonPressTimer(0.1f, 0);
    }
    
    public void _on_button2_button_down()
    {
        GD.Print("button 2");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(1).Name);
        ButtonPressTimer(0.1f, 1);
    }
    
    public void _on_button3_button_down()
    {
        GD.Print("button 3");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(2).Name);
        ButtonPressTimer(0.1f, 2);
    }
    
    public void _on_button4_button_down()
    {
        GD.Print("button 4");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(3).Name);
        ButtonPressTimer(0.1f, 3);
    }
    
    public void _on_button5_button_down()
    {
        GD.Print("button 5");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(4).Name);
        ButtonPressTimer(0.1f, 4);
    }
    
    public void _on_button6_button_down()
    {
        GD.Print("button 6");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(5).Name);
        ButtonPressTimer(0.1f, 5);
    }
    
    public void _on_button7_button_down()
    {
        GD.Print("button 7");    
        GD.Print(GetChild(0).GetNode<Sprite>("Sprite").GetChild(6).Name);
        ButtonPressTimer(0.1f, 6);
    }
    
    private async void ButtonPressTimer(float time, int index)
    {
        GetChild(0).GetNode<Sprite>("Sprite").GetChild<Sprite>(index).Scale = new Vector2(0.99f, 1.02f);
        await ToSignal(GetTree().CreateTimer(time), "timeout");
        GetChild(0).GetNode<Sprite>("Sprite").GetChild<Sprite>(index).Scale = new Vector2(1f, 1f);
    }
}
