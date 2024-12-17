using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectsKeys
{
    public static readonly Dictionary<string, string> Items = new Dictionary<string, string>
    {
        { "Tap", "Tap" },
        { "BottleHolder", "BottleHolder" },
        { "Bottle", "Bottle" },
    };

    public static string GetValue(string id)
    {
        if(Items.TryGetValue(id, out string itemId))
        {
            return itemId;
        }

        return null;
    }
}
