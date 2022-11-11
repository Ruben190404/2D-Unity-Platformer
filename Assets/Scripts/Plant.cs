using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timer = 0;
    [SerializeField] public float fireRate = 1f;
    // private bool _inCooldown = false;
    [SerializeField]private bool attack = false;
    private Animator anim;
    
    private enum State 
    {
        idle,
        attacking,
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimationState();
        anim.SetBool("Attacking", true);
    }

    void Shoot()
    {
        // _inCooldown = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // StartCoroutine(Cooldown());
    }
    //
    // private IEnumerator cooldownTimer()
    // {
    //     yield return new WaitForSeconds(fireRate);
    //     _inCooldown = false;
    // }

    private void UpdateAnimationState()
    {
        State state;
    
        if (attack)
        {
            state = State.attacking;
        }
        else
        {
            state = State.idle;
        }
        
        anim.SetInteger("state", (int)state);
    }
}
