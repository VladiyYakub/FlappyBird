using UnityEngine;
public class PipeGeneration : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnpositionY;
    [SerializeField] private float _minSpawnpositionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnpositionY, _maxSpawnpositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;

                DisableObjectsAbroadScrean();
            }
        }
    }
}

    
