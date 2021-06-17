using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int points;
    public Text pointsText;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public void addPoints(int count)
    {
        points += count;
        pointsText.text = points.ToString();
    }
}
