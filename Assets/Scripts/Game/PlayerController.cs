using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player = new Player();

    [Header("Movement params")]
    [SerializeField]
    [Range(20F, 50F)]
    private float speed = 20F;

    [Header("Shoot params")]
    [SerializeField]
    private Rigidbody[] bulletPrefabs;

    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    [Range(0F, 500F)]
    private float shootForce = 250F;

    private Rigidbody selectedBullet;

    private float
        hVal = 0F,
        minXPos,
        maxXPos,
        defaultYPos,
        validXPos;

    private Vector2 moveDirection;

    public string PlayerScore { get => player?.Score.ToString(); }

    private void Start()
    {
        float playerWidth = GetComponent<Collider>().bounds.size.x;

        maxXPos = GameUtils.GetScreenDimensions().GetUseableScreenWidth(GameUtils.SCREEN_WIDTH_PERCENT) - playerWidth;
        minXPos = -maxXPos + playerWidth;

        defaultYPos = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        hVal = Input.GetAxis("Horizontal");
        Vector2 moveDirection = (new Vector2(hVal, 0).normalized) * speed * Time.deltaTime;
        validXPos = Mathf.Clamp(transform.position.x + moveDirection.x, minXPos, maxXPos);

        transform.position = new Vector3(validXPos, defaultYPos, 0F);

        ProcessShooting();
    }

    private void ProcessShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Fire
            if (selectedBullet == null)
            {
                SelectBullet(0);
            }

            if (spawnPos != null)
            {
                Instantiate(selectedBullet, spawnPos.position, spawnPos.rotation).AddForce(transform.forward * shootForce, ForceMode.Force);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectBullet(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectBullet(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectBullet(2);
        }
    }

    private void SelectBullet(int index)
    {
        selectedBullet = bulletPrefabs[GameUtils.GetClampedValue(index, bulletPrefabs.Length)];
    }
}