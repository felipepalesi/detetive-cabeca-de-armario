using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[10];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "entrou");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }
        //inventario cheio
        if (!itemAdded)
        {
            Debug.Log("inventario cheio");
        }

    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                //item foi encontrado
                return true;
            }
        }

        //item não foi encontrado
        return false;
    }
}
