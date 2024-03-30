using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.XR;

public class WeaponStats : MonoBehaviour
{
    float attack;
    float totalAttack;
    public float weaponDmg;

    public GameObject damageText;
    public Camera mainCamera;

    PlayerController player;
    void Start()
    {
        player = GetComponent<PlayerController>();
        attack = player.damage;
       
    }


    void Update()
    {

    }

    public float DamageInput()
    {
        totalAttack = attack + weaponDmg;
        float finalAttack = Mathf.Round(Random.Range(totalAttack - 4, totalAttack + 4));
        //Damage TEXT UI
        //GameObject textDam = Instantiate(damageText, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);

        GameObject textDam = Instantiate(damageText, transform.position + Vector3.up * 5f, Quaternion.identity);
        textDam.GetComponent<TextMeshPro>().SetText(finalAttack.ToString());
        textDam.transform.rotation = Quaternion.LookRotation(textDam.transform.position - mainCamera.transform.position);
        textDam.GetComponent<TextMeshPro>().SetText(finalAttack.ToString());
        Destroy(textDam, 2f);

        //Crit Attack
        if (finalAttack > attack + 3)
        {

            finalAttack *= 2;
            textDam.GetComponent<TextMeshPro>().SetText("CRIT!\n" + finalAttack.ToString());
        }
        return finalAttack;

    }
}
