using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator animator;
    private GameObject [] Health;
    private int PHealth;
    // Start is called before the first frame update
    void Start()
    {

        Health = GameObject.FindGameObjectsWithTag("HUDHealth");

    }

    // Update is called once per frame
    void Update()
    {
        PHealth = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>().PlayerHealth;

        Health[PHealth].SetActive(false);
        if (PHealth == 1)
        {
            animator.SetBool("IsOneHP", true);
        }
    }


}
