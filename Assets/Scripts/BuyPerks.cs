using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPerks : MonoBehaviour
{   
    
    public int fireRateCost;
    public int damageCost;
    public int piercingCost;
    public int damageIncrease;
    public int fireRateIncrease;
    public int ammoCost;
    public GameObject player;
    // Start is called before the first frame update

    public void BuyFireRateIncrease(){
        if(fireRateCost <= player.GetComponent<SoulCount>().souls){
            player.GetComponent<SoulCount>().souls -= fireRateCost;
            print("firerate increase");
            for (int i = 0; i < gameObject.transform.childCount; i++) {
                if (gameObject.transform.GetChild(i).tag== "Gun") {
                    gameObject.transform.GetChild(i).GetComponent<Gun>().IncreaseFireRate(fireRateIncrease);
                }
            }
        }
        

    }
    public void BuyDamageIncrease(){
        if(damageCost <= player.GetComponent<SoulCount>().souls){
            player.GetComponent<SoulCount>().souls -= damageCost;
            print("damage increase");
            for (int i = 0; i < gameObject.transform.childCount; i++) {
                if (gameObject.transform.GetChild(i).tag== "Gun") {
                    gameObject.transform.GetChild(i).GetComponent<Gun>().IncreaseGunDamage(damageIncrease);
                }else{ //melee
                    gameObject.transform.GetChild(i).GetComponent<BasebatAttack>().damage += damageIncrease;
                }
            }
         }
    }
    public void BuyPiercingIncrease(){
        if(piercingCost <= player.GetComponent<SoulCount>().souls){
            print("piercing increase");
            player.GetComponent<SoulCount>().souls -= piercingCost;
            for (int i = 0; i < gameObject.transform.childCount; i++) {
                if (gameObject.transform.GetChild(i).tag== "Gun") {
                    gameObject.transform.GetChild(i).GetComponent<Gun>().IncrementPiercing();
                }
            }
        }
    }
    public void BuyAmmoIncrease(){
        if(ammoCost <= player.GetComponent<SoulCount>().souls){
            print("ammo increase");
            player.GetComponent<SoulCount>().souls -= ammoCost;
            for (int i = 0; i < gameObject.transform.childCount; i++) {
                if (gameObject.transform.GetChild(i).tag== "Gun") {
                    gameObject.transform.GetChild(i).GetComponent<Gun>().IncreaseMaxAmmo();
                }
            }
        }
    }
}
