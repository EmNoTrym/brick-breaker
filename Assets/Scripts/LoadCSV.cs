using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    private string[] data;

    public int level;

    public int lives;
    public int gameSpeed;

    public bool newLevelLoaded = false;
    

    // Start is called before the first frame update

    
    void Awake()
    {
        level = PlayerPrefs.GetInt("PickedLevel");
        LoadNewCSV();
    }

    public void LoadNewCSV()
    {
        TextAsset csv = Resources.Load<TextAsset>("level_" + level);
        data = csv.text.Split(new char[] { '\n' });

        string[] levelInfo = data[0].Split(new char[] { ',' });
        int.TryParse(levelInfo[0], out lives);
        int.TryParse(levelInfo[1], out gameSpeed);
        newLevelLoaded = false;
    }

    public string[] ReadSpawnRow(int i)
    {
        string[] row = data[i + 1].Split(new char[] { ',' });

        return row;
    }
}
