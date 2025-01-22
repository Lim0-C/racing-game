using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum GasLocation
{
    Left,
    Center,
    Right
}
public class TileManager : MonoBehaviour
{
    private Tile[] tiles;
    private Player player;
    private float speed;
    private GasLocation gaslocation;
    void Start()
    {
        tiles = GameObject.Find("TileMap").GetComponentsInChildren<Tile>();
        player = GameObject.Find("Player").GetComponent<Player>();
        speed = player.moveSpeed;
    }

    
    void Update()
    {
        foreach (var tile in tiles)
        {
            if (tile.transform.position.z < -20f)
            {
                tile.transform.position = new Vector3(0,0,60);
                RandomSpawnGas(tile);
            }
            tile.transform.position -= Vector3.forward * speed * Time.deltaTime;
        }
    }

    private void RandomSpawnGas(Tile tile)
    {
        int rd = Random.Range(0, 3);
        int rd2 = Random.Range(0, 2);
        if (rd2 == 0)
        {
            gaslocation = (GasLocation)rd;
            GameObject gas;
            switch (gaslocation)
            {
                case GasLocation.Left:
                    gas = (GameObject)Instantiate(Resources.Load("Prefabs/Gas"),
                        tile.transform.position + new Vector3(-3.5f, 1.5f, 0),
                        Quaternion.identity);
                    gas.transform.SetParent(tile.transform);
                    break;
                case GasLocation.Center:
                    gas =  (GameObject)Instantiate(Resources.Load("Prefabs/Gas"),
                        tile.transform.position + new Vector3(0, 1.5f, 0),
                        Quaternion.identity);
                    gas.transform.SetParent(tile.transform);
                    break;
                case GasLocation.Right:
                    gas =  (GameObject)Instantiate(Resources.Load("Prefabs/Gas"),
                        tile.transform.position + new Vector3(3.5f, 1.5f, 0),
                        Quaternion.identity);
                    gas.transform.SetParent(tile.transform);
                    break;
            }
        }
    }
}
