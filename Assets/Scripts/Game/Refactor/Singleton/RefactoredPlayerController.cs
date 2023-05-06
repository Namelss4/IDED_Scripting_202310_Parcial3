using UnityEditor;

public class RefactoredPlayerController : PlayerControllerBase
{
    
    private static RefactoredPlayerController instance;
    public static RefactoredPlayerController Instance { get => instance; private set => instance = value; }
    protected override bool NoSelectedBullet => throw new System.NotImplementedException();

    public delegate void OnScoreChangedEvent(int scoreAdd);

    public delegate void OnBulletSelected(int index);

    public event OnScoreChangedEvent onScoreChangedEvent;

    public event OnBulletSelected onBulletSelected;

    protected override void Shoot()
    {
        //base.Shoot();
    }

    protected override void SelectBullet(int index)
    {
        //base.SelectBullet(index);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}