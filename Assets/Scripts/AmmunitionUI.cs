using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI rightHandGunAmmoText;
    [SerializeField] TMPro.TextMeshProUGUI leftHandGunAmmoText;
    public bool isRightHanded;


    public void MagazineRender(int bulletRemaining, int magazineSize)
    {
        if(isRightHanded)
        {
            rightHandGunAmmoText.text = bulletRemaining.ToString() + "|" + magazineSize.ToString(); 
        }
        else
        {
            leftHandGunAmmoText.text = bulletRemaining.ToString() + "|" + magazineSize.ToString(); 
        }
    }
}
