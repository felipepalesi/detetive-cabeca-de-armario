using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Mais de uma instância de Inventory encontrada");

        }

        instance = this;
    }
    #endregion
    //quando for referenciar em outro script, usar   Inventory.instance (ou   Inventory.instance.Add(item), por exemplo

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> itens = new List<Item>();

    public void Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            itens.Add(item);

            if(onItemChangedCallback != null)
            {

            onItemChangedCallback.Invoke();
            }

        }
    }

    public void Remove (Item item)
    {
        itens.Remove(item);
    }
}
