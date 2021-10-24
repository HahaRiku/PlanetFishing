using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour
{
    [SerializeField] private GameObject meteoritePrefab;

    void Start()
    {
        StartGenerating();
    }

    private void StartGenerating()
    {
        StartCoroutine(GenerateMeteorite(3));
    }

    IEnumerator GenerateMeteorite(float countTime)
    {
        Instantiate(meteoritePrefab, new Vector3(Random.Range(-40, 40), Random.Range(-16, 16), 10), Quaternion.identity);
        yield return new WaitForSeconds(countTime);
        StartCoroutine(GenerateMeteorite(3));
    }
}
