using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class NewTestScript
{

    private GameObject gameObject;
    private Button signInButton;
    private SignInController signInController;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject("TestObject");
        signInButton = gameObject.AddComponent<Button>();
        signInController = gameObject.AddComponent<SignInController>();
        signInButton.onClick.AddListener(signInController.Signin);
    }

    [UnityTest]
    public IEnumerator SignInButtonTriggersSignInMethod()
    {
        signInButton.onClick.Invoke();
        yield return null;
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}

