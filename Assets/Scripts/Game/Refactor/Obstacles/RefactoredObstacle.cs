public abstract class RefactoredObstacle : ObstacleBase
{
    private static GameControllerBase gameController;

    //private static GameController gameController;

    protected override GameControllerBase GameController
    {
        get
        {
            if (gameController == null)
            {
                gameController = FindObjectOfType<RefactoredGameController>();
            }

            return gameController;
        }
    }

    protected override void DestroyObstacle(bool notify = false)
    {
        if (notify)
        {
            
            //GameController?.SendMessage("OnObstacleDestroyed", HP);
        }

        Destroy(gameObject);
    }
}