using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private Animator _anim;
    [Header ("Buttons")]
    public GameObject Buton;
    public GameObject Buton2;
    public GameObject Buton3;

    [Header("Vfx")]
    public ParticleSystem fireBall;
    public GameObject swordRain;
    
    Movement movement;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
        movement = GetComponent<Movement>();
        _anim = GetComponent<Animator>();

        fireBall.Stop();
        swordRain.SetActive(false);


        Buton.SetActive(true);
        Buton2.SetActive(true);
        Buton3.SetActive(true);

        StartCoroutine(Waittttt());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void GarenE()
    {
            _anim.SetTrigger("GarenE");
            StartCoroutine(Waittttt());
            Buton2.SetActive(false);
    }

    public void FireBall() 
    {
         
        _anim.SetTrigger("FireShoot");
        movement.playerSpeed = 0;
        fireBall.Play();

        StartCoroutine(Waittttt());
        StartCoroutine(CharacterFireWait());

        Buton.SetActive(false);

    }
    public void SwordRain ()
    {
        _anim.SetTrigger("SwordRain");
        

        movement.playerSpeed = 0;


        StartCoroutine(Waittttt());
        StartCoroutine(CharacterSwordWait());
        swordRain.SetActive(true);
        Buton3.SetActive(false);
    }

    IEnumerator Waittttt() 
    {
        swordRain.SetActive(false);
        yield return new WaitForSecondsRealtime(3f);

        Buton.SetActive(true);
        Buton2.SetActive(true);
        Buton3 .SetActive(true);
       


        Debug.Log("çalýþýyorr");
 
    }
    IEnumerator CharacterFireWait()
    {
        yield return new WaitForSecondsRealtime(1.75f);
        movement.playerSpeed = 3f;
        _anim.SetBool("Walk", false);
        _anim.SetBool("Run", false);
    }
    IEnumerator CharacterSwordWait()
    {
        yield return new WaitForSecondsRealtime(4f);
        movement.playerSpeed = 3f;
        _anim.SetBool("Walk", false);
        _anim.SetBool("Run", false);
    }
}


