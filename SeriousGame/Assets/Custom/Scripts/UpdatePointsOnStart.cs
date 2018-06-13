using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePointsOnStart : MonoBehaviour
{

    public Transform pointText;
    void Start()
    {
        pointText.GetComponent<Text>().text = GameController.gameController.Points.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
