using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadFoodItems : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Text>().text = ((int)GameController.gameController.FoodItems).ToString() + "x";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
