using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
   public GameObject boss;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim=boss.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FinishAttack(string attack)
    {
        anim.SetBool(attack, false);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Ataque");
            
        }

    }*/
    public void AtaqueLanzallamas ()
    {
        anim.SetTrigger("Lanzallamas");
    }

    public void AtaqueMeleeGolpe (){
        
        anim.SetTrigger ("Ataque");
    }
}
