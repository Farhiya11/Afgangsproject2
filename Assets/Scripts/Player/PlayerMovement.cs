using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using UnityEngine.UI;
using Unity.Services.CloudSave;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector2(horizontalInput, verticalInput);

        transform.position += direction * speed * Time.deltaTime;
    }

}
