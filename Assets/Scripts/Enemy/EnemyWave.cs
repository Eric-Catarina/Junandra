using UnityEngine;

public class EnemyWaveBuilder
{
    private GameObject _enemyPrefab;
    private int _enemyAmount;
    private float _delayBetweenSpawns;
    private float _xPosition;
    private float _secondsToStart;

    public EnemyWaveBuilder WithPrefab(GameObject enemyPrefab)
    {
        _enemyPrefab = enemyPrefab;
        return this;
    }

    public EnemyWaveBuilder WithAmount(int enemyAmount)
    {
        _enemyAmount = enemyAmount;
        return this;
    }

    public EnemyWaveBuilder WithDelay(float delayBetweenSpawns)
    {
        _delayBetweenSpawns = delayBetweenSpawns;
        return this;
    }

    public EnemyWaveBuilder WithXPosition(float xPosition)
    {
        _xPosition = xPosition;
        return this;
    }

    public EnemyWaveBuilder WithSecondsToStart(float secondsToStart)
    {
        _secondsToStart = secondsToStart;
        return this;
    }

    public EnemyWave Build()
    {
        return new EnemyWave(_enemyPrefab, _enemyAmount, _delayBetweenSpawns, _xPosition, _secondsToStart);
    }
}

public class EnemyWave 
{
    private GameObject _enemiePrefab;
    private int _enemyAmount;
    private float _delayBetweenSpawns;
    private float _xPosition;
    private float _secondsToStart;

    public EnemyWave(GameObject prefab, int amount, float delay, float xPos, float secondsToStart)
    {
        _enemiePrefab = prefab;
        _enemyAmount = amount;
        _delayBetweenSpawns = delay;
        _xPosition = xPos;
        _secondsToStart = secondsToStart;
    }

    public GameObject enemyPrefab { get { return _enemiePrefab; } }
    public int EnemyAmount { get { return _enemyAmount; } }
    public float DelayBetweenSpawns { get { return _delayBetweenSpawns; } }
    public float XPosition { get { return _xPosition; } }
    public float SecondsToStart { get { return _secondsToStart; } }
}
