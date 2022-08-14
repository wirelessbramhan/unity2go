using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deserializer 
{   // Data types and Classes declared for handling Request deserialization 
    public bool hide_in_customer_history;
    public object registered_entities;
    public string whiteboard_template;
    public string customer_state;
    public PlaceholderAliases placeholder_aliases;
    public bool show_feedback;
    public ToStateFunction to_state_function;
    public string placeholder;
    public bool show_in_history;
    public bool overwrite_whiteboard;
    public string start_timestamp;
    public string console;
    public string name;
    public string title;
    public ResponseChannels response_channels;
    public StateOptions state_options;
    public string response_id;
    public string whiteboard_title;
    public string timestamp;
    public bool maintain_whiteboard;
    public int wait;
    public string type;
    public object options;
    public string engagement_id;

    public class Data
    {
        public List<Slideshow> Slideshow { get; set; }
    }

    public class PlaceholderAliases
    {
    }

    public class ResponseChannels
    {
        public string voice;
        public string frames { get; set; }
        public string shapes { get; set; }
    }

    public class Slideshow
    {
        public string Image { get; set; }
        public string Caption { get; set; }
    }

    public class StateOptions
    {
        public string cs_top_three { get; set; }
        public string cs_must_have { get; set; }
        public string cs_enquiry { get; set; }
        public string cs_mt1 { get; set; }
        public string cs_mt2 { get; set; }
        public string cs_mt3 { get; set; }
    }

    public class ToStateFunction
    {
        public string function { get; set; }
    }

    public static Deserializer CreateFromJSON(string jsonRequestString)
    {
        return JsonUtility.FromJson<Deserializer>(jsonRequestString);
    }
}
