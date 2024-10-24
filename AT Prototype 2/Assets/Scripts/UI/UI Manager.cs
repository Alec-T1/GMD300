using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator animator;
    public GameObject PointModule;
    private GameObject [] Health;
    private int PHealth;
    private bool n = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Health = GameObject.FindGameObjectsWithTag("HUDHealth");

    }

    // Update is called once per frame
    void Update()
    {
        
        PHealth = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().PlayerHealth;
        if (PHealth < 3)
        {
            Health[PHealth].SetActive(false);
        }
       
        if (PHealth == 1)
        {
            Debug.Log("One HP");
            animator.SetTrigger("ShowHealth");

        }
    }

    private void test()
    {

    }


}
