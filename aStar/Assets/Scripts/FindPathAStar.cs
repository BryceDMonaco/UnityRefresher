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
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
