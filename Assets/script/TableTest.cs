using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TableRow
{
    public string column1;
    public int column2;
    public float column3;

    
}

[CreateAssetMenu(fileName = "TableTest", menuName = "Scriptable Objects/TableTest")]
public class TableTest : ScriptableObject
{
    [SerializeField]
    private List<TableRow> rows = new List<TableRow>();

    public List<TableRow> Rows => rows;
}
