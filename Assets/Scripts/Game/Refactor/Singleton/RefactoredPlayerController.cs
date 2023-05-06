public class RefactoredPlayerController : PlayerControllerBase
{
    
    private static RefactoredPlayerController instance;
    protected override bool NoSelectedBullet => throw new System.NotImplementedException();

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