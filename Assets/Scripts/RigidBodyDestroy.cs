using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyDestroy : MonoBehaviour {

    private void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        Physics.IgnoreLayerCollision(9,9);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain Chunk")
        {
            Destroy(GetComponent<Rigidbody>());
        }
        else if(collision.gameObject.tag == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
