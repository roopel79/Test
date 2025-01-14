using UnityEngine;

public class Hero : MonoBehaviour
{
    public Animator hero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            hero.Play("run");
        }
        else if(Input.GetKeyDown(KeyCode.A) == true)
        {
            hero.SetTrigger("attack");
            //hero.Play("attack");
        }
        
    }
}
