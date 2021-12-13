using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCube : MonoBehaviour
{

    Vector3 _Rot = new Vector3();
    Vector3 destRot = new Vector3();

    public float speed = 5f;

    void Start()
    {
        _Rot = transform.eulerAngles;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            StartCoroutine(RotationCube());
        }
    }
    IEnumerator RotationCube()
    {
        destRot = _Rot + new Vector3(0, 90, 0);
        float alpha = 0f;

        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(_Rot),Quaternion.Euler(destRot),alpha);//
            yield return new WaitForEndOfFrame();
        }

        transform.rotation = Quaternion.Euler(destRot);
    }
}