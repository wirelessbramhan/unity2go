using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serializer : MonoBehaviour
{
    public string system_response;
    public string engagement_id;
    public string customer_state;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}


