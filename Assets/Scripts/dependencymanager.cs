// // DependencyManager.cs
// using UnityEngine;

// public class dependencymanager : MonoBehaviour
// {
//     private static dependencymanager _instance;
//     public static dependencymanager Instance => _instance;

//     public ISignIn signInImplementation;

//     private void Awake()
//     {
//         if (_instance == null)
//         {
//             // If no instance exists, set this as the instance and mark it as persistent
//             _instance = this;
//             signInImplementation = new AuthManager();
//             cloudImplementation = new CloudSaveManager();
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             // If an instance already exists, destroy this GameObject
//             Destroy(gameObject);
//         }
//     }

    

// }
