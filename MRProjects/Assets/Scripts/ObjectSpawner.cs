//John Bowditch 2025.02.13
//Trigger Spawn
//Have this controlled by a button input

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; //XR input handling
using UnityEngine.InputSystem.XR; //Specifically Meta Quest Controller layout

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectPrefab; //The spawning object
    public Transform spawnPoint; //Where the object spawns
    public XRNode controllerNode = XRNode.RightHand; // Using right controller
    public float spawnCooldown = 1.0f; //Time between spawns

    private bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && IsAButtonPressed())
        {
            StartCoroutine(SpawnObjectWithCooldown());
        }
    }

    bool IsAButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        bool buttonPressed = false;

        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPressed) && buttonPressed)
        {
            return true;
        }

        return false;
    }

    IEnumerator SpawnObjectWithCooldown()
    {
        canSpawn = false; //prevent immediate respawning
        SpawnObject();
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true; //Allows to spawn again
    }

    void SpawnObject()
    {
        if (objectPrefab != null && spawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        else
        {
            Debug.Log("Either assign a GameObject or spawnPoint in Inspector");
        }
    }
}
