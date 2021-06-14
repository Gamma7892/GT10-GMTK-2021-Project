using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private float placeChance = 0.6f;

    public RoomPrefab[] AllRooms;


    // Start is called before the first frame update
    void Start()
    {
        //Random.seed = -2138785206;
        //generate logic map
        int mapY = Random.Range(5, 11);
        int mapX = Random.Range(5, 11);
        Map map = new Map(mapY, mapX, placeChance);
                
        Debug.Log(map.ToString());
        Debug.Log("Seed: " + Random.seed);

        map.PlacePrefabs(AllRooms);

    }

    // Update is called once per frame
    

    
}

[System.Serializable]
public class Directions
{
    public enum RelativeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}

class Map : Directions
{
    Room[,] map;
    int lenY, lenX;
    int startY, startX, endY, endX;

    public Map(int y, int x, float roomPlaceChance)
    {
        map = new Room[y, x];
        lenY = y;
        lenX = x;
        GenerateMap(roomPlaceChance);

        (startY, startX) = (Random.Range(0, 5), Random.Range(0, 5));
        (endY, endX) = (Random.Range(5, y-2), Random.Range(5, x-2));

        ToString();

        VerifySolution();

        //set rooms at ^ coords to their special type.
        map[startY, startX].roomType = Room.RoomType.start;
        map[endY, endX].roomType = Room.RoomType.end;
        
        AssignNeighbors();
    }

    void GenerateMap(float roomPlaceChance)
    {
        for (int i = 0; i < lenY; i++)
        {
            for (int j = 0; j < lenX; j++)
            {
                if (Random.Range(0f, 1f) < roomPlaceChance)
                {
                    map[i, j] = new Room(i, j);
                }
            }
        }
        map[lenY-1, lenX-1] = null; //assigning neighbors is harder if we have to worry about the corner.
    }

    //adds rooms in an L shape from start to finish to verify at least one solution.
    void VerifySolution()
    {
        //walk down to the goal height
        for (int i = startY; i <= endY; i++)
        {
            if(map[i,startX] == null)
            {
                map[i, startX] = new Room(i, startX);
            }
        }

        // from that ^ point, walk over to the goal.
        for (int i = startX; i <= endX; i++)
        {
            if (map[endY, i] == null)
            {
                map[endY, i] = new Room(startY, i);
            }
        }
    }
    void AssignNeighbors()
    {
        for (int i = 0; i < lenY-1; ++i)
        {
            for (int j = 0; j < lenX-1; ++j)
            {
                if (map[i, j] != null)
                {
                    if (map[i + 1, j] != null)
                    {
                        map[i, j].AdjoiningRooms.Add(RelativeDirection.Down);
                        map[i + 1, j].AdjoiningRooms.Add(RelativeDirection.Up);
                    }
                    if (map[i, j + 1] != null)
                    {
                        map[i, j].AdjoiningRooms.Add(RelativeDirection.Right);
                        map[i, j + 1].AdjoiningRooms.Add(RelativeDirection.Left);
                    }
                }
            }
        }
        //handle linking rooms on the bottom row
        for (int j = 0; j < lenX-1; ++j)
        {
            if (map[lenY-1, j] != null)
            {
                if (map[lenY - 1, j + 1] != null)
                {
                    map[lenY - 1, j].AdjoiningRooms.Add(RelativeDirection.Right);
                    map[lenY - 1, j + 1].AdjoiningRooms.Add(RelativeDirection.Left);
                }
            }
        } 
    }

    public void PlacePrefabs(RoomPrefab[] AllRooms)
    {
        
        
        for(int i = 0; i < lenY; i++)
        {
            for(int j = 0; j < lenX; j++)
            {
                Room thisRoom = map[i, j];
                if (thisRoom != null)
                {
                    
                    //TODO rewrite picking and assigning room prefabs to rooms

                    // now that we know what it is, we can instantiate it.

                }
            }
        }
    }

    public override string ToString()
    {
        string str = "\n";
        for (int i = 0; i < lenY; i++)
        {
            for (int j = 0; j < lenX; j++)
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
        str += "My start location is: (" + startY + ", " + startX + "), and my end location is: (" + endY + ", " + endX + ")\n";
        return str;
    }
}

[System.Serializable]
public class RoomPrefab : Directions
{
    public RelativeDirection[] exits;
    public GameObject Prefab;
}

class Room : Directions
{
    //NOTE arrays throughout work in reverse what you're used to in an ordered pair. it's (y,x) NOT the euler (x,y). this is important if you want to write out a map to check your logic.
    public int y, x;
    public List<RelativeDirection> AdjoiningRooms;
    public GameObject thisRoom;
    public enum RoomType { start, end, normal }
    public RoomType roomType;

    public Room(int y, int x)
    {
        AdjoiningRooms = new List<RelativeDirection>();
        roomType = RoomType.normal;
        this.y = y;
        this.x = x;
    }

    public override string ToString()
    {
        return ("I am a room with " + AdjoiningRooms.Count + " adjcent rooms, and my coordinates are: " + y + ", " + x);
    }
}

