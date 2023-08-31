using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathMarker
{
    public MapLocation location;
    public float G;  // Number of nodes from start
    public float H;  // Pythagorean distance to destination
    public float F;  // G + H
    public GameObject marker;
    public PathMarker parent;

    public PathMarker(MapLocation l, float g, float h, float f, GameObject marker, PathMarker p)
    {
        location = l;
        G = g;
        H = h;
        F = f;
        this.marker = marker;
        parent = p;
    }

    public override bool Equals(object obj)
    {
        if (obj is PathMarker otherMarker)
        {
            if (location.Equals(otherMarker.location)
                && G == otherMarker.G
                && H == otherMarker.H
                && F == otherMarker.F
                && marker.Equals(otherMarker.marker)
                && parent.Equals(otherMarker.parent))
            {
                return true;
            }
        }

        return false;
        
    }
}

public class FindPathAStar : MonoBehaviour
{
    public Maze maze;
    public Material closedMaterial;
    public Material openMaterial;

    List<PathMarker> open = new List<PathMarker>();
    List<PathMarker> closed = new List<PathMarker>();

    public GameObject start;
    public GameObject end;
    public GameObject pathP;

    PathMarker goalNode;
    PathMarker startNode;

    PathMarker lastPos;
    bool done = false;

    void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");

        foreach (GameObject m in markers)
        {
            Destroy(m);
        }
    }

    void BeginSearch()
    {
        done = false;
        RemoveAllMarkers();

        List<MapLocation> locations = new List<MapLocation>();
        for(int z = 1; z < maze.depth - 1; z++)
        {
            for (int x = 1; x < maze.width - 1; x++)
            {
                if (maze.map[x, z] != 1)
                {
                    locations.Add(new MapLocation(x, z));
                }
            }
        }

        locations.Shuffle();

        Vector3 startLocation = new Vector3(locations[0].x, 0, locations[0].z) * maze.scale;
        startNode = new PathMarker(new MapLocation(locations[0].x, locations[0].z), 0f, 0f, 0f, Instantiate(start, startLocation, Quaternion.identity), null);

        Vector3 goalLocation = new Vector3(locations[1].x, 0, locations[1].z) * maze.scale;
        startNode = new PathMarker(new MapLocation(locations[1].x, locations[1].z), 0f, 0f, 0f, Instantiate(end, goalLocation, Quaternion.identity), null);

        open.Clear();
        closed.Clear();

        open.Add(startNode);
        lastPos = startNode;
    }

    void Search(PathMarker thisNode)
    {
        if (thisNode.Equals(goalNode))
        {
            // Goal found
            done = true;
            return;
        }

        foreach (MapLocation dir in maze.directions)
        {
            MapLocation neighbor = dir + thisNode.location;

            // Skip neighbor if wall
            if (maze.map[neighbor.x, neighbor.z] == 1)
            {
                continue;
            }

            // Skip neighbor if out of maze
            if (neighbor.x < 1 || neighbor.x >= maze.width || neighbor.z < 1 || neighbor.z >= maze.depth)
            {
                continue;
            }

            if (IsClosed(neighbor))
            {
                continue;
            }

            float G = Vector2.Distance(thisNode.location.ToVector(), neighbor.ToVector()) + thisNode.G;
            float H = Vector2.Distance(neighbor.ToVector(), goalNode.location.ToVector());
            float F = G + H;

            GameObject pathBlock = Instantiate(pathP, new Vector3(neighbor.x, 0, neighbor.z) * maze.scale, Quaternion.identity);
        }
    }

    bool IsClosed(MapLocation marker)
    {
        foreach (PathMarker p in closed)
        {
            if (p.location.Equals(marker))
            {
                return true;
            }
        }

        return false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BeginSearch();
        }
    }
}
