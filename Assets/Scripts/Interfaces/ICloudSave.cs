using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface ICloudSave
{
    Task<T> LoadData<T>(string key);
    Task SaveData<T>(T Indata, string key); 
}
