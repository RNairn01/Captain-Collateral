using Godot;
using System;

public class LevelTimer : Timer
{
    private float levelTime;
    private Label timerValue;
    private GameManager gameManager;
    private bool hasSubmittedTime = false;
    
    public override void _Ready()
    {
        levelTime = 0;
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
    }

    public void SubmitTime()
    {
        TimerTracker.Times.Add(levelTime);
    }
}
