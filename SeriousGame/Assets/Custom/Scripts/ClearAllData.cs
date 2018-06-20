using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearData()
    {
        GameController.gameController.WaterLevel = 1f;
        GameController.gameController.FoodLevel = 1f;
        GameController.gameController.EnergyLevel = 1f;
        GameController.gameController.FoodItems = 0;
        GameController.gameController.WaterItems = 0;
        GameController.gameController.FirstTime = true;
        GameController.gameController.Points = 0;
        GameController.gameController.OldDate = DateTime.Now;
        GameController.gameController.OfflineHours = 0;

    }
}
