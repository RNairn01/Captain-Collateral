using Godot;
using System;
using System.ComponentModel.Design.Serialization;

public class ShopTask : BaseTaskPopup
{
    private GameManager gameManager;
    private bool isHoldingSomething = false;
    private bool holdingFigure, holdingPlanet, holdingShirt, holdingHead;
    private bool figureInPlace, planetInPlace, shirtInPlace, headInPlace;
    private Sprite actionFigure, planet, shirt, head;

    public override void _Ready()
    {
        gameManager = GetTree().Root.GetNode<GameManager>("Node2D/GameManager");
        actionFigure = GetNode<Sprite>("Panel/Sprite/Draggables/ActionFigure");
        planet = GetNode<Sprite>("Panel/Sprite/Draggables/Planet");
        shirt = GetNode<Sprite>("Panel/Sprite/Draggables/Shirt");
        head = GetNode<Sprite>("Panel/Sprite/Draggables/Head");
    }

    protected override void PopupTask()
    {
       if (!isTaskComplete && figureInPlace && planetInPlace && shirtInPlace && headInPlace)
       {
          isTaskComplete = true;
          gameManager.TaskDone++;
          DelayThenFree(0.5f);
       }

    }

    public override void _Process(float delta)
    {
       PopupTask();
        
       if (isHoldingSomething)
       {
           if (holdingFigure)
           {
                FollowMouse(actionFigure, delta);           
           }

           if (holdingPlanet)
           {
               FollowMouse(planet, delta);
           }

           if (holdingShirt)
           {
               FollowMouse(shirt, delta);
           }

           if (holdingHead)
           {
               FollowMouse(head, delta);
           }
       }
    }

    //There is almost certainly a more elegant way of handling all these signals that I need to learn
    public void _on_FigureArea_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!isHoldingSomething && Input.IsActionPressed("click"))
        {
            isHoldingSomething = true;
            holdingFigure = true;
        }
        else if (isHoldingSomething && Input.IsActionJustReleased("click"))
        {
           holdingFigure = false;
           isHoldingSomething = false;
        }
    }
    public void _on_PlanetArea_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!isHoldingSomething && Input.IsActionPressed("click"))
        {
            isHoldingSomething = true;
            holdingPlanet = true;
        }
        else if (isHoldingSomething && Input.IsActionJustReleased("click"))
        {
           holdingPlanet = false;
           isHoldingSomething = false;
        }
    }
    public void _on_ShirtArea_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!isHoldingSomething && Input.IsActionPressed("click"))
        {
            isHoldingSomething = true;
            holdingShirt = true;
        }
        else if (isHoldingSomething && Input.IsActionJustReleased("click"))
        {
           holdingShirt = false;
           isHoldingSomething = false;
        }
    }
    public void _on_HeadArea_input_event(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (!isHoldingSomething &&  Input.IsActionPressed("click"))
        {
            isHoldingSomething = true;
            holdingHead = true;
        }
        else if (isHoldingSomething && Input.IsActionJustReleased("click"))
        {
           holdingHead = false;
           isHoldingSomething = false;
        }
    }

    public void _on_ActionFigureArea_area_entered(Area2D area)
    {
        if (area.Name == "FigureArea")
        {
            figureInPlace = true;
        }
    }
    public void _on_PlanetArea_area_entered(Area2D area)
    {
        if (area.Name == "PlanetArea")
        {
            planetInPlace = true;
        }
    }
    public void _on_ShirtArea_area_entered(Area2D area)
    {
        if (area.Name == "ShirtArea")
        {
            shirtInPlace = true;
        }
    }
    public void _on_HeadArea_area_entered(Area2D area)
    {
        if (area.Name == "HeadArea")
        {
            headInPlace = true;
        }
    }
    public void _on_ActionFigureArea_area_exited(Area2D area)
    {
        if (area.Name == "FigureArea")
        {
            figureInPlace = false;
        }
    }
    public void _on_PlanetArea_area_exited(Area2D area)
    {
        if (area.Name == "PlanetArea")
        {
            planetInPlace = false;
        }
    }
    public void _on_ShirtArea_area_exited(Area2D area)
    {
        if (area.Name == "ShirtArea")
        {
            shirtInPlace = false;
        }
    }
    public void _on_HeadArea_area_exited(Area2D area)
    {
        if (area.Name == "HeadArea")
        {
            headInPlace = false;
        }
    }

    private void FollowMouse(Sprite sprite, float delta)
    { 
        sprite.GlobalPosition = Lerp(sprite.GlobalPosition, GetGlobalMousePosition(), 50 * delta);
    }

}
