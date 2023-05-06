using UnityEngine;

public class RefactoredUIManager : UIManagerBase
{
    private static RefactoredUIManager instance;

    [SerializeField]
    private RefactoredPlayerController playerController;

    [SerializeField]
    private GameControllerBase gameController;

    public static RefactoredUIManager Instance { get => instance; private set => instance = value; }

    protected override PlayerControllerBase PlayerController => playerController;

    protected override GameControllerBase GameController => gameController;

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