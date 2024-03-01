using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skils : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GarenE()
    {
        WaitS();
        _anim.Play("GarenE");
    }
    IEnumerator WaitS()
    {
        yield return new WaitForSeconds(5);
    }
}


