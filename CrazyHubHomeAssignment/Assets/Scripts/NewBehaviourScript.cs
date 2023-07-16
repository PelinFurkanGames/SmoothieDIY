using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Vector3 initialposition;
    private void Start()
    {
        initialposition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blender"))
        {
            //Destroy(gameObject);
            Debug.Log("aa");
        }
        else
        {
            transform.position = initialposition;
        }
    }
}
