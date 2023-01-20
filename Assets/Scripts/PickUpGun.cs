using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    [SerializeField] Character character;
    private GameObject leftHandGun = null;
    private GameObject rightHandGun = null;
    private GameObject lastLeftHandGun, lastRightHandGun;
    private bool isRightHandFull, isLeftHandFull;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        DroppedGun d = collision.GetComponent<DroppedGun>();
        
        if(d != null && Input.GetKey(KeyCode.V))
        {
            if(isRightHandFull)
            {
                rightHandGun = SwapGun(lastRightHandGun, character.rightHand, d, collision.gameObject.transform);
            }
            else
            {
                GameObject lastRightHandGun = d.droppedGunPrefab;
                GameObject rightHandGun = EquipGun(character.rightHand, d);
                isRightHandFull = true;      
            }
            Destroy(collision.gameObject);
        }
        
        else if(d != null && Input.GetKey(KeyCode.C))
        {
            if(isLeftHandFull)
            {   
                leftHandGun = SwapGun(lastLeftHandGun, character.leftHand, d, collision.gameObject.transform);
                Animate.gunId = d.gunId;
            }
            else
            {       
                GameObject leftHandGun = EquipGun(character.leftHand, d);
                GameObject lastLeftHandGun = d.droppedGunPrefab;
                isLeftHandFull = true;
                Animate.gunId = d.gunId;
            }
            Destroy(collision.gameObject);
        }
    }


    private GameObject EquipGun(Transform hand, DroppedGun droppedGun)
    {
        GameObject gun = Instantiate(droppedGun.equipedGunPrefab, hand.position, hand.rotation, hand);
        Rigidbody2D rb = gun.GetComponent<Rigidbody2D>();
        return gun;
    }

    
    private GameObject SwapGun(GameObject equipedGun, Transform hand, DroppedGun droppedGun, Transform dgTransform)
    {
        GameObject droppedGunObj = Instantiate(equipedGun, dgTransform.position, dgTransform.rotation);
        Rigidbody2D rb = droppedGunObj.GetComponent<Rigidbody2D>();
        Destroy(equipedGun);
        return EquipGun(hand, droppedGun);
    }
}