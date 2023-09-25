using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System;

public class DataTableMgr : MonoBehaviour
{
    public static DataTableMgr instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = FindAnyObjectByType<DataTableMgr>();
            }
            return m_instance;
        }
    }

    private static DataTableMgr m_instance;
    private DataTableMgr(DataTable other) { } // ���� ������ ����
    // == ������ �����ε� ����

    protected Dictionary<DataTable.Ids, DataTable> tables;

    public DataTable Get (DataTable.Ids id)
    {
        if(!tables.TryGetValue(id, out var value))
        {
            return null;
        }
        return value;
    }

    public void LoadAll()
    {
        // ���̺� �߰��� �ڵ�
        //tables.Add(new Dictionary< DataTable.Ids.String, new StringTable() >);

        foreach(var pair in tables)
        {
            if (!pair.Value.Load())
            {
                Console.WriteLine("ERR: DATA TABLE LOAD FAIL");
                Environment.Exit(-1); // ��������?
            }
        }
    }
}