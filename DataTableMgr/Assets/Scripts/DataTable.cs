using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataTable : MonoBehaviour
{
    public enum Ids
    {
        None = -1,
        String,
        Clip
    }

    protected Ids tableId = Ids.None;

    public DataTable(DataTable.Ids id) { tableId = id; }
    private DataTable(DataTable other) { } // ���� ������ ����
    public abstract bool Load();
    public abstract void Release();
}
