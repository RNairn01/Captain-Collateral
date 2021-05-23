using Godot;
using System;
using System.Collections.Generic;

public class TimerTracker : Node
{
    public static List<float> Times;

    public override void _Ready()
    {
        Times = new List<float>();
        //Test values, these get cleared on game start
        Times.AddRange(new List<float>(){15, 14.2f, 5.76f, 9, 20, 8.97f, 6, 2.1f});
    }
}