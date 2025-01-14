using UnityEngine;

public class CallbackAndLambda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PerformCalculation(10,20,(res, res2) =>
        {
            return 0.0f;
        });
    }

    void PerformCalculation(int a, int b, System.Func<int,int,float> callback)
    {
        int result = a + b;

        float c = callback?.Invoke(7,8) ?? 0f; // �Ű� ������ �Ѿ�� �ݹ��Լ��� ȣ���� �� �ִ�.
        /*float c;

        if (callback != null)
        {
            c = callback.Invoke(7, 8);
        }
        else
        {
            c = 0f;
        }*/
    }

    /*float OnPlayCallback(int res, int res2)
    {
        Debug.Log("OnPlayCallback ȣ��");
        return 0.5f;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
