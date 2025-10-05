using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.Services.Core;
using System.Threading.Tasks;
using Unity.Services.Authentication;
public class ProgressBar : MonoBehaviour
{

    public static int points { get; private set; }
    public static int stars { get; private set; }
    public static int level { get; private set; }


    private ICloudSave playerProgress;

    public delegate void Progress();
    public static event Progress OnProgress;
    
    private static ProgressBar instance;
    public static ProgressBar Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ProgressBar>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(ProgressBar).Name);
                    instance = singleton.AddComponent<ProgressBar>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }


    private async void Start()
    {
        playerProgress = new CloudSaveManager();
        await LoadPlayerData();
        NotifyProgress();
    }

public async void EarnPoints()
    {
        points++;
        NotifyProgress();
        EarnStars();
        await SavePlayerData();
    }

private async void EarnStars()
    {
        if (points % 2 == 0)
        {
            stars++;
            NotifyProgress();
            await SavePlayerData();
            LevelUp();
        }
    }

    private async void LevelUp()
    {
        if (stars >= 10 && points >= 20)
        {
            level++;
            stars -= 10;
            points -= 20;
            await SavePlayerData();
        }
    }

  
 private async Task SavePlayerData()
{
    await playerProgress.SaveData(points, "Points");
    await playerProgress.SaveData(stars, "Stars");
    await playerProgress.SaveData(level, "Level");
}

public async Task LoadPlayerData()
{
    points = await playerProgress.LoadData<int>("Points");
    stars = await playerProgress.LoadData<int>("Stars");
    level = await playerProgress.LoadData<int>("Level");
}

private static void NotifyProgress()
    {
        OnProgress?.Invoke();
    }

}

