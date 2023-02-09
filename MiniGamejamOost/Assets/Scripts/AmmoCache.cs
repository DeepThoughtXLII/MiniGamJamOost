using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AmmoCache : MonoBehaviour
{
    public float bulletAmount;
    [SerializeField] private TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "ammo: " + bulletAmount;
    }
}
