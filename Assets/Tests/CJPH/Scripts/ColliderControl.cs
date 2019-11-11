using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public GameObject colliderActive;
    public GameObject colliderDeactive;
    public Renderer render;
    public int orderInLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigenter");

            colliderActive.SetActive(true);
            colliderDeactive.SetActive(false);
            render.sortingOrder = orderInLayer;
        }
    }
}
