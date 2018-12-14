using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class EnriqueScript : MonoBehaviour
{
    DatabaseReference reference;


    // Use this for initialization
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://demofirebasegetafe.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("enrique").ValueChanged += Mover;
    }



    void Mover(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        IEnumerable<DataSnapshot> posiciones = args.Snapshot.Children;
        foreach (var coordenada in posiciones)
        {
            if (coordenada.Key.ToString() == "x")
            {
                transform.position = new Vector3(int.Parse(coordenada.Value.ToString()), transform.position.y);
            }
            else if (coordenada.Key.ToString() == "y")
            {
                transform.position = new Vector3(transform.position.x, int.Parse(coordenada.Value.ToString()));
            }
        }

    }

}
