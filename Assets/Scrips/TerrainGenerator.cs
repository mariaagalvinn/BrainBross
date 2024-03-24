using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0,0,0);

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private void Start()
    {
        for(int i=0; i<maxTerrainCount; i++)
        {
            SpawnTerrain(true);
        }
        maxTerrainCount = currentTerrains.Count;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain(false);
        }
    }

    private void SpawnTerrain(bool isStart)
    {
        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int terrainSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
        for(int i=0; i<terrainSuccession; i++)
        {
            GameObject Terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
            Terrain.transform.SetParent(terrainHolder);
            currentTerrains.Add(Terrain);
            if(isStart)
            {
                if(currentTerrains.Count > maxTerrainCount)
                {
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            else
            {

            }
            currentPosition.x++;
        }
    }
}
