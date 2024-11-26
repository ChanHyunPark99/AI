using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    // Audio
    [Header("Audio")]
    public AudioClip shootSound; // ���� Ŭ�� �߰�
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource ������Ʈ �������� �Ǵ� �߰��ϱ�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Play shoot sound
        if (shootSound && audioSource)
        {
            audioSource.PlayOneShot(shootSound); // ���� �� �� ���
        }

        // Get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Direction from player to mouse
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        // Create and shoot bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y) * bulletSpeed;

        // Destroy bullet after 2 seconds
        Destroy(bullet, 2f);
    }
}
