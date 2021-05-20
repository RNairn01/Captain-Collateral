using Godot;
using System;

public class AlienTask : BaseTaskPopup
{
    private int clickCounter;
    private AnimatedSprite anim;
    private GameManager gameManager;
    private AudioStreamPlayer[] crackSounds;
    private AudioStreamPlayer crack1, crack2, crack3, crack4, crack5, crack6, crack7, crackBreak;
    public override void _Ready()
    {
        anim = GetNode<AnimatedSprite>("Panel/Sprite/AnimatedSprite");
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        //This is horrible but I was having some trouble getting them to load in properly as part of an array
        crack1 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack1");
        crack2 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack2");
        crack3 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack3");
        crack4 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack4");
        crack5 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack5");
        crack6 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack6");
        crack7 = GetNode<AudioStreamPlayer>("Panel/CrackSounds/Crack7");
        crackBreak = GetNode<AudioStreamPlayer>("Panel/CrackSounds/CrackBreak");
        crackSounds = new[] {crack1, crack2, crack3, crack4, crack5, crack6, crack7};
    }

    protected override void PopupTask()
    {
        if (Input.IsActionJustPressed("click") && clickCounter < 7)
        { 
            crackSounds[clickCounter].Play();
            clickCounter++;
            anim.Frame++;
        }

        if (!isTaskComplete && clickCounter >= 7)
        {
             crackBreak.Play();
             isTaskComplete = true;
             gameManager.TaskDone++;
             DelayThenFree(0.5f);
        }
    }
}
