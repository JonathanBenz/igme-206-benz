// Author Jonathan Benz
using UnityEngine;

/// <summary>
/// This script spawns our snowmen!
/// </summary>
public class CreatureSpawner : MonoBehaviour
{
    // We set a reference to our Snowman prefab in the editor here
    [SerializeField] GameObject creaturePrefab;

    // Variables to store three separate spawn positions
    [SerializeField] Vector3 spawn1Pos;
    [SerializeField] Vector3 spawn2Pos;
    [SerializeField] Vector3 spawn3Pos;
    // Start is called before the first frame update
    void Start()
    {
        // Spawning our three snowmen in three different locations
        GameObject.Instantiate(creaturePrefab, spawn1Pos, Quaternion.identity);
        GameObject.Instantiate(creaturePrefab, spawn2Pos, Quaternion.identity);
        GameObject.Instantiate(creaturePrefab, spawn3Pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
