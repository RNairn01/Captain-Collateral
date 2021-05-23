using Godot;
using System;
using System.Collections.Generic;

public class TimeSet : Control
{
    private Label time1, time2, time3, time4, time5, time6, time7, time8, timeTotal;
    
    public override void _Ready()
    {
        time1 = GetLabel("Time1");
        time2 = GetLabel("Time2");
        time3 = GetLabel("Time3");
        time4 = GetLabel("Time4");
        time5 = GetLabel("Time5");
        time6 = GetLabel("Time6");
        time7 = GetLabel("Time7");
        time8 = GetLabel("Time8");
        timeTotal = GetLabel("TimeTotal");

        SetTimeText();
    }

    private Label GetLabel(string labelName)
    {
        return GetNode("Sprite").GetNode<Label>(labelName);
    }

    private void SetTime(Label label, int index)
    {
        label.Text = $"Level {index + 1} - {TimerTracker.Times[index].ToString("0.0")}";
    }

    private float GetTimeTotals(List<float> times)
    {
        float total = 0;
        foreach (var time in times)
        {
            total += time;
        }
        return total;
    }

    private void SetTimeText()
    {
        SetTime(time1, 0);
        SetTime(time2, 1);
        SetTime(time3, 2);
        SetTime(time4, 3);
        SetTime(time5, 4);
        SetTime(time6, 5);
        SetTime(time7, 6);
        SetTime(time8, 7);

        timeTotal.Text = $"Total - {GetTimeTotals(TimerTracker.Times).ToString("0.0")}";
    }
}
