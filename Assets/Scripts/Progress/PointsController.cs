using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;



public class PointsController : MonoBehaviour
{
    private ProgressBar progressInstance;

    private void Start()
    {
        progressInstance = ProgressBar.Instance;
    }

    public void getPoints()
    {
        progressInstance.EarnPoints();
    }
}


