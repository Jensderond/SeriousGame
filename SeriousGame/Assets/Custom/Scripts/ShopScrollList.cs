using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int price = 1;
    public Buyable ItemType;
}
public enum Buyable { FOOD, WATER };
public class ShopScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public Text myPointsDisplay;
    public SimpleObjectPool buttonObjectPool;

    private int points;
    
   

    // Use this for initialization
    void Start()
    {
        RefreshDisplay();
        points = GameController.gameController.Points;
    }

    void RefreshDisplay()
    {
        points = GameController.gameController.Points;
        myPointsDisplay.text = "Points: " + points.ToString();
        RemoveButtons();
        AddButtons();


    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);
            newButton.transform.localScale = new Vector3(1, 1, 1);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }

    public void BuyItem(Item item)
    {
        if (points >= item.price)
        {
            GameController.gameController.Points -= item.price;
            points -= item.price;

            switch (item.ItemType)
            {
                case Buyable.FOOD:
                    GameController.gameController.FoodItems++;
                    break;
                case Buyable.WATER:
                    GameController.gameController.WaterItems++;
                    break;
            }
            GameController.gameController.FoodItems++;
            RefreshDisplay();
        }
    }

    void AddItem(Item itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}