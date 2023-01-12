using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Transform bar;
    
    public void SetState(float currentHp, float maxHp ){
        
        float state = currentHp;
        state /= maxHp;
        if(state < 0f)
        {
            state = 0f;
        }
        bar.transform.localScale =  new Vector3(state, 1f, 1f);
    }
}