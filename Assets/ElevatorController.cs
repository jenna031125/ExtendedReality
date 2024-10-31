using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator _animator;
    private bool isPlayerOnElevator = false; 
    private bool isElevatorUp = false;       
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = false;
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
            _animator.SetTrigger("Up"); 
        }
        else
        {
            _animator.SetTrigger("Down"); 
        }

        isElevatorUp = !isElevatorUp;
    }

}
