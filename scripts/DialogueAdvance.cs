using Godot;
using System;
using System.Diagnostics;

public class DialogueAdvance : Node
{
    private Label captainText;
    private Label steveText;
    private int dialogueProgress;
    private string[] dialogueArr;
    private int[] speakerOrder;
    private GameManager gameManager;
    private AudioStreamPlayer uiSound;
   
    //This is a very poor dialogue system but I need to finish this soon
    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("GameManager");
        uiSound = GetNode<AudioStreamPlayer>("Sprite/UISound");
        captainText = GetNode<Label>("Sprite/Captain");
        steveText = GetNode<Label>("Sprite/Steve");
        dialogueProgress = 0;
        dialogueArr = new[] {"Ah, Stevie my boy! You've finally arrived! Do you remember how to click to advance dialogue?", "Yes Captain Collateral, I used the A and S keys to move here, with Spacebar for jumping.", "Excellent, well, there's no need to worry, I've already saved the city!", "...", "Like you always save it sir?", "Yes! Those aliens are as good as dust!", "*sigh* I suppose that means I'm on cleanup duty again.", "Right you are Stevie! Sweep up debris and use the mouse to interact with tasks!", "Of course sir... I'll get right to work", "Good work Stevie! You'll be a hero soon enough at this rate!", "*sigh*" };
        speakerOrder = new[] {0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1};
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("click") && dialogueProgress < dialogueArr.Length)
        {
            GD.Print("Advance");
            AdvanceDialogue(speakerOrder[dialogueProgress]);
            dialogueProgress++;
        }
        else if (Input.IsActionJustPressed("click"))
        {
            gameManager.OnDialogueButtonDown(); 
        }
    }

    private void AdvanceDialogue(int speaker)
    {
        if (speaker == 0)
        {
            captainText.Text = dialogueArr[dialogueProgress];
            steveText.Text = "";
        }
        else if (speaker == 1)
        {
            captainText.Text = "";
            steveText.Text = dialogueArr[dialogueProgress];
        }

        if (dialogueProgress > 0)
        {
            uiSound.Play();
        }
    }
}
