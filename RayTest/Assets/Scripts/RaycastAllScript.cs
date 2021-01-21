using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAllScript : MonoBehaviour
{
    RaycastHit[] hits;
    float MaxDistance = 25f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);

            hits = Physics.RaycastAll(transform.position, transform.forward, MaxDistance);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                MeshRenderer ChangeColor = hit.transform.GetComponent<MeshRenderer>();

                if (ChangeColor)
                {
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
        }
    }
}
