using UnityEngine;
public class EnemyWaveBuilder
{
    private GameObject _enemyPrefab;
    private float _duration;
    private int _enemyAmount;
    private float _delayBetweenSpawns;
    private float _xPosition;

    public EnemyWaveBuilder WithPrefab(GameObject enemyPrefab)
    {
        _enemyPrefab = enemyPrefab;
        return this;
    }

    public EnemyWaveBuilder WithDuration(float duration)
    {
        _duration = duration;
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

    public EnemyWave Build()
    {
        return new EnemyWave(_enemyPrefab, _duration, _enemyAmount, _delayBetweenSpawns, _xPosition);
    }
}

public class EnemyWave 
{
    private GameObject _enemiePrefab;
    private float _duration;
    private int _enemyAmount;
    private float _delayBetweenSpawns;
    private float _xPosition;

    public EnemyWave(GameObject prefab, float duration, int amount, float delay, float xPos)
    {
        _enemiePrefab = prefab;
        _duration = duration;
        _enemyAmount = amount;
        _delayBetweenSpawns = delay;
        _xPosition = xPos;
    }

    public GameObject enemyPrefab { get { return _enemiePrefab; } }
    public float Duration { get { return _duration; } }
    //public float SecondsToStart { get { return _secondsToStart}}
    public int EnemyAmount { get { return _enemyAmount; } }
    public float DelayBetweenSpawns { get { return _delayBetweenSpawns; } }
    public float XPosition { get { return _xPosition; } }
}
