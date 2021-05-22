using Godot;
using System;

public class SceneManager : Node
{
    public static int currentLevel = 0;
    public static string titlescene = "res://levels/MainMenu.tscn";
    public static string dialoguescene = "res://levels/Dialogue.tscn";
    private static string level1scene = "res://levels/level1.tscn";
    private static string level2scene = "res://levels/level2.tscn";
    private static string level3scene = "res://levels/level3.tscn";
    private static string level4scene = "res://levels/level4.tscn";
    private static string level5scene = "res://levels/level5.tscn";
    private static string level6scene = "res://levels/level6.tscn";
    private static string level7scene = "res://levels/level7.tscn";
    private static string level8scene = "res://levels/level8.tscn";
    public static string endScene = "res://levels/end.tscn";
    public static string[] levelScenes;
    
    public override void _Ready()
    {
        levelScenes = new[]
            {level1scene, level2scene, level3scene, level4scene, level5scene, level6scene, level7scene, level8scene};
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel < levelScenes.Length)
        {
           GetTree().ChangeScene(levelScenes[currentLevel]);
        }
    }

    public override void _Process(float delta) 
    {
    }
}
