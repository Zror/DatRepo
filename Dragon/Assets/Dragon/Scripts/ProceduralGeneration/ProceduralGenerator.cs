using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject root;
    private ProceduralObject lastSpawned;

    public float spawnX;
    public float endSpawn;

    protected void Start()
    {
        GenerateAll();
        SpawnObject(root);
    }

    private void GenerateAll()
    {
        SpawnObject(root);
        var initialSpawn = lastSpawned;

        LinkedList<ProceduralObject> spawned = new LinkedList<ProceduralObject>();
        spawned.AddFirst(initialSpawn);

        while (initialSpawn.transform.position.x > endSpawn)
        {
            foreach (var obj in spawned)
            {
                obj.transform.position = new Vector3(obj.transform.position.x - (this.transform.position.x  - spawnX), this.transform.position.y, this.transform.position.z);
            }
            GenerateNext();
            spawned.AddLast(lastSpawned);
        }
    }

    protected void Update()
    {
        if (lastSpawned.transform.position.x < spawnX)
        {
            GenerateNext();
        }
    }

    public void GenerateNext()
    {
        SpawnObject(SelectNextSpawn());
    }

    private void SpawnObject(GameObject instance)
    {
        GameObject spawned = (GameObject) Instantiate(instance, this.transform.position, this.transform.rotation);
        lastSpawned = spawned.GetComponent<ProceduralObject>();

    }

    private GameObject SelectNextSpawn()
    {;
        return lastSpawned.potentialNextNodes[Random.Range(0, lastSpawned.potentialNextNodes.Length)];
    }
}