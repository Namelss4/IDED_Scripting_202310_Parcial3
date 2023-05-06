using UnityEngine;

public sealed class GameController : GameControllerBase
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private ObstacleSpawner obstacleSpawner;

    protected override PlayerControllerBase PlayerController => playerController;

    protected override UIManagerBase UiManager => uiManager;

    protected override ObstacleSpawnerBase Spawner => obstacleSpawner;

    protected override void OnScoreChanged(int scoreAdd)
    {
        PlayerController?.SendMessage("UpdateScore", scoreAdd);
        UiManager?.SendMessage("UpdateScoreLabel");
    }

    protected override void SetGameOver()
    {
        UiManager?.SendMessage("OnGameOver");
        PlayerController?.SendMessage("OnGameOver");
        Spawner?.SendMessage("OnGameOver");
        base.SetGameOver();
    }
}