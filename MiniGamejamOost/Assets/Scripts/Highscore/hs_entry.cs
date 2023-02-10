using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hs_entry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI placement;

    public void SetEntry(string placement, string name, string score)
    {
        this.placement.text = placement+".";
        this.playerName.text = name;
        this.score.text = score;
    }
}
