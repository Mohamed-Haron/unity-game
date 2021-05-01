using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoremanager : MonoBehaviour
{

    public static scoremanager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void changescore (int coinvalue)
    {
        score += coinvalue;
        text.text = "X:" + score.ToString();
    }
}
