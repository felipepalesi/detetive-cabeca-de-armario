﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header ("Locked")]
    public bool openable = false;
    public bool locked = false;
    public GameObject itemNeeded;
    
    [Header ("NPC")]
    public bool npc = false;
    public DialogueTrigger dialogueTrigger;
    
    [Header ("Door")]
    public bool door = false;
    public string nextScene;

    public void Talk()
    {
        dialogueTrigger.TriggerDialogue();
    } 
}
