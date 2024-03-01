using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private Animator _anim;
    public GameObject Buton;
    public GameObject Buton2;
    public ParticleSystem fireBall;

    Movement movement;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        _anim = GetComponent<Animator>();

        fireBall.Stop();
        Buton.SetActive(true);
        Buton2.SetActive(true);

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
        StartCoroutine(CharacterWait());

        Buton.SetActive(false);

    }

    IEnumerator Waittttt() 
    {
        yield return new WaitForSecondsRealtime(3f);

        Buton.SetActive(true);
        Buton2.SetActive(true);


        Debug.Log("çalýþýyorr");
 
    }
    IEnumerator CharacterWait()
    {
        yield return new WaitForSecondsRealtime(1.75f);
        movement.playerSpeed = 3f;
        _anim.SetBool("Walk", false);
        _anim.SetBool("Run", false);
    }
}


