using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class csvLoading : MonoBehaviour
{
    private List<List<string>> csvData = new List<List<string>>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("Example");
        if(csvFile != null)
        {
            Debug.Log("������ �����մϴ�.");
            // '\n' --> �ٹٲ�
            string[] rows = csvFile.text.Split('\n');

            foreach( string row in rows)
            {
                string[] fields = row.Split(',');
                List<string> rowData = new List<string>(fields);
                csvData.Add(rowData);
            }

            int row_num = 0;
            foreach(List<string> row in csvData)
            {
                Debug.Log("[" + (row_num + 1) + "]��");
                int field_num = 0;
                foreach(string field in row)
                {
                    switch(field_num)
                    {
                        case 0: Debug.Log("1�� " + int.Parse(field)); break;
                        case 1: Debug.Log("2�� " + int.Parse(field)); break;
                        case 2: Debug.Log("3�� " + float.Parse(field)); break;
                        case 3: Debug.Log("4�� " + float.Parse(field)); break;
                    }
                    field_num++;
                }
                row_num++;
            }
        }
        else
        {
            Debug.Log("������ �������� �ʽ��ϴ�.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
