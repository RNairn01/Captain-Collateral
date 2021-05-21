using Godot;
using System;

public class ScrubTask : BaseTaskPopup
{
    private GameManager gameManager;
    private int totalStains;
    private int stainsCleaned;
    private bool hasLeftBeenScrubbed;
    private int totalStainsScrubbed;
    private bool hasRightBeenScrubbed;
    private Sponge sponge;
    private Sprite scrub1, scrub2, scrub3, scrub4;
    private Sprite[] stains;
    private AudioStreamPlayer scrubLeft;
    private AudioStreamPlayer scrubRight;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        hasLeftBeenScrubbed = false;
        hasRightBeenScrubbed = false;
        totalStainsScrubbed = 0;
        sponge = GetNode<Sponge>("Panel/Sprite/Sponge");
        scrub1 = GetNode<Sprite>("Panel/Sprite/Scrub1");
        scrub2 = GetNode<Sprite>("Panel/Sprite/Scrub2");
        scrub3 = GetNode<Sprite>("Panel/Sprite/Scrub3");
        scrub4 = GetNode<Sprite>("Panel/Sprite/Scrub4");
        stains = new[] {scrub4, scrub3, scrub2, scrub1};
        totalStains = stains.Length;
        scrubLeft = GetNode<AudioStreamPlayer>("Panel/ScrubLeft");
        scrubRight = GetNode<AudioStreamPlayer>("Panel/ScrubRight");
    }

    protected override void PopupTask()
    {
        if (hasLeftBeenScrubbed && hasRightBeenScrubbed)
        {
            BothSidesScrubbed();
        }

        if (!isTaskComplete && totalStainsScrubbed >= totalStains)
        {
            isTaskComplete = true;
            gameManager.TaskDone++;
            DelayThenFree(0.5f);
        }
    }

    public void _on_ZoneLeft_area_entered(Area2D area)
    {
        if (!hasLeftBeenScrubbed && area.GetParent().Name == sponge.Name && !isTaskComplete)
        {
            hasLeftBeenScrubbed = true;
            scrubLeft.Play();
        } 
    }
    
    public void _on_ZoneRight_area_entered(Area2D area)
    {
        if (!hasRightBeenScrubbed && area.GetParent().Name == sponge.Name && !isTaskComplete)
        {
            hasRightBeenScrubbed = true;
            scrubRight.Play();
        } 
    }

    private void BothSidesScrubbed()
    {
        hasLeftBeenScrubbed = false;
        hasRightBeenScrubbed = false;
        if (totalStainsScrubbed < totalStains)
        {
            stains[totalStainsScrubbed].Visible = false;
            totalStainsScrubbed++;
        }
        
    }

}
