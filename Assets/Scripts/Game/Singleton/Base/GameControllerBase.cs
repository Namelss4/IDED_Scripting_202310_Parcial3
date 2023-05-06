using UnityEngine;

public abstract class GameControllerBase : MonoBehaviour
{
    [SerializeField]
    private float playTime = 60F;

    public float RemainingPlayTime { get; private set; }

    protected abstract PlayerControllerBase PlayerController { get; }
    protected abstract UIManagerBase UiManager { get; }

    protected abstract ObstacleSpawnerBase Spawner { get; }

    protected abstract void OnScoreChanged(int scoreAdd);

    protected void OnObstacleDestroyed(int hp)
    {
        OnScoreChanged(hp);
    }

    protected virtual void SetGameOver()
    {
        enabled = false;
    }

    private void Start()
    {
        RemainingPlayTime = playTime;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        RemainingPlayTime -= Time.deltaTime;

        if (RemainingPlayTime <= 0F)
        {
            RemainingPlayTime = 0F;
            SetGameOver();
        }
    }
}