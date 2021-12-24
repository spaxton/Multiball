using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Base : MonoBehaviour
{
    [Header("Barrel Base Configuration")]
    public Dispatcher BarrelEnterDispatcher;
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

        BarrelEnterDispatcher?.ActivateDispatcher(_player);
        PassengerInput = _player.GetComponent<Movement_Pinball>().IH;
        
        Passenger = _player;
        Passenger.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Passenger.transform.position = transform.position;
        Passenger.transform.SetParent(transform);
    }

    public void ShootPlayerOut()
    {
        Passenger.transform.SetParent(null);
        Passenger.GetComponent<Rigidbody2D>().velocity = transform.up * ExitVelocity;
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
