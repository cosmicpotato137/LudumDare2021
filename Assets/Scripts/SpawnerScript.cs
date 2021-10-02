using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnerScript : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject hazard;

    void Start()
    {
        spawnHazard(tilemap);
    }

    public void spawnHazard(Tilemap tilemap){
        for(int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++){
            for(int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++){
                Vector3Int localPlace = new Vector3Int(x, y, (int)tilemap.transform.position.y);
                Vector3 place = tilemap.CellToWorld(localPlace);
                place = new Vector3(place.x + 0.5f, place.y + 0.5f, place.z);
                if(tilemap.HasTile(localPlace)){
                    var placed = Instantiate(hazard, place, transform.rotation);
                    //Debug.Log("placing");
                }
            }
        }
    }
}
