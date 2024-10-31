using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator _animator;
    private bool isPlayerOnElevator = false; // Tracks if the player is on the elevator
    private bool isElevatorUp = false;       // Tracks if the elevator is up or down

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the elevator.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = true;
            Debug.Log("Player entered the elevator.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = false;
            Debug.Log("Player left the elevator.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && isPlayerOnElevator)
        {
            ToggleElevator();
        }
    }

    void ToggleElevator()
    {
        if (_animator == null) return;

        if (!isElevatorUp)
        {
            Debug.Log("Setting Up trigger.");
            _animator.SetTrigger("Up"); // Goes up when down
        }
        else
        {
            Debug.Log("Setting Down trigger.");
            _animator.SetTrigger("Down"); // Goes down when up
        }

        isElevatorUp = !isElevatorUp; // Toggle state after each press
    }

}
