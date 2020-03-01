using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class InteractionObject : MonoBehaviour
{

    public bool inventory;      //se true, obj pode ir pro inventário
    public bool openable;       //se true, obj pode ser aberto
    public bool locked;         //se true, obj está fechado
    public bool talks;          //se true, obj fala com o player

    public DialogueTrigger dialogueTrigger;

    public GameObject itemNeeded;    //item necessário para interagir com o obj

    //public Animator anim;          //DESCOMENTAR QUANDO TIVER ANIMAÇÃO

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    /* public void Open()                       DESCOMENTAR QUANDO TIVER ANIMAÇÃO
    {
        anim.SetBool("open", true);

    }
    */
}
