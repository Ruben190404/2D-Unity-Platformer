using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock : MonoBehaviour
{
    private CircleCollider2D col;

    private void Start()
    {
        col = GetComponent<CircleCollider2D>();
    }

    void Fire()
    {
        col.enabled = true;
    }

    void EndFire()
    {
        col.enabled = false;
        
    }
}