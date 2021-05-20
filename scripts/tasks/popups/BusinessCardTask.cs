using Godot;
using System;

public class BusinessCardTask : BaseTaskPopup
{
    private GameManager gameManager;
    private int cardsRequired;
    private int cardsHanded;
    public bool isHoldingCard;
    public AudioStreamPlayer pickUpCard, handCard;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        cardsRequired = 4;
        cardsHanded = 0;
        isHoldingCard = false;
        pickUpCard = GetNode<AudioStreamPlayer>("Panel/PickUpCard");
        handCard = GetNode<AudioStreamPlayer>("Panel/HandCard");
    }

    protected override void PopupTask()
    {
       if (!isTaskComplete && cardsHanded >= cardsRequired)
       {
          isTaskComplete = true;
          gameManager.TaskDone++;
          DelayThenFree(0.5f);
       }
    }

    public void _on_Person1Area_area_entered(Area2D area)
    {
       area.GetParent().QueueFree();
       handCard.Play();
       GetNode("Panel/Sprite/People/Person1").QueueFree();
       cardsHanded++;
    }
    public void _on_Person2Area_area_entered(Area2D area)
    {
       area.GetParent().QueueFree();
       GetNode("Panel/Sprite/People/Person2").QueueFree();
       cardsHanded++;
    }
    public void _on_Person3Area_area_entered(Area2D area)
    {
       area.GetParent().QueueFree();
       GetNode("Panel/Sprite/People/Person3").QueueFree();
       cardsHanded++;
    }
    public void _on_Person4Area_area_entered(Area2D area)
    {
       area.GetParent().QueueFree();
       GetNode("Panel/Sprite/People/Person4").QueueFree();
       cardsHanded++;
    }

}
