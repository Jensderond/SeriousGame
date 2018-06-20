using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {

    public int thePoints; //how much do you want to add 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSomePoints(int thePoints)
    {
        GameController.gameController.Points += thePoints;
        GameController.gameController.EnergyLevel =75;
        GameController.gameController.FoodLevel = 75;
        GameController.gameController.WaterLevel =75;
        GameController.gameController.FoodItems += 5;
        GameController.gameController.WaterItems += 5;
        GameController.gameController.EnergyItems += 5;
        GameController.gameController.SaveData();

        //The above doesnt set the levels when radials are in the same scene as this script! instead use dogradialsfor that
        
    }
    public void addLevels(DogRadial radial){

        radial.SetAllValuesTo(100);
    }
}
