using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LoadCSV loadCSV;

        // UI elements
        [SerializeField] int blocksCounter;

        public void IncrementBlocksCounter()
        {
            blocksCounter++;
        }

        public void DecrementBlocksCounter()
        {
            blocksCounter--;

            if (blocksCounter <= 0)
            {
                loadCSV.level++;
                GameObject.Find("Paddle").GetComponent<Paddle>().SetToOriginalPos();
                GameObject.Find("Ball").GetComponent<Ball>().HasBallBeenShot = false;
                GameObject.Find("GameSessionLoader").GetComponent<GameSessionLoader>().StartGameSession();
                loadCSV.LoadNewCSV();
            }
        }
    }


