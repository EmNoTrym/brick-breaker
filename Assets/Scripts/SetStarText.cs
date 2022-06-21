using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetStarText : MonoBehaviour
{
    public TextMeshProUGUI starText;

    void Start()
    {
        starText.text = ((PlayerPrefs.GetInt("playedScene") - 1) * 3).ToString(); 
    }
}
