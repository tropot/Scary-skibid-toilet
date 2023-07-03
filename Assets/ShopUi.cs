using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Button purchaseButton;
    private SaveManager saveManager;

    private void Start()
    {
        purchaseButton.onClick.AddListener(PurchaseItem);
        saveManager = FindObjectOfType<SaveManager>();
    }

    private void PurchaseItem()
    {
        // Handle the purchase logic
    }
    

    private void SaveGame()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        //saveManager.SaveGame(playerInventory);
    }
    private void LoadGame()
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        //saveManager.LoadGame(playerInventory);
    }
}