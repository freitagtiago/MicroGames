using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Text textPoints;
    [SerializeField] Text healthPoints;
    int hits = 0;

    public void UpdateScore(int points)
    {
        hits = hits + points;
        textPoints.text = hits.ToString();
    }

    public void UpdateHealth(int health)
    {
        healthPoints.text = health.ToString();
    }
}
