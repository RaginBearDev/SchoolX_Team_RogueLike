using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimationController : MonoBehaviour
{
   [HideInInspector] public bool walking;
   [HideInInspector] public static int gunId;

   Animator animator;
   int activeLayer;  

   private void Awake()
   {
        animator = GetComponentInChildren<Animator>();
        activeLayer = animator.GetLayerIndex("Unarmed");
   }

   private void Update()
   {
     animator.SetBool("Walking", walking);
     animator.SetInteger("GunId", gunId);

     switch(gunId)
     {
          case 3:
               animator.SetLayerWeight(activeLayer, 0);
               animator.SetLayerWeight(animator.GetLayerIndex("Shotgun"), 1);
               activeLayer = animator.GetLayerIndex("Shotgun");
               break;

          case 2:
               animator.SetLayerWeight(activeLayer, 0);
               animator.SetLayerWeight(animator.GetLayerIndex("Carabine"), 1);
               activeLayer = animator.GetLayerIndex("Carabine");
               break;

          case 1:
               animator.SetLayerWeight(activeLayer, 0);
               animator.SetLayerWeight(animator.GetLayerIndex("Revolver"), 1);
               activeLayer = animator.GetLayerIndex("Revolver");
               break;

          case 0:
               animator.SetLayerWeight(activeLayer, 0);
               animator.SetLayerWeight(animator.GetLayerIndex("Unarmed"), 1);
               activeLayer = animator.GetLayerIndex("Unarmed");
               break;
     }
     
     Debug.Log(activeLayer);
   }
}
