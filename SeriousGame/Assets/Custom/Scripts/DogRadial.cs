using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class DogRadial : MonoBehaviour
{

    [Header("OBJECTS")]
    public Transform loadingBar;
    public Transform textPercent;

    [Header("VARIABLES (IN-GAME)")]
    public bool isOn;
    public bool restart;
    [Range(0, 100)] public float currentPercent;
    [Range(0, 100)] public int speed;
    [Range(0, 10)] public float decayPerTick;

    [Header("SPECIFIED PERCENT")]
    public bool enableSpecified;
    public bool enableLoop;
    [Range(0, 100)] public float specifiedValue;

    public enum RadialOptions { WaterLevel, FoodLevel, EnergyLevel };
    public RadialOptions currentRadial;


    private bool isFilling;
    void Start()
    {
        switch (currentRadial)
        {
            case RadialOptions.WaterLevel:
                specifiedValue = GameController.gameController.WaterLevel;
                break;
            case RadialOptions.FoodLevel:
                specifiedValue = GameController.gameController.FoodLevel;
                break;
            case RadialOptions.EnergyLevel:
                specifiedValue = GameController.gameController.EnergyLevel;
                break;
        }

        int offlineDecay = GameController.gameController.OfflineHours * 5;

        // give them a couple of seconds to save their pet... so se to 1 instead of 0
        if ((specifiedValue - offlineDecay) > 1)
        {
            specifiedValue -= offlineDecay;
        }
        else
        {
            specifiedValue = 1;
        }
    }

    void Update()
    {


        if (currentPercent <= 100 && isOn == true && enableSpecified == false)
        {
            currentPercent += speed * Time.deltaTime;
        }

        if (currentPercent <= 100 && isOn == true && enableSpecified == true)
        {
            if (currentPercent <= specifiedValue)
            {
                currentPercent += speed * Time.deltaTime;
            }

            //when in loop mode simply set current% to 0 else invert default update
            if (enableLoop == true && currentPercent >= specifiedValue)
            {
                currentPercent = 0;
            }
            else
            if (currentPercent >= specifiedValue)
            {
                currentPercent -= speed * Time.deltaTime;
            }

        }

        // loop
        if (currentPercent == 100 || currentPercent >= 100 && restart == true)
        {
            currentPercent = 0;
        }

        // when above 1% and not filling up then decay
        if (currentPercent >= 1 && specifiedValue >= 1 && isOn && isFilling == false)
        {
            specifiedValue -= (float)(decayPerTick / 1000);
            UpdatePersistance();
            // currentPercent -= decayPerTick;
        }

        //TODO: verify that this also works when the bar is emptying
        loadingBar.GetComponent<Image>().fillAmount = currentPercent / 100;
        textPercent.GetComponent<Text>().text = ((int)currentPercent).ToString("F0") + "%";
    }
    public void AddToSpecifiedPercentage(float amountToAdd)
    {
        isFilling = true;
        if (this.specifiedValue + amountToAdd > 100)
        {
            specifiedValue = 100;
            UpdatePersistance();
        }
        else
        {
            specifiedValue += amountToAdd;
            UpdatePersistance();
        }
        isFilling = false;
    }

    private void UpdatePersistance()
    {
        switch (currentRadial)
        {
            case RadialOptions.WaterLevel:
                GameController.gameController.WaterLevel = specifiedValue;
                break;
            case RadialOptions.FoodLevel:
                GameController.gameController.FoodLevel = specifiedValue;
                break;
            case RadialOptions.EnergyLevel:
                GameController.gameController.EnergyLevel = specifiedValue;
                break;
        }
    }
}