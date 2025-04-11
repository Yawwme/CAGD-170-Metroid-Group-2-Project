using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public int buildIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
