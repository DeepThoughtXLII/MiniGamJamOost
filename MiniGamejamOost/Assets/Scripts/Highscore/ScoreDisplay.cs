using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score;
    public float sc;

    // Update is called once per frame
    void Update()
    {
        sc = Score.instance.yourScore;
        score.text = sc.ToString();
    }
}
