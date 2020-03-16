using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI score;
    static int scorePoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        score.text = "" + scorePoints;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scorePoints;
    }

    public static void AddPointsToScore()
    {
        scorePoints += 10;
    }

}
