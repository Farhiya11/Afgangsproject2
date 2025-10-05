using UnityEngine;
using TMPro;

public class ProgressController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private GameObject starObject;
    private ProgressBar progressbar;

    void Start()
    {   
        progressbar = ProgressBar.Instance;
        UpdateLevelText();
        ShowStars();
    }

    private void OnEnable()
    {
        ProgressBar.OnProgress += UpdateLevelText;
        ProgressBar.OnProgress += UpdatePointsText;
        ProgressBar.OnProgress += ShowStars;
    }

    private void OnDisable()
    {
        ProgressBar.OnProgress -= UpdateLevelText;
        ProgressBar.OnProgress -= UpdatePointsText;
        ProgressBar.OnProgress -= ShowStars;
    }

    void UpdateLevelText()
    {
        levelText.text = ProgressBar.level.ToString();
    }

      void UpdatePointsText()
    {
        pointsText.text = ProgressBar.points.ToString();
    }

    void ShowStars()
    {
        int starCount = ProgressBar.stars; 
        int currentChildren = starObject.transform.childCount;
        for (int i = 0; i < currentChildren; i++)
        {
            GameObject star = starObject.transform.GetChild(i).gameObject;
            if (i < starCount)
            {
                star.SetActive(true);
            }
            else
            {
                star.SetActive(false);
            }
        }
    }
}
