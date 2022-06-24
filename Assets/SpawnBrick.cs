using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW;

namespace QFSW.MOP2
{
    public class SpawnBrick : MonoBehaviour
    {
        public LoadCSV loadCSV;

        public ObjectPool oneHitPool;
        public ObjectPool twoHitPool;
        public ObjectPool unbreakablePool;
        public ObjectPool transparentPool;

        const float stepx = 1f;
        const float stepy = 1f;

        private void Update()
        {
            if (!loadCSV.newLevelLoaded)
            {
                oneHitPool.ReleaseAll();
                twoHitPool.ReleaseAll();
                unbreakablePool.ReleaseAll();
                transparentPool.ReleaseAll();

                for (int i = 0; i < 6; i++)
                {
                    string[] row = loadCSV.ReadSpawnRow(i);
                    for (int j = 0; j < 16; j++)
                    {
                        Vector3 position = new Vector3(0.5f + stepx * j, 10.5f - i * stepy, 0);
                        if (int.Parse(row[j]) == 0)
                        {
                            transparentPool.GetObject(position);
                        }
                        else if (int.Parse(row[j]) == 1)
                        {
                            oneHitPool.GetObject(position);
                        }
                        else if (int.Parse(row[j]) == 2)
                        {
                            twoHitPool.GetObject(position);
                        }
                        else if (int.Parse(row[j]) == -1)
                        {
                            unbreakablePool.GetObject(position);
                        }
                    }

                    loadCSV.newLevelLoaded = true;
                }
            
                
            }
        }
    }
}
