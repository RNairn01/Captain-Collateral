using Godot;
using System;

public class LevelTimer : Timer
{
    public float levelTime = 0;
    private Label timerValue;
    private GameManager gameManager;
    private bool hasSubmittedTime = false;
    
    public override void _Ready()
    {
        timerValue = GetChild<Label>(0);
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        WaitTime = 0.1f;
        Start();
    }

    public void _on_Timer_timeout()
    {
        if (!gameManager.IsLevelComplete)
        {
            levelTime += 0.1f;
            timerValue.Text = levelTime.ToString("0.0");
        }
        else if (!hasSubmittedTime)
        {
            TimerTracker.Times.Add(levelTime);
            hasSubmittedTime = true;
        }
    }
}
