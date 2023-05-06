public class RefactoredUIManager : UIManagerBase
{
    private static RefactoredUIManager instance;
    protected override PlayerControllerBase PlayerController => throw new System.NotImplementedException();

    protected override GameControllerBase GameController => throw new System.NotImplementedException();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}