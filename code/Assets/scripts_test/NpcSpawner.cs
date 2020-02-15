using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnergyBar
{

    // Demo class
    // Spawns NCP prefabs
    // or any other objects

    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] GameObject npcPrefab;
        [SerializeField] int npcCount = 1;
        [SerializeField] Transform parent;

        void Start()
        {
            SpawnNPCs();
        }

        void SpawnNPCs()
        {
            for (int i = 0; i < npcCount; i++)
            {
                var clone = Instantiate(npcPrefab);
                var posx = Random.Range(0, 30f);
                var posz = Random.Range(0, 30f);

                clone.transform.position = new Vector3(posx, 1, posz);

                if (parent)
                    clone.transform.SetParent(parent);
            }
        }
        
    }

}