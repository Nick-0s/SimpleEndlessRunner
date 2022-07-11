using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _scoreObjects;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private float _rateOfScoreObjects;

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnPeriod;
    private bool _isWorking = true;

    private void OnValidate()
    {
        _rateOfScoreObjects = Mathf.Clamp(_rateOfScoreObjects, 0, 1);
    }

    private void Start()
    {
        Initialize(_scoreObjects, _enemies, _rateOfScoreObjects);
        StartCoroutine(Spawn());        
    }

    public void Stop()
    {
        _isWorking = false;
    }

    private IEnumerator Spawn()
    {
        var waitForSpawnPeriod = new WaitForSeconds(_spawnPeriod);

        while(_isWorking)
        {
            yield return TrySpawnObject() ? waitForSpawnPeriod : null;
        }
    }

    private bool TrySpawnObject()
    {
        if(TryGetObject(out GameObject objectToSpawn))
        {
            int pointIndex = Random.Range(0, _spawnPoints.Length);

            SetObject(objectToSpawn, _spawnPoints[pointIndex].position);
        }

        return objectToSpawn != null;
    }

    private void SetObject(GameObject objectToSet, Vector3 spawnPoint)
    {
        objectToSet.transform.position = spawnPoint;
        objectToSet.SetActive(true);
    }
}
