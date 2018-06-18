using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipOfTheDay : MonoBehaviour {

    // Use this for initialization
    public Text txtTip;
    void Start ()
    {
        string[] tips = { "Movement stimulates the release of the happiness hormone endorphin" };
        int index = Random.Range(0, tips.Length);
        txtTip.text = tips[index];
    }
}
