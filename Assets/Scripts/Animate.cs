using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
   Animator animator;
   public bool walking;

   private void Awake()
   {
        animator = GetComponentInChildren<Animator>();
   }

   private void Update()
   {
        animator.SetBool("Walking", walking);
   }
}
