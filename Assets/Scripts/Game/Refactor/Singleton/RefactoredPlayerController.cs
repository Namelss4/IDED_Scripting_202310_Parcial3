using UnityEditor;
using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    
    private static RefactoredPlayerController instance;
    public static RefactoredPlayerController Instance { get => instance; private set => instance = value; }
    protected override bool NoSelectedBullet => selectedBulletPool == null;

    public delegate void OnScoreChangedEvent(int scoreAdd);

    public delegate void OnBulletSelected(int index);

    public event OnScoreChangedEvent onScoreChangedEvent;

    public event OnBulletSelected onBulletSelected;

    [SerializeField]
    private PoolBase bulletLowPool;

    [SerializeField]
    private PoolBase bulletMidPool;

    [SerializeField]
    private PoolBase bulletHardPool;

    private PoolBase selectedBulletPool;

    protected override void Shoot()
    {
        selectedBulletPool.RetrieveInstance(); //this should not instantiate stuff like this, this should get the shooting point and some sort of velocity, but I honestly do not know how to change the pooling method to do so

    }

    protected override void SelectBullet(int index)
    {
        switch (index)
        {
            case 0: 
                selectedBulletPool = bulletLowPool;
                break;

            case 1:
                selectedBulletPool = bulletMidPool;
                break;

            case 2: 
                selectedBulletPool= bulletHardPool;
                break;
        }
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