using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalInChecker : MonoBehaviour
{
    [SerializeField] private List<Ball> ballList;

    
    private void Start()
    {
        ballList = FindObjectsByType<Ball>().ToList();
        
    }
    
    
}
