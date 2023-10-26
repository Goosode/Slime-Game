using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    private float maxStamina = 100;
    private float stamina;
    public Slider staminaBar;
    public static bool isRunning;

    [SerializeField]
    private AudioSource SprintSFX;

    void Awake() {
        stamina = maxStamina;
    }

    void Update()
    {
        if(Input.GetButtonDown("Sprint")){
            SprintSFX.Play();
        }

        //if push left shift use stamina
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0){
            isRunning = true;
            stamina -= 1f;

        }

        else{
            isRunning = false;
        }

        //if not push left shift re charge stamina
        if(stamina < 100 && !Input.GetKey(KeyCode.LeftShift)){
            stamina += 0.16f;
        }

        //stamina bar 
        if(staminaBar != null){
            staminaBar.value = stamina / maxStamina;
        }
    }
}
