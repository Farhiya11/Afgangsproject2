using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Unity.Services.Core;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class ExerciseController : MonoBehaviour
{
    [SerializeField] private GameObject exercise;

    private bool playerInRange;

    private void Awake()
    {
        exercise.SetActive(false);
        playerInRange = false;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    
    private void Update()
    {
        if(playerInRange)
        {
            exercise.SetActive(true);
        }
        else
        {
            exercise.SetActive(false);
        }

    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        playerInRange = false;   
    }


}