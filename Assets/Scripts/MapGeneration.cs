using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Room Rooms = new Room(0);
        Rooms.generateRooms(0, 2, 4);

        Debug.Log(Rooms.ToString());
        Rooms.debugRooms();
    }

    // Update is called once per frame
    

    
}

class Room
{
    public int numExits;
    int depth = 0;
    public List<Room> exitRooms;

    public Room(int Depth)
    {
        exitRooms = new List<Room>();
        depth = Depth;
    }

    
    public void generateRooms(int depth, int lowRange, int highRange)
    {
        lowRange = (lowRange < 0) ? 0 : lowRange;
        
        numExits = Random.Range(lowRange, highRange);
        depth++;
        for (int i = 0; i < numExits; i++)
        {
            Room attachedRoom = new Room(depth);
            exitRooms.Add(attachedRoom);
            attachedRoom.generateRooms(depth, --lowRange, --highRange);
        }
    }

    public void debugRooms()
    {
        foreach (Room r in exitRooms)
        {
            Debug.Log(r.ToString());
            r.debugRooms();
        }
    }

    public override string ToString()
    {
        return ("I am a room at depth: " + depth + ", with " + numExits + " adjcent rooms.");
    }
}
