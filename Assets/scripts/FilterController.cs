using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterController : MonoBehaviour
{
    public GameObject filterpanel;
    // Start is called before the first frame update
    void Start()
    {
        filterpanel.SetActive(false);
    }
    public void showFilter(){
        filterpanel.SetActive(true);
    }

  
}
