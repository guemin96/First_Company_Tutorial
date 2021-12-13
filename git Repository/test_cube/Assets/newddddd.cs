using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newddddd : MonoBehaviour
{
    // Start is called before the first frame update
    List<RaycastHit> hit;
    void Start()
    {
        hit = new List<RaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < 8; i++)
            {
                RaycastHit tempHit = new RaycastHit();

                Physics.Raycast(this.transform.position, this.transform.position + new Vector3(Mathf.Sin(45f * i * Mathf.Deg2Rad), 0.0f, Mathf.Cos(45f * i * Mathf.Deg2Rad)), out tempHit);

                hit.Add(tempHit);
                               
            }
            foreach(RaycastHit tempHit in hit)
            {
                tempHit.collider.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                tempHit.collider.gameObject.transform.parent = this.transform;
            }
            
        }
    }
}
