using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugRadials : MonoBehaviour {

    public Transform textPercent;
    public enum RadialOptions { WaterLevel, FoodLevel, EnergyLevel };
    public RadialOptions currentRadial;

    void Update () {
        switch (currentRadial)
        {
            case RadialOptions.WaterLevel:
                textPercent.GetComponent<Text>().text = "Water" + GameController.gameController.WaterLevel.ToString();
                break;
            case RadialOptions.FoodLevel:
                textPercent.GetComponent<Text>().text = "Food" + GameController.gameController.FoodLevel.ToString();
                break;
            case RadialOptions.EnergyLevel:
                textPercent.GetComponent<Text>().text = "Energy" + GameController.gameController.EnergyLevel.ToString();
                break;
        }
       
    }
}
