using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInterObj)
        {
            //checka se o obj pode ser colocado no inventário
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            //checka se o obj pode ser aberto
            if (currentInterObjScript.openable)
            {

                //checka se o obj está trancado
                if (currentInterObjScript.locked)
                {

                    //checka se o player tem o item necessário para abrir
                    //procurar no inventário pelo item necessário
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        currentInterObjScript.locked = false;

                        //feedback de que o obj foi aberto
                        Debug.Log(currentInterObj.name + "liberou geral");
                    }
                    else
                    {
                        //feedback de que o obj não foi aberto
                        Debug.Log(currentInterObj.name + "tá faltando");
                    }
                }
                else
                {
                    //abre o obj
                    Debug.Log(currentInterObj.name + "abriu");
                    //currentInterObjScript.Open();          DESCOMENTAR QUANDO TIVER ANIMAÇÃO
                }
            }

            //checka se este obj fala e/ou tem uma mensagem
            if (currentInterObjScript.talks)
            {
                currentInterObjScript.dialogueTrigger.TriggerDialogue();
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;

            }
        }

    }

}
