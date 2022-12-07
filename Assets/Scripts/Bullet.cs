using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] private float BulletDie = 1f;
    private void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void Update()
    {
        Destroy(gameObject, BulletDie);
    }
}
