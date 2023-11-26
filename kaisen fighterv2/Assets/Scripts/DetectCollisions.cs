using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject has a tag "NPC"
        if (other.CompareTag("npc"))
        {
            // Destroy only NPCs
            Destroy(other.gameObject);
        }
    }
}
