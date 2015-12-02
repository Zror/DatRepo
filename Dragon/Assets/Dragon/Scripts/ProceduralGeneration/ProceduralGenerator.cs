using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[RequireComponent(typeof(ProceduralWorldSettings))]
public class ProceduralGenerator : MonoBehaviour
{
    [Header("Game Object Pool")]
    public GameObject grass;
    public GameObject swamp;
    public GameObject dirt;
    public GameObject[] towers;
    public GameObject[] clouds;
    public GameObject[] storms;
    public GameObject[] coins;
    public GameObject[] haystacks;
    public GameObject[] livestocks;

    [Header("Generator Configuration")]
    [Tooltip("This origin will be reset at the start of the scene.")]
    public FloatingOrigin origin;

    public float border = 10;
    public float stepSize = 2;
    public float offset = 0;

    protected ProceduralWorldSettings settings;

    [Header("Spawn Counters (Debugging Display)")]
    public float towerSpawnCounter;
    public float cloudSpawnCounter;
    public float stormCloudSpawnCounter;
    public float coinSpawnCounter;
    public float haystackSpawnCounter;
    public float livestockSpawnCounter;

    protected void Start()
    {
        origin = FindObjectOfType<FloatingOrigin>();
        settings = GetComponent<ProceduralWorldSettings>();
        origin.OnOriginShift += PostShiftGeneration;

        this.transform.position = Vector3.left*origin.clearChildAfter;
        GenerateNewNodes();
    }

    protected void PostShiftGeneration(object sender, FloatingOriginShiftEventArgs args)
    {
        this.transform.position += Vector3.left*args.ShiftAmount;
        GenerateNewNodes();
    }

    protected void GenerateNewNodes()
    {
        while (this.transform.position.x < origin.transform.position.x + origin.maxOriginPoint + border)
        {
            CreateTerrainAtPosition();
            IncrementCounters();

            offset += stepSize;
            this.transform.position += Vector3.right*stepSize;
        }
    }

    protected void CreateTerrainAtPosition()
    {
        float grassValue = settings.GetValueFromCurveAtPosition(settings.grassRate, offset);
        float swampValue = settings.GetValueFromCurveAtPosition(settings.swampRate, offset);
        float dirtValue = settings.GetValueFromCurveAtPosition(settings.dirtRate, offset);

        GameObject inst = swamp;
        if (grassValue > swampValue && grassValue > dirtValue)
        {
            inst = grass;
        }
        else if (dirtValue > swampValue && dirtValue > grassValue)
        {
            inst = dirt;
        }

        GameObject created = (GameObject)Instantiate(inst, this.transform.position, this.transform.rotation);
        var sprites = created.GetComponents<SpriteRenderer>();
        foreach (var sprite in sprites)
        {
            sprite.sortingOrder = (int) offset;
        }
        created.transform.parent = origin.transform;
    }

    protected void IncrementCounters()
    {
        towerSpawnCounter += settings.GetValueFromCurveAtPosition(settings.towerRate, offset)*stepSize;
        cloudSpawnCounter += settings.GetValueFromCurveAtPosition(settings.cloudRate, offset)*stepSize;
        stormCloudSpawnCounter += settings.GetValueFromCurveAtPosition(settings.stormCloudRate, offset)*stepSize;
        coinSpawnCounter += settings.GetValueFromCurveAtPosition(settings.coinRate, offset)*stepSize;
        haystackSpawnCounter += settings.GetValueFromCurveAtPosition(settings.haystackRate, offset)*stepSize;
        livestockSpawnCounter += settings.GetValueFromCurveAtPosition(settings.livestockRate, offset)*stepSize;

        if (towerSpawnCounter > settings.towerSpawnAt)
        {
            towerSpawnCounter -= settings.towerSpawnAt;
            CreateTower();
        }

        if (cloudSpawnCounter > settings.cloudSpawnAt)
        {
            cloudSpawnCounter -= settings.cloudSpawnAt;
            CreateCloud();
        }

        if (stormCloudSpawnCounter > settings.stormCloudSpawnAt)
        {
            stormCloudSpawnCounter -= settings.stormCloudSpawnAt;
            CreateStormCloud();
        }

        if (coinSpawnCounter > settings.coinSpawnAt)
        {
            coinSpawnCounter -= settings.coinSpawnAt;
            CreateCoin();
        }

        if (haystackSpawnCounter > settings.haystackSpawnAt)
        {
            haystackSpawnCounter -= settings.haystackSpawnAt;
            CreateHaystack();
        }

        if (livestockSpawnCounter > settings.livestockSpawnAt)
        {
            livestockSpawnCounter -= settings.livestockSpawnAt;
            CreateLivestock();
        }
    }

    protected void CreateTower()
    {
        CreateObject(SelectOne(towers));
    }

    protected void CreateCloud()
    {

        CreateObject(SelectOne(clouds));
    }

    protected void CreateStormCloud()
    {

        CreateObject(SelectOne(storms));
    }

    protected void CreateCoin()
    {

        CreateObject(SelectOne(coins));
    }

    protected void CreateHaystack()
    {

        CreateObject(SelectOne(haystacks));
    }

    protected void CreateLivestock()
    {
        CreateObject(SelectOne(livestocks));
    }

    protected void CreateObject(GameObject template)
    {
        GameObject created = (GameObject)Instantiate(template, this.transform.position, this.transform.rotation);
        created.transform.parent = origin.transform; // Make a parent of the floating origin
    }

    protected TObject SelectOne<TObject>(TObject[] objects)
    {
        return objects[UnityEngine.Random.Range(0, objects.Length)];
    }
}