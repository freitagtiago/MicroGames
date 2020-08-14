using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Text textPoints;
    int hits = 0;

    public void UpdateScore()
    {
        hits++;
        textPoints.text = hits.ToString();
    }
}
