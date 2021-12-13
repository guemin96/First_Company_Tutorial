using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotationCube : MonoBehaviour
{
    Vector3 _Rot = new Vector3();
    Vector3 destRot = new Vector3();

    //레이저로 묶어주는 역할
    List<Transform> m_listHitTm = new List<Transform>();
    //텍스트
    [SerializeField] Text txt;

    //원래 부모(Center)
    //[SerializeField] GameObject CenterCube= new GameObject(); => 안되는 이유.. 생성자를 호출하면 안되고 변수만 설정해준다.
    // 생성자(또는 인스턴스 필드 이니셜라이저)에서 호출할 수 없으므로 대신 Wake 또는 Start에서 호출한다. 게임 개체 'DCube'의 MonoBehaviour 'RotationCube'에서 호출됩니다.

    [SerializeField] GameObject CenterCube;

    //
    InputManager theinputManager;

    Coroutine coroutine = null;

    void Start()
    {
        _Rot = transform.eulerAngles;
        theinputManager = GetComponentInParent<InputManager>();// 해당 스크립트를 가져오기 위해서는 start부문에서 따로 설정해줘야한다
        //현재 inputmanager 스크립트는 Center라는 객체 안에 있기 때문에 GetComponentInParent라는 함수를 통해 스크립트를 가져온다.

        //텍스트 부분 시작
        //theUIManager = GetComponent<UIManager>();

        //txts = theUIManager.txt;// 오류 나는 지점
        //for (int i = 0; i < 6; i++)
        //{
        //    Debug.Log(txts[i].text);
        //}
        //텍스트 부분 끝
        //ray 생성
        //hits = new List<RaycastHit> ();

    }
    public void CubeRotation(string _cubeType )
    {
        switch (_cubeType)
        {
            case "U":
                m_listHitTm = UDRaycube();
                if (txt.name == "Up")
                {
                    txt.text = "<color=green>U : Rotate upside clockwise</color>";
                }
                destRot = _Rot + new Vector3(0, 90, 0);
                break;

            case "D":
                m_listHitTm = UDRaycube();
                if (txt.name == "Down")
                {
                    txt.text = "<color=green>D : Rotate downside clockwise</color>";
                }
                destRot = _Rot + new Vector3(0, -90, 0);
                break;
            case "R":
                m_listHitTm = RLRaycube();

                if (txt.name == "Right")
                {
                    txt.text = "<color=green>R : Rotate rightside clockwise</color>";
                }
                destRot = _Rot + new Vector3(0, 0, 90);
                break;
            case "L":
                m_listHitTm = RLRaycube();
                if (txt.name == "Left")
                {
                    txt.text = "<color=green>L : Rotate leftside clockwise</color>";
                }
                destRot = _Rot + new Vector3(0, 0, -90);
                break;
            case "F":
                m_listHitTm = FBRaycube();
                // x축으로 -180도 회전을 했을때 180,0,0을 가져오는게 아니라 0,180,180의 회전축을 컴퓨터상에서 가져오기 때문에
                // 그 부분을 방지해주는 코드
                if (_Rot.y > 0)
                {
                    destRot = _Rot + new Vector3(90f, 0, 0);
                }
                else if (_Rot.y <= 0f)
                {
                    destRot = _Rot + new Vector3(-90f, 0, 0);
                }

                if (txt.name == "Front")
                {
                    txt.text = "<color=green>F : Rotate Frontside clockwise</color>";
                }
                break;
            case "B":
                m_listHitTm = FBRaycube();

                if (txt.name == "Back")
                {
                    txt.text = "<color=green>B : Rotate Backside clockwise</color>";
                }
                destRot = _Rot + new Vector3(90, 0, 0);
                break;
        }
        
        ParentCode();
        CoroutineCode();
    }
    //코루틴 실행 및 중복실행방지 코드
    void CoroutineCode()
    {
        if (coroutine == null) // 코루틴을 변수에 담아서 현재 코루틴이 실행되고 있을때는 실행하지 못하도록 설정해준다.
        {
            coroutine = StartCoroutine(Co_RotationCube());
            //큐브조각들을 다시 원래 부모밑으로 넣어주는 역할
        }
    }
    //대각선에 있는 큐브들을 각 면의 중심에 자식으로 넣어주는 코드
    void ParentCode()
    {
        if (m_listHitTm.Count > 0)
        {
            foreach (Transform hitTm in m_listHitTm)
            {
                hitTm.SetParent(this.transform);
                //hit.collider.gameObject.transform.parent = this.transform;
            }
        }
    }
    // raycast에서 두번째 매개변수인 방향을 설정할때 8방향으로 쏴줘야하는데 각각의 중심 큐브에 따라 다 방향이 다르기 때문에 
    // 총 3개의 함수를 만들어준다.
    List<Transform> UDRaycube()
    {
        RaycastHit Hit;
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(1.1f, 0f, 1.1f), out Hit, 100f);// rayCast함수(현재위치, 나아가는 방향, 맞춘 객체, 레이저의 길이)
        if (isHit)
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(1, 0, 0), out Hit, 100f))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(1, 0, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, 0, 1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, 0, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, 0, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }

        return m_listHitTm;
    }
    List<Transform> RLRaycube()
    {
        RaycastHit Hit;
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(1f, 1f, 0f), out Hit, 100f);// rayCast함수(현재위치, 나아가는 방향, 맞춘 객체, 레이저의 길이)
        if (isHit)
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out Hit, 100f))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, 1, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, 0, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(1, 0, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(1, -1, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(-1, -1, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }

        return m_listHitTm;
    }
    List<Transform> FBRaycube()
    {
        RaycastHit Hit;
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(0, 1f, 1f), out Hit, 100f);// rayCast함수(현재위치, 나아가는 방향, 맞춘 객체, 레이저의 길이)
        if (isHit)
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out Hit, 100f))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 1, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, 0, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }
        if (Physics.Raycast(transform.position, new Vector3(0, -1, -1), out Hit))
        {
            m_listHitTm.Add(Hit.transform);
        }

        return m_listHitTm;
    }
    //색깔을 원래대로 돌려주는 코드
    void OriColorTxt()
    {
        switch (txt.name)
        {
            case "Up":
                txt.text = "<color=white>U : Rotate upside clockwise</color>";
                break;
            case "Down":
                txt.text = "<color=white>D : Rotate downside clockwise</color>";
                break;
            case "Right":
                txt.text = "<color=white>R : Rotate rightside clockwise</color>";
                break;
            case "Left":
                txt.text = "<color=white>L : Rotate leftside clockwise</color>";
                break;
            case "Front":
                txt.text = "<color=white>F : Rotate Frontside clockwise</color>";
                break;
            case "Back":
                txt.text = "<color=white>B : Rotate Backside clockwise</color>";
                break;
        }
    }
    IEnumerator Co_RotationCube()
    {
        float alpha = 0f;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            
            transform.localRotation = Quaternion.Lerp(Quaternion.Euler(_Rot), Quaternion.Euler(destRot), alpha);//
            
            //transform.eulerAngles = Vector3.Lerp(_Rot, destRot, alpha);

            //Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.);

            yield return new WaitForEndOfFrame();
        }

        transform.localRotation = Quaternion.Euler(destRot);//현재 회전값이 정확하게 목표회전값과 동일하게 만들어주기 위한 작업
        //_Rot = transform.localRotation.eulerAngles;
        _Rot = destRot;

        // 원래 부모로 넣어주기
        if (m_listHitTm.Count > 0)
        {
            foreach (Transform hitTm2 in m_listHitTm)
            {
                hitTm2.SetParent(CenterCube.transform);
            }
        }
        //코루틴안에서 회전이 다 끝나게 되면 텍스트 색상 다시 바꿔줌
        OriColorTxt();
        
        //input.getkey 함수로 인해 random값을 계속해서 가져오기 때문에 bool값을 통해 회전이 끝나기 전까지는 false로 만들어줘서
        //random값을 받아오지 못하게 만든다.
        theinputManager.isRotate = true;
        
        // 코루틴안에서 회전이 다 끝나게 되면 null값으로 만들어줘야한다. 
        m_listHitTm.Clear();


        coroutine = null;
        yield break;
    }
}
