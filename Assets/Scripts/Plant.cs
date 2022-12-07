using UnityEngine;


public class Plant : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0;
    [SerializeField] public float fireRate = 1f;
    private Animator anim;
    [SerializeField]private bool Animend;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Attacking", true);
        Animend = false;
    }
    
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void animStart()
    {
        anim.SetBool("Attacking", true);
        Animend = false;
    }

    void animEnd()
    {
        anim.SetBool("Attacking", false);
        Animend = true;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CircleCollider2D))
        {
            anim.SetTrigger("Hit");
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
