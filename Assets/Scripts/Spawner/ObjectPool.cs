using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for(int i = 0; i < _capacity; i++)
        {
            AddObjectToPool(prefab);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for(int i = 0; i < _capacity; i++)
        {
            int index = Random.Range(0, prefabs.Length);

            AddObjectToPool(prefabs[index]);
        }
    }

    protected void Initialize(GameObject[] scoreObjects, GameObject[] enemies, float ratio)
    {
        int i = 0;
        int numberOfCollectables = (int)(_capacity * ratio);

        for(; i < numberOfCollectables; i++)
        {
            int index = Random.Range(0, scoreObjects.Length);

            AddObjectToPool(scoreObjects[index]);
        }

        for(; i < _capacity; i++)
        {
            int index = Random.Range(0, enemies.Length);

            AddObjectToPool(enemies[index]);
        }
    }

    protected void AddObjectToPool(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        if (result)
        {
            _pool.Remove(result);
            int randomIndex = Random.Range(0, _capacity);
            _pool.Insert(randomIndex, result);
        }

        return result != null;
    }
}
