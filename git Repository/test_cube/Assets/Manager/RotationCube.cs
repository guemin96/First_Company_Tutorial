using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotationCube : MonoBehaviour
{
    Vector3 _Rot = new Vector3();
    Vector3 destRot = new Vector3();

    //�������� �����ִ� ����
    List<Transform> m_listHitTm = new List<Transform>();
    //�ؽ�Ʈ
    [SerializeField] Text txt;

    //���� �θ�(Center)
    //[SerializeField] GameObject CenterCube= new GameObject(); => �ȵǴ� ����.. �����ڸ� ȣ���ϸ� �ȵǰ� ������ �������ش�.
    // ������(�Ǵ� �ν��Ͻ� �ʵ� �̴ϼȶ�����)���� ȣ���� �� �����Ƿ� ��� Wake �Ǵ� Start���� ȣ���Ѵ�. ���� ��ü 'DCube'�� MonoBehaviour 'RotationCube'���� ȣ��˴ϴ�.

    [SerializeField] GameObject CenterCube;

    //
    InputManager theinputManager;

    Coroutine coroutine = null;

    void Start()
    {
        _Rot = transform.eulerAngles;
        theinputManager = GetComponentInParent<InputManager>();// �ش� ��ũ��Ʈ�� �������� ���ؼ��� start�ι����� ���� ����������Ѵ�
        //���� inputmanager ��ũ��Ʈ�� Center��� ��ü �ȿ� �ֱ� ������ GetComponentInParent��� �Լ��� ���� ��ũ��Ʈ�� �����´�.

        //�ؽ�Ʈ �κ� ����
        //theUIManager = GetComponent<UIManager>();

        //txts = theUIManager.txt;// ���� ���� ����
        //for (int i = 0; i < 6; i++)
        //{
        //    Debug.Log(txts[i].text);
        //}
        //�ؽ�Ʈ �κ� ��
        //ray ����
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
                // x������ -180�� ȸ���� ������ 180,0,0�� �������°� �ƴ϶� 0,180,180�� ȸ������ ��ǻ�ͻ󿡼� �������� ������
                // �� �κ��� �������ִ� �ڵ�
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
    //�ڷ�ƾ ���� �� �ߺ�������� �ڵ�
    void CoroutineCode()
    {
        if (coroutine == null) // �ڷ�ƾ�� ������ ��Ƽ� ���� �ڷ�ƾ�� ����ǰ� �������� �������� ���ϵ��� �������ش�.
        {
            coroutine = StartCoroutine(Co_RotationCube());
            //ť���������� �ٽ� ���� �θ������ �־��ִ� ����
        }
    }
    //�밢���� �ִ� ť����� �� ���� �߽ɿ� �ڽ����� �־��ִ� �ڵ�
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
    // raycast���� �ι�° �Ű������� ������ �����Ҷ� 8�������� ������ϴµ� ������ �߽� ť�꿡 ���� �� ������ �ٸ��� ������ 
    // �� 3���� �Լ��� ������ش�.
    List<Transform> UDRaycube()
    {
        RaycastHit Hit;
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(1.1f, 0f, 1.1f), out Hit, 100f);// rayCast�Լ�(������ġ, ���ư��� ����, ���� ��ü, �������� ����)
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
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(1f, 1f, 0f), out Hit, 100f);// rayCast�Լ�(������ġ, ���ư��� ����, ���� ��ü, �������� ����)
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
        
        bool isHit = Physics.Raycast(transform.position, new Vector3(0, 1f, 1f), out Hit, 100f);// rayCast�Լ�(������ġ, ���ư��� ����, ���� ��ü, �������� ����)
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
    //������ ������� �����ִ� �ڵ�
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

        transform.localRotation = Quaternion.Euler(destRot);//���� ȸ������ ��Ȯ�ϰ� ��ǥȸ������ �����ϰ� ������ֱ� ���� �۾�
        //_Rot = transform.localRotation.eulerAngles;
        _Rot = destRot;

        // ���� �θ�� �־��ֱ�
        if (m_listHitTm.Count > 0)
        {
            foreach (Transform hitTm2 in m_listHitTm)
            {
                hitTm2.SetParent(CenterCube.transform);
            }
        }
        //�ڷ�ƾ�ȿ��� ȸ���� �� ������ �Ǹ� �ؽ�Ʈ ���� �ٽ� �ٲ���
        OriColorTxt();
        
        //input.getkey �Լ��� ���� random���� ����ؼ� �������� ������ bool���� ���� ȸ���� ������ �������� false�� ������༭
        //random���� �޾ƿ��� ���ϰ� �����.
        theinputManager.isRotate = true;
        
        // �ڷ�ƾ�ȿ��� ȸ���� �� ������ �Ǹ� null������ ���������Ѵ�. 
        m_listHitTm.Clear();


        coroutine = null;
        yield break;
    }
}
