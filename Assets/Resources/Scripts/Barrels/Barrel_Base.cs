using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrel_Base : MonoBehaviour
{
    [Header("Barrel Base Configuration")]
    public float ExitVelocity;

    [Header("Debugging")]
    public InputHandler PassengerInput;
    public GameObject Passenger;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Passenger == null)
            {
                BringInPlayer(collision.gameObject);
            }
        }
    }

    public void Update()
    {
        if (Passenger != null)
        {
            HandleMoveInput();
            HandleFireInput();
        }
    }



    public void BringInPlayer(GameObject _player)
    {
        if(_player.GetComponent("Alpha_Character") != null){
            //Modified for alternate character script
            Passenger = _player;
            Rigidbody2D RB2D = Passenger.GetComponent<Rigidbody2D>();
            RB2D.velocity = Vector3.zero;
            RB2D.isKinematic = true;


            Passenger.transform.position = transform.position;
            Passenger.transform.SetParent(transform);

        } else {
            //Previous character script, should fire normally
            PassengerInput = _player.GetComponent<Movement_Pinball>().IH;

            Passenger = _player;
            Rigidbody2D RB2D = Passenger.GetComponent<Rigidbody2D>();
            RB2D.velocity = Vector3.zero;
            RB2D.isKinematic = true;


            Passenger.transform.position = transform.position;
            Passenger.transform.SetParent(transform);

            //TEST CODE
            _player.GetComponent<Dispatch_OnTick>()?.TurnOn();
        }

    }
    public void ShootPlayerOut()
    {
        // TEST CODE
        Passenger.GetComponent<Dispatch_OnTick>()?.TurnOff();

        Passenger.transform.SetParent(null);
        Rigidbody2D RB2D = Passenger.GetComponent<Rigidbody2D>();
        RB2D.velocity = transform.up * ExitVelocity;
        RB2D.isKinematic = false;
        Passenger = null;
        PassengerInput = null;

    }

    public void HandleFireInput()
    {
        if (PassengerInput != null)
        {
            if (PassengerInput.AInputDown)
            {
                ShootPlayerOut();
            }
        }

        if(Passenger.GetComponent("Alpha_Character") != null){
            if (Input.GetKeyDown("space"))
            {
                ShootPlayerOut();
            }
        }
    }

    public virtual void HandleMoveInput()
    {

    }

}
