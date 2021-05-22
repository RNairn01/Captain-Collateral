using Godot;
using System;
using System.Collections.Generic;

public class TimerTracker : Node
{
    public static List<float> Times;

    public override void _Ready()
    {
        Times = new List<float>();
    }
}
