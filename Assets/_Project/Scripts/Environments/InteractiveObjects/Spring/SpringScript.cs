using System.Reflection;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;

    void Start()
    {
        anim=GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            anim.SetBool("OnSpring",true);
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            anim.SetBool("OnSpring",false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
