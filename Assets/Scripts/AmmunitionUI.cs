using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUI : MonoBehaviour
{
    [SerializeField] Text leftHandGunAmmoText;
    [SerializeField] GameObject ammoContainer;

    public void MagazineRender(int bulletRemaining, int magazineSize)
    {   
        Debug.Log("lol");
        ammoContainer.SetActive(true);
        leftHandGunAmmoText.text = bulletRemaining.ToString() + "|" + magazineSize.ToString(); 
        
    }
}
