using Godot;
using System;

public class ScrubTask : BaseTaskPopup
{
    private GameManager gameManager;
    private int totalStains;
    private int stainsCleaned;
    private int scrubLeftCount;
    private bool hasLeftBeenScrubbed;
    private int scrubRightCount;
    private int totalStainsScrubbed;
    private bool hasRightBeenScrubbed;
    private Sponge sponge;
    private Sprite scrub1, scrub2, scrub3, scrub4;
    private Sprite[] stains;
    
    public override void _Ready()
    {
        GD.Print("task loaded"); 
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        scrubLeftCount = 0;
        hasLeftBeenScrubbed = false;
        scrubRightCount = 0;
        hasRightBeenScrubbed = false;
        totalStainsScrubbed = 0;
        sponge = GetNode<Sponge>("Panel/Sprite/Sponge");
        scrub1 = GetNode<Sprite>("Panel/Sprite/Scrub1");
        scrub2 = GetNode<Sprite>("Panel/Sprite/Scrub2");
        scrub3 = GetNode<Sprite>("Panel/Sprite/Scrub3");
        scrub4 = GetNode<Sprite>("Panel/Sprite/Scrub4");
        stains = new[] {scrub4, scrub3, scrub2, scrub1};
        totalStains = stains.Length;
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
            DelayThenFree(0.5f);
        }
    }

    public void _on_ZoneLeft_area_entered(Area2D area)
    {
        if (!hasLeftBeenScrubbed && area.GetParent().Name == sponge.Name)
        {
            hasLeftBeenScrubbed = true;
            GD.Print("left scrubbed");
        } 
    }
    
    public void _on_ZoneRight_area_entered(Area2D area)
    {
        if (!hasRightBeenScrubbed && area.GetParent().Name == sponge.Name)
        {
            hasRightBeenScrubbed = true;
            GD.Print("right scrubbed");
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
