using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FernandoScript : MonoBehaviour {
    DatabaseReference reference;

   
	// Use this for initialization
	void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://demofirebasegetafe.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0);
            reference.Child("fernando/y").SetValueAsync(transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0);
            reference.Child("fernando/y").SetValueAsync(transform.position.y);

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0);
            reference.Child("fernando/x").SetValueAsync(transform.position.x);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0);
            reference.Child("fernando/x").SetValueAsync(transform.position.x);

        }
    }

}
