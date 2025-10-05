using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DictionaryController : MonoBehaviour
{
    public TextMeshProUGUI koreanTextParent;
    public TextMeshProUGUI englishTextParent;
    public Transform contentPanelEng;
    public Transform contentPanelKor;
    public TMP_InputField EnglishInputField;

    private Dictionary<string, string> _dictionary;

    private void Start()
    {
        DataLoader dataLoader = new DataLoader();
        _dictionary = dataLoader.LoadData();
        
        foreach (var entry in _dictionary)
        {
            string koreanTranslation = entry.Value.ToLower();
            string englishWord = entry.Key.ToLower();
            CreateUIElement(koreanTranslation, englishWord);
        }
        
    }

    void CreateUIElement(string korean, string english)
    {
        TextMeshProUGUI koreanText = Instantiate(koreanTextParent, contentPanelKor);
        TextMeshProUGUI englishText = Instantiate(englishTextParent, contentPanelEng);

        koreanText.text = korean;
        englishText.text = english;
    }

    void OnSearchInputEng(string searchText)
    {
        searchText = searchText.ToLower(); 
        SearchDictionary(searchText);
    }

    void SearchDictionary(string searchText)
    {
        foreach (var entry in _dictionary)
        {
            string englishWord = entry.Key.ToLower();
            string koreanTranslation = entry.Value.ToLower();

            bool isMatch = englishWord.Contains(searchText) || koreanTranslation.Contains(searchText);

            UpdateUIForMatch(englishWord, koreanTranslation, isMatch);
        }
    }

    void UpdateUIForMatch(string englishWord, string koreanTranslation, bool isMatch)
    {
        UpdateUIForWord(contentPanelEng, englishWord, isMatch);

        UpdateUIForWord(contentPanelKor, koreanTranslation, isMatch);
    }

    void UpdateUIForWord(Transform panel, string word, bool isMatch)
    {
        foreach (Transform child in panel)
        {
            TextMeshProUGUI text = child.GetComponent<TextMeshProUGUI>();
            if (text != null && text.text.ToLower() == word)
            {
                child.gameObject.SetActive(isMatch);
                break;
            }
        }
    }
}
