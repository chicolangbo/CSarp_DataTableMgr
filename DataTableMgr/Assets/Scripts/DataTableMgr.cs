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
    private DataTableMgr(DataTable other) { } // 복사 생성자 막음
    // == 연산자 오버로딩 삭제

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
        // 테이블 추가시 코드
        //tables.Add(new Dictionary< DataTable.Ids.String, new StringTable() >);

        foreach(var pair in tables)
        {
            if (!pair.Value.Load())
            {
                Console.WriteLine("ERR: DATA TABLE LOAD FAIL");
                Environment.Exit(-1); // 강제종료?
            }
        }
    }
}