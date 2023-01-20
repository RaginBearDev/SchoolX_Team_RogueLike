using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpGun : MonoBehaviour
{
    [SerializeField] Character character;
    private GameObject leftHandGun = null;
    private GameObject rightHandGun = null;
    private GameObject lastLeftHandGun, lastRightHandGun;
    private bool isRightHandFull = false;
    private bool isLeftHandFull = false;
    [SerializeField] AmmunitionUI leftHand, rightHand;
    private int lastRightGunAmmo, lastLeftGunAmmo;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        DroppedGun d = collision.GetComponent<DroppedGun>();
        
        if(d != null && Input.GetKey(KeyCode.V))
        {
            if(isRightHandFull)
            {
                Debug.Log(isRightHandFull);
                lastRightHandGun = rightHandGun.GetComponentInChildren<GunObject>().droppedGunPrefab;
                rightHandGun = SwapGun(lastRightHandGun, character.rightHand, d, collision.gameObject.transform, rightHandGun);
                rightHandGun.GetComponentInChildren<GunObject>().isRightHand = true;
                rightHand.MagazineRender(rightHandGun.GetComponentInChildren<GunObject>().magazineSize, rightHandGun.GetComponentInChildren<GunObject>().magazineSize);
                lastRightGunAmmo = rightHandGun.GetComponentInChildren<GunObject>().magazineSize;
                Destroy(collision.gameObject);


            }
            else
            {
                Debug.Log("PickUp");
                rightHandGun = EquipGun(character.rightHand, d);
                lastRightHandGun = rightHandGun.GetComponentInChildren<GunObject>().droppedGunPrefab;
                rightHandGun.GetComponentInChildren<GunObject>().isRightHand = true;
                isRightHandFull = true;
                Destroy(collision.gameObject);

                //rightHand.MagazineRender(rightHandGun.GetComponentInChildren<GunObject>().magazineSize, rightHandGun.GetComponentInChildren<GunObject>().magazineSize);
                //lastRightGunAmmo = rightHandGun.GetComponentInChildren<GunObject>().magazineSize;
            }

        }
        
        else if(d != null && Input.GetKey(KeyCode.C))
        {
            if(isLeftHandFull)
            {   
                Debug.Log("swap");
                leftHandGun = SwapGun(lastLeftHandGun, character.leftHand, d, collision.gameObject.transform, leftHandGun);
                lastLeftHandGun = leftHandGun.GetComponentInChildren<GunObject>().droppedGunPrefab;
                leftHandGun.GetComponentInChildren<GunObject>().isRightHand = false;
                leftHand.MagazineRender(leftHandGun.GetComponentInChildren<GunObject>().magazineSize, leftHandGun.GetComponentInChildren<GunObject>().magazineSize);
                lastLeftGunAmmo = leftHandGun.GetComponentInChildren<GunObject>().magazineSize;
            }
            else
            {       
                leftHandGun = EquipGun(character.leftHand, d);
                lastLeftHandGun = leftHandGun.GetComponentInChildren<GunObject>().droppedGunPrefab;
                leftHandGun.GetComponentInChildren<GunObject>().isRightHand = false;
                isLeftHandFull = true;
                //leftHand.MagazineRender(leftHandGun.GetComponentInChildren<GunObject>().magazineSize, leftHandGun.GetComponentInChildren<GunObject>().magazineSize);
                //lastLeftGunAmmo = leftHandGun.GetComponentInChildren<GunObject>().magazineSize;
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

    
    private GameObject SwapGun(GameObject equipedGun, Transform hand, DroppedGun droppedGun, Transform dgTransform, GameObject gunInHand)
    {
        GameObject droppedGunObj = Instantiate(equipedGun, dgTransform.position, dgTransform.rotation);
        Rigidbody2D rb = droppedGunObj.GetComponent<Rigidbody2D>();
        Destroy(gunInHand);
        return EquipGun(hand, droppedGun);
    }

    private void Update() 
    {
        rightHand.MagazineRender(rightHandGun.GetComponentInChildren<GunObject>().bulletRemaining, rightHandGun.GetComponentInChildren<GunObject>().magazineSize);
        leftHand.MagazineRender(leftHandGun.GetComponentInChildren<GunObject>().bulletRemaining, leftHandGun.GetComponentInChildren<GunObject>().magazineSize);
    }
}