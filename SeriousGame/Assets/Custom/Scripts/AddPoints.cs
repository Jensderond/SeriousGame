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
        GameController.gameController.EnergyLevel += thePoints;
        GameController.gameController.FoodItems += 5;
        GameController.gameController.WaterItems += 5;
    }
}
