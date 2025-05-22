using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTrackedSpawner : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject cubePrefab;

    private Dictionary<string, GameObject> spawnedPrefabs = new();

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SpawnOrUpdate(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            SpawnOrUpdate(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out var prefab))
            {
                Destroy(prefab);
                spawnedPrefabs.Remove(trackedImage.referenceImage.name);
            }
        }
    }

    void SpawnOrUpdate(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;

        cubePrefab.transform.rotation = trackedImage.transform.rotation * Quaternion.Euler(90f, 0f, 0f);

        if (!spawnedPrefabs.TryGetValue(name, out var prefab))
        {
            prefab = Instantiate(cubePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
            spawnedPrefabs[name] = prefab;
        }
        else
        {
            prefab.transform.position = trackedImage.transform.position;
            prefab.transform.rotation = trackedImage.transform.rotation;
        }

        prefab.SetActive(trackedImage.trackingState == TrackingState.Tracking);
    }
}

