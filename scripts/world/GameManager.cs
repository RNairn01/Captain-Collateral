using Godot;
using System;

public class GameManager : Node
{
    [Export] private int sweepInLevel;
    [Export] private int taskInLevel;
    public int SweepDone;
    public int TaskDone;
    public bool IsLevelComplete = false;
    private AudioStreamPlayer uiSound;
    private AnimationPlayer fadeAnim;
    
    public override void _Ready()
    {
        uiSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        fadeAnim = GetNode<ColorRect>("ColorRect").GetNode<AnimationPlayer>("FadeAnim");
        GD.Print(fadeAnim.Name);
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
        fadeAnim.Play("fade");
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
        fadeAnim.Play("fade");
        GetTree().ChangeScene(SceneManager.titlescene);
    }

    private void LoadDialogue()
    {
        fadeAnim.Play("fade");
        GetTree().ChangeScene(SceneManager.dialoguescene);
    }
    private void StartGame()
    {
        SceneManager.currentLevel = 0;
        TimerTracker.Times.Clear();
        fadeAnim.Play("fade");
        GetTree().ChangeScene(SceneManager.levelScenes[SceneManager.currentLevel]);
    }

    public void OnMainMenuButtonDown()
    {
        uiSound.Play();
        LoadDialogue();
    }
    public void OnDialogueButtonDown()
    {
        uiSound.Play();
        StartGame();
    }

    public void OnEndButtonDown()
    {
        uiSound.Play();
        LoadMainMenu();
    }
}
