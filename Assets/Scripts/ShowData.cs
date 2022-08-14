using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Deserializer Deserializer;
    public Serializer Serializer;
    public Text Text;

    void Start() // Assigns values to the static string fields and Displays as Log
    {
        Serializer.system_response = "sr_init";
        Serializer.engagement_id = "NzQ3MTBjNTItNDJhNS0zZTY1LWIxZjAtMmRjMzllYmU0MmMyZXhoaWJpdF9hbGRv";
        Text.text = Serializer.SaveToString();
    }

    public void ChangeData1() // Changes customer_state value in the Request Body Raw Data
    {
        Serializer.customer_state = "cs_men_products";
        Text.text = Serializer.SaveToString();
    }

    public void ChangeData2() // Changes customer_state value in the Request Body Raw Data
    {
        Serializer.customer_state = "cs_men_explore";
        Text.text = Serializer.SaveToString();
    }

    public void ChangeData3() // Changes customer_state value in the Request Body Raw Data
    {
        Serializer.customer_state = "cs_about_collection";
        Text.text = Deserializer.placeholder;
    }
}
