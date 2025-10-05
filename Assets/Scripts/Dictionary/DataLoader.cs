using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using System.Threading.Tasks;
using TMPro;


public class DataLoader
{
    private string filePath = "Assets/TextMesh Pro/Resources/en-ko_communication.csv";

    public Dictionary<string, string> LoadData()
    {
        var dictionary = new Dictionary<string, string>();
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine())!= null)
                {
                    string[] values = line.Split(';');
                    if (values.Length >= 2)
                    {
                        string[] sentences = new string[2];
                        for (int i = 0; i < 2; i++)
                        {
                            sentences[i] = values[i].Trim();
                        }
                        string korSent = sentences[0];
                        string engSent = sentences[1];
                        dictionary[engSent] = korSent;
                    }
                }
            }
        }
        catch (IOException e)
        {
            Debug.Log("Error");

        }
        return dictionary;
    }
}
