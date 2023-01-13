using System;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public StarterAssetsInputs starterAssets;
    public Animator animator;
    
    [SerializeField] private bool isTrash=false;
    [SerializeField] private bool isMoving = false;

    private void Update()
    {
        isMoving = starterAssets.move.x != 0 || starterAssets.move.y != 0;
        if (isMoving)
        {
            animator.SetInteger("Move", 1);
        }
        else if (isTrash)
        {
            animator.SetInteger("Move", 2);
        }
        else
        {
            animator.SetInteger("Move", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            isTrash = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            isTrash = false;
        }
    }
}
