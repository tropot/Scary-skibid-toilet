using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public int money;
    public GameObject[] ItemPrefabs;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
    }

    public void setAmmount(Item boughtItem)
    {
        bool itemNotFound = true;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == boughtItem.itemName)
            {
                inventory[i].quantity += 1;
                itemNotFound = false;
            }
        }
        if (itemNotFound == true)
        {
            inventory.Add(boughtItem);
        }
        saveManager.numberToSave = money;
        saveManager.toSave = inventory;
        saveManager.SaveGame();
    }
}
