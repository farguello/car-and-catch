using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GeneratePrefab", 0.0f, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[randomIndex];
        Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, 200), prefab.transform.rotation);

    }
}
