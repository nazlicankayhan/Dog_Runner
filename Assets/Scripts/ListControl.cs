using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListControl : MonoBehaviour
{


    public int a;
    public int b;
    public static ListControl instance;
    public List<GameObject> dogs = new List<GameObject>();
    private void Start()
    {
        instance = this;
    }
   
    
   
}
