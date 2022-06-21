using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectLevel : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public Image webImg;
    public GameObject _3start;

    private void Start()
    {
        int playedScene = PlayerPrefs.GetInt("playedScene");
        Debug.Log(int.Parse(buttonText.text));
        if (playedScene > int.Parse(buttonText.text))
            _3start.SetActive(true);
        if (playedScene < int.Parse(buttonText.text))
            webImg.gameObject.SetActive(true);

    }

    public void ChangeLevel()
    {
        if(buttonText.text == "Tutorial")
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            int playedScene = PlayerPrefs.GetInt("playedScene", 1);
            Debug.Log(playedScene);
            if (playedScene >= int.Parse(buttonText.text))
                SceneManager.LoadScene("Level" + buttonText.text);
            else
                return;
        }
        
    }
}
