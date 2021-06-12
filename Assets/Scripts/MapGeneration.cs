using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private float placeChance = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        //Random.seed = 38;
        //generate logic map
        int mapY = Random.Range(5, 16);
        int mapX = Random.Range(5, 16);
        Map map = new Map(mapY, mapX, placeChance);
        
        Debug.Log(map.ToString());
        Debug.Log("Seed: " + Random.seed);

        //choose coord for start and end rooms.
    }

    // Update is called once per frame
    

    
}

class Map
{
    Room[,] map;

    public Map(int y, int x, float roomPlaceChance)
    {
        map = new Room[y, x];
        GenerateMap(roomPlaceChance);
    }

    public void GenerateMap(float roomPlaceChance)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (Random.Range(0f, 1f) < roomPlaceChance)
                {
                    map[i, j] = new Room(0, i, j);
                }
            }
        }
    }

    public override string ToString()
    {
        string str = "\n";
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i,j] != null)
                {
                    str += "1 ";
                }
                else
                {
                    str += "0 ";
                }
            }
            str += "\n";
        }
        return str;
    }
}

class Room
{
    public int numExits;
    //NOTE arrays throughout work in reverse what you're used to in an ordered pair. it's (y,x) NOT the euler (x,y). this is important if you want to write out a map to check your logic.
    public int y, x;
    public List<Room> AdjoiningRooms;
    public GameObject thisRoom;

    public Room(int Depth, int y, int x)
    {
        AdjoiningRooms = new List<Room>();
        this.y = y;
        this.x = x;
    }

    public override string ToString()
    {
        return ("I am a room with " + numExits + " adjcent rooms, and my coordinates are: " + y + ", " + x);
    }
}
