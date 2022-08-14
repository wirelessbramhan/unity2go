using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serializer : MonoBehaviour
{  // Matched variables to json Raw Data to be be passed
    public string system_response;
    public string engagement_id;
    public string customer_state;

    public string SaveToString() // Converts to json string to be passed to PostData
    {
        return JsonUtility.ToJson(this);
    }
}


