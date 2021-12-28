using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barrel_Base : MonoBehaviour
{
    [Header("Barrel Base Configuration")]
    public float ExitVelocity;
    public int RequiredBounces = 2;


    [Header("Debugging")]
    public InputHandler PassengerInput;
    public GameObject Passenger;
    public TextMeshPro BounceTMP;

    public void Start()
    {
        BounceTMP = GetComponentInChildren<TextMeshPro>();

        if (BounceTMP != null)
        {
            BounceTMP.text = RequiredBounces.ToString();
        }
    }

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

        PassengerInput = _player.GetComponent<Movement_Pinball>().IH;

        Passenger = _player;
        Rigidbody2D RB2D = Passenger.GetComponent<Rigidbody2D>();
        RB2D.velocity = Vector3.zero;
        RB2D.isKinematic = true;


        Passenger.transform.position = transform.position;
        Passenger.transform.SetParent(transform);

        //TEST CODE
        _player.GetComponent<BounceHandler>()?.ResolveBounces(RequiredBounces);
        _player.GetComponent<Dispatch_OnTick>()?.TurnOn();

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
    }

    public virtual void HandleMoveInput()
    {

    }

}
