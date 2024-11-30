using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapUpdater : MonoBehaviour
{
    [SerializeField] private Tilemap[] tilemaps;

    private void Awake()
    {
        tilemaps = GetComponentsInChildren<Tilemap>();

        if (tilemaps.Length == 0)
        {
            Debug.LogError("No tilemaps found in the children of this GameObject!");
        }
    }
    
    private void Start()
    {
        RefreshAllTilemaps();
        
    }

    public void RefreshAllTilemaps()
    {
        if (tilemaps == null || tilemaps.Length == 0)
        {
            Debug.LogError("No tilemaps assigned!");
            return;
        }

        foreach (var tilemap in tilemaps)
        {
            if (tilemap != null)
            {
                tilemap.RefreshAllTiles();
                Debug.Log($"Tilemap '{tilemap.name}' refreshed.");
            }
            else
            {
                Debug.LogWarning("One of the tilemaps is null.");
            }
        }
    }
}
