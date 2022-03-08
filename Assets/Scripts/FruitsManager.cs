using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitsManager : MonoBehaviour
{
    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInLevel;

    void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }
    
    void Update()
    {
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = (totalFruitsInLevel - transform.childCount).ToString();
    }
}
