using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public Item itemForSale;
    public PlayerInventory playerInventory;
    public TMP_Text priceUI;
    private int priceText;
    private SaveManager saveManager;


    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        priceText = itemForSale.price;
        priceUI.text = priceText.ToString();
        saveManager = FindObjectOfType<SaveManager>();
        playerInventory.inventory = saveManager.LoadGame();
        playerInventory.money = saveManager.numberToSave;
    }

    public void PurchaseItem()
    {
        if (playerInventory.money >= itemForSale.price)
        {
            playerInventory.DeductMoney(itemForSale.price);
            List<Item> tst = saveManager.LoadGame();
            playerInventory.setAmmount(itemForSale);
        }
        else
        {
            Debug.Log("Not enough money to purchase the item.");
        }
    }
}
