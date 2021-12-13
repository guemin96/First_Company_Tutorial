using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCube : MonoBehaviour
{
    Vector3 _Rot = new Vector3();
    Vector3 destRot = new Vector3();
    void Start()
    {
        _Rot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            StartCoroutine(RotationCube());
        }
    }
    IEnumerator RotationCube()
    {
        destRot = _Rot + new Vector3(0, 0, 90);
        float alpha = 0f;

        while (alpha<1)
        {
            alpha += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(_Rot), Quaternion.Euler(destRot), alpha);
            yield return new WaitForEndOfFrame();
        }
        transform.rotation = Quaternion.Euler(destRot);
    }
}
