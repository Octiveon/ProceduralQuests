using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject[] spawnables;
    [Range(0, 1000)]
    public int[] maxSpawned;
    [Range(0, 1000)]
    public int[] minSpawned;
    [Range(0,1)]
    public float[] minSpwnRange;
    [Range(0, 1)]
    public float[] maxSpwnRange;

    GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;
    }


    public void SpawnObjects(HeightMap heightMap, float multiplier , GameObject meshObject)
    {
        StartCoroutine(Spawn( heightMap, multiplier, meshObject));
    }


    IEnumerator Spawn(HeightMap heightMap, float multiplier, GameObject meshObject)
    {
        int x = 1;
        int z = 1;
        float y = 1;

        int index = 0;
        int range = 0;

        foreach (GameObject obj in spawnables)
        {
            range = Random.Range(minSpawned[index], maxSpawned[index]);
            for (int i = 0; i < minSpwnRange.Length || i < range; i++)
            {
                x = Random.Range(0, 172);
                z = Random.Range(0, 172);
                y = heightMap.values[x, z] / multiplier;
                int loopCnt = 0;

                if(y < minSpwnRange[index] || y > maxSpwnRange[index])
                {
                    while (y < minSpwnRange[index] || y > maxSpwnRange[index])
                    {
                        if (loopCnt > 500) { break; }
                        x = Random.Range(0, 172);
                        z = Random.Range(0, 172);
                        y = heightMap.values[x, z] / multiplier;
                        loopCnt++;
                    }
                }
                else
                {
                    Instantiate(spawnables[index], meshObject.transform.position + new Vector3(Random.Range(-170,170), y + multiplier, Random.Range(-170, 170)), Quaternion.identity, meshObject.transform);
                }


                yield return new WaitForSeconds(0.01f);

            }
            index++;
        }

        
    }
}
