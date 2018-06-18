using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDataScript : MonoBehaviour
{

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 40, 100, 30), "Energy Up"))
        {
            GameController.gameController.EnergyLevel += 10;
        }
        if (GUI.Button(new Rect(10, 80, 100, 30), "Energy Down"))
        {
            GameController.gameController.EnergyLevel -= 10;
        }
        if (GUI.Button(new Rect(10, 120, 100, 30), "Food Up"))
        {
            GameController.gameController.FoodLevel += 10;
        }
        if (GUI.Button(new Rect(10, 160, 100, 30), "Food Down"))
        {
            GameController.gameController.FoodLevel -= 10;
        }
        if (GUI.Button(new Rect(10, 200, 100, 30), "Water Up"))
        {
            GameController.gameController.WaterLevel += 10;
        }
        if (GUI.Button(new Rect(10, 240, 100, 30), "Water Down"))
        {
            GameController.gameController.WaterLevel -= 10;
        }
    }
}
