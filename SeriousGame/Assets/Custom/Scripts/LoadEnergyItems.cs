using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEnergyItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = ((int)GameController.gameController.EnergyItems).ToString() + "x";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
