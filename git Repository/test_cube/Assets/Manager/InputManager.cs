using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Cube
{
    U, D, F, B, R, L
}
public class InputManager : MonoBehaviour
{
    public List<RotationCube> rotationCubes;
    public RotationCube[] rotationCubes_ary;
    string str = string.Empty;
    int random;
    public bool isRotate =true;
    
    Dictionary<E_Cube, RotationCube> dic = new Dictionary<E_Cube, RotationCube>();

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rotationCubes_ary = GetComponentsInChildren<RotationCube>();
        InitDic();


    }
    void Update()
    {
        //InputButton(); // 첫번째 방법
        InputEnum(); // 두번째 방법
    }
    void InitDic()
    {

        dic.Add(E_Cube.U, rotationCubes_ary[0]);
        dic.Add(E_Cube.D, rotationCubes_ary[1]);
        dic.Add(E_Cube.F, rotationCubes_ary[2]);
        dic.Add(E_Cube.B, rotationCubes_ary[3]);
        dic.Add(E_Cube.R, rotationCubes_ary[4]);
        dic.Add(E_Cube.L, rotationCubes_ary[5]);
    }
    E_Cube _ecube = E_Cube.U;
    void InputEnum()
    {
        if (Input.GetKey(KeyCode.U))
        {
            var v = dic[E_Cube.U];// key값을 넣어주면 v에 value 값을 반환해준다.
            v.CubeRotation("U");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            var v = dic[E_Cube.D];//
            v.CubeRotation("D");
        }
        else if (Input.GetKey(KeyCode.F))
        {
            var v = dic[E_Cube.F];//
            v.CubeRotation("F");
        }
        else if (Input.GetKey(KeyCode.B))
        {
            var v = dic[E_Cube.B];//
            v.CubeRotation("B");
        }
        else if (Input.GetKey(KeyCode.R))
        {
            var v = dic[E_Cube.R];//
            v.CubeRotation("R");
        }
        else if (Input.GetKey(KeyCode.L))
        {
            var v = dic[E_Cube.L];//
            v.CubeRotation("L");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isRotate)
            {
                random = Random.Range(0, rotationCubes_ary.Length);
                isRotate = false;
            }
            switch (random)
            {
                
                case 0: 
                    var v = dic[E_Cube.U];
                    v.CubeRotation("U");
                    break;
                case 1:
                    v = dic[E_Cube.D];
                    v.CubeRotation("D");
                    break;
                case 2:
                    v = dic[E_Cube.F];
                    v.CubeRotation("F");
                    break;
                case 3:
                    v = dic[E_Cube.B];
                    v.CubeRotation("B");
                    break;
                case 4:
                    v = dic[E_Cube.R];
                    v.CubeRotation("R");
                    break;
                case 5:
                    v = dic[E_Cube.L];
                    v.CubeRotation("L");
                    break;
            }
        }

    }

    // Update is called once per frame
    void InputButton()
    {
        if (Input.GetKey(KeyCode.U))
        {
            rotationCubes[0].CubeRotation("U");
            //if (dic.ContainsKey(E_Cube.U))
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationCubes[1].CubeRotation("D");
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rotationCubes[2].CubeRotation("F");
        }
        else if (Input.GetKey(KeyCode.B))
        {
            rotationCubes[3].CubeRotation("B");
        }
        else if (Input.GetKey(KeyCode.R))
        {
            rotationCubes[4].CubeRotation("R");
        }
        else if (Input.GetKey(KeyCode.L))
        {
            rotationCubes[5].CubeRotation("L");
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (isRotate)
            {
                random = Random.Range(0, rotationCubes.Count);
                isRotate = false;
            }

            switch (random)
            {
                case 0:
                    str = "U";
                    break;
                case 1:
                    str = "D";
                    break;
                case 2:
                    str = "F";
                    break;
                case 3:
                    str = "B";
                    break;
                case 4:
                    str = "R";
                    break;
                case 5:
                    str = "L";
                    break;
            }
            rotationCubes[random].CubeRotation(str);
        }
    }
}
