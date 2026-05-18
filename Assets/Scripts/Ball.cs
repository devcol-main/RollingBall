using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    [SerializeField] private GlobalVariable.TagName tagName;
    
    // get
    public GlobalVariable.TagName TagName => tagName;   
    
    
}
