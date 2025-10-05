using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using System.Threading.Tasks;
using UnityEngine.UI;
using Unity.Services.CloudSave;
using UnityEngine.SceneManagement;
using System;
using System.Net.Http;

public class CloudSaveManager : ICloudSave
{

public async Task SaveData<T>(T inData, string key)
{
    try
    {
        var data = new Dictionary<string, object> { { key, inData } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        // return inData; // Assuming you want to return the input data upon successful save
    }
    catch (HttpRequestException httpEx)
    {
        // Handle HTTP-specific exceptions
        Debug.LogError($"HTTP error occurred: {httpEx.Message}");
        throw; // Consider whether to rethrow based on your application's error handling policy
    }
    catch (Exception ex)
    {
        // Handle non-HTTP exceptions
        Debug.LogError($"An error occurred while saving data: {ex}");
        throw; // Rethrowing the exception
    }
}


// public async Task<T> SaveData<T>(T Indata, string key) 
// {
//     var data = new Dictionary<string, object>{{key, Indata}};
//     await CloudSaveService.Instance.Data.Player.SaveAsync(data);
// }

//use task instead of void when returning something to avoid issues
public async Task<T> LoadData<T>(string key)
{
    var playerData = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { key });
    if (playerData.TryGetValue(key, out var keyValue))
    {
        Debug.Log($"Loaded data for key {key}: {keyValue.Value.GetAs<T>()}");
        return keyValue.Value.GetAs<T>(); // Return the loaded data
    }
    else
    {
        Debug.LogWarning($"Key '{key}' not found in cloud save data.");
        return default; // Return default value if key is not found
    }
}

}
