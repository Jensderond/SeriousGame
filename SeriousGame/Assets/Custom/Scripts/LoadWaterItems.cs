using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWaterItems : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<Text>().text = ((int)GameController.gameController.WaterItems).ToString() + "x";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
