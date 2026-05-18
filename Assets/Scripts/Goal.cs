using System;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GlobalVariable.TagName tagName;

    [SerializeField] private bool isGoalIn = false;
    
    public bool IsGoalIn => isGoalIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            isGoalIn = ball.TagName == tagName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.TagName == tagName)
            {
                isGoalIn = false;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent<Ball>(out Ball ball)) 
            return;
        
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();
            
        //
        if (ball.TagName == tagName)
        {
            rb.linearVelocity *= 0.9f;
                
            rb.AddForce(direction * rb.mass * 20f);
                
        }
        else
        {
            rb.AddForce(-direction * rb.mass * 80f);
        }

    }
}
