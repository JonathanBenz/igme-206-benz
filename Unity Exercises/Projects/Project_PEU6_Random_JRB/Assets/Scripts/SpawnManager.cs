using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] int amountToSpawnMin = 2;
    [SerializeField] int amountToSpawnMax = 8;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject creaturePrefab;

    const int Elephant = 0;
    const int Turtle = 1;
    const int Snail = 2;
    const int Octopus = 3;
    const int Kangaroo = 4;

    List<GameObject> currentlySpawnedCreatures = new List<GameObject>();
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    /// <summary>
    /// Spawns in a new random amount of creatures.
    /// </summary>
    public void Spawn()
    {
        CleanUp();
        int amountToSpawn = Random.Range(amountToSpawnMin, amountToSpawnMax);
        for(int i=0; i<amountToSpawn; i++)
        {
            GameObject newlySpawnedCreature = SpawnCreature();
            currentlySpawnedCreatures.Add(newlySpawnedCreature);
        }
    }
    /// <summary>
    /// Instantiates a new creature with a random sprite and a random color. Uses Gaussian distribution when spawning in position. 
    /// The random creatures spawned use a non-uniform random (they have specified spawn rates).
    /// </summary>
    /// <returns> GameObject instance of the instantiated creature. </returns>
    private GameObject SpawnCreature()
    {

        // Instantiating the new creature.
        GameObject newCreature = Instantiate(creaturePrefab, this.transform);

        // Getting a random sprite in the Sprite Renderer
        SpriteRenderer newCreatureSpriteRenderer = newCreature.GetComponent<SpriteRenderer>();

        float randomfloat = Random.Range(0f, 1f);
        // 25% chance of spawning an Elephant
        if(randomfloat <= .25)
        {
            newCreatureSpriteRenderer.sprite = sprites[Elephant];
        }
        // 20% chance of spawning a Turtle (.25 + .20 = .45)
        else if(randomfloat <= .45)
        {
            newCreatureSpriteRenderer.sprite = sprites[Turtle];
        }
        // 15% chance of spawning a Snail (.45 + .15 = .60)
        else if(randomfloat <= .60)
        {
            newCreatureSpriteRenderer.sprite = sprites[Snail];
        }
        // 10% chance of spawning an Octopus (.60 + .10 = .70) 
        else if(randomfloat <= .70)
        {
            newCreatureSpriteRenderer.sprite = sprites[Octopus];
        }
        // 30% chance of spawning a Kangaroo (.70 + .30 = 1.0)
        else
        {
            newCreatureSpriteRenderer.sprite = sprites[Kangaroo];
        }

        // Getting a random color in the Sprite Renderer
        newCreatureSpriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

        // Getting a random position using Gaussian function. Position will be within 2 standard deviations from the center.
        float randomXPos = Gaussian(0, 2);
        float randomYPos = Gaussian(0, 2);
        newCreature.transform.position = new Vector2(randomXPos, randomYPos);

        return newCreature;

    }
    /// <summary>
    /// Destroys all currently spawned creatures.
    /// </summary>
    private void CleanUp()
    {
        foreach(GameObject o in currentlySpawnedCreatures)
        {
            Destroy(o);
        }
        currentlySpawnedCreatures.Clear();
    }
    /// <summary>
    /// Function to generate random Gaussian data.
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

}
