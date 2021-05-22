using Godot;
using System;

public class GameManager : Node
{
    [Export] private int sweepInLevel;
    [Export] private int taskInLevel;
    public int SweepDone;
    public int TaskDone;
    public bool IsLevelComplete = false;
    
    public override void _Ready()
    {  
    }
    
    public override void _Process(float delta)
    {
        if (!IsLevelComplete && (SweepDone >= sweepInLevel && TaskDone >= taskInLevel))
        {
            GD.Print("level finished");
            IsLevelComplete = true;
        }
    }
}
