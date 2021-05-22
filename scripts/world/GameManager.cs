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
            LoadNextLevel();
        }
    }
    private async void LoadNextLevel()
    {
        SceneManager.currentLevel++;
        if (SceneManager.currentLevel < SceneManager.levelScenes.Length)
        {
           await ToSignal(GetTree().CreateTimer(1f), "timeout");
           GetTree().ChangeScene(SceneManager.levelScenes[SceneManager.currentLevel]);
        }
        else
        {
            GetTree().ChangeScene(SceneManager.endScene);
        }
    }
    
    private void LoadMainMenu()
    {
        SceneManager.currentLevel = 0;
        TimerTracker.Times.Clear();
        GetTree().ChangeScene(SceneManager.titlescene);
    }

    private void LoadDialogue()
    {
        GetTree().ChangeScene(SceneManager.dialoguescene);
    }
    private void StartGame()
    {
        SceneManager.currentLevel = 0;
        TimerTracker.Times.Clear();
        GetTree().ChangeScene(SceneManager.levelScenes[SceneManager.currentLevel]);
    }
}
