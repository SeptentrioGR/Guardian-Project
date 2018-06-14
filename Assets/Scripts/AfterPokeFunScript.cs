using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterPokeFunScript : MonoBehaviour {

    private float fire_start_time;
    public string[] LinesToSay;
    private bool SaidSomething;
    private float timerToSaySomethingNew = 0;
    private float delayBeforeSaySomethingNew = 2;
    private float timeBeforeGettingBored = 60;

    private void Start()
    {
        timerToSaySomethingNew = delayBeforeSaySomethingNew;
    }

    void Update()
    {
        if (SaidSomething)
        {
            timerToSaySomethingNew -= Time.deltaTime;
            if(timerToSaySomethingNew < 0)
            {
                timerToSaySomethingNew = delayBeforeSaySomethingNew;
                SaidSomething = false;
            }
        }
        string[] joysticks = Input.GetJoystickNames();
     
        if (Input.anyKey || Input.GetButton(Constants.InteractKeyString) || Input.GetButton(Constants.m_FireButtonString) || Input.GetButton(Constants.JumpButtonString) || Game.Instance.GetPlayer().GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            //Debug.Log("Key Pressed");
            fire_start_time = Time.time;
            SpeechBubble.Instance.Stop();
        }
       
        if((Time.time - fire_start_time) > timeBeforeGettingBored)
        {          
            if (!SaidSomething)
            {
               // Debug.Log("elapsed time paseed");
                SaidSomething = true;
                SaySomething();
            }     
        }
     
    }

    public void SaySomething()
    {
        SpeechBubble.Instance.Speek(LinesToSay[Random.Range(0, LinesToSay.Length)],delayBeforeSaySomethingNew);
    }
    
}
