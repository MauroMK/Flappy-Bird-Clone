using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject tubePrefab;

    private float spawnRate = 1f;
    private float minHeight = -0.25f;
    private float maxHeight = 1.8f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnTube), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnTube));
    }

    private void SpawnTube()
    {
        GameObject tubes = Instantiate(tubePrefab, transform.position, Quaternion.identity);
        tubes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
