using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyepatchBear : MonoBehaviour{
    [System.NonSerialized] public EyepatchBearStateMachine stateMachine; //This gets set at start.
    public EyepatchBearIdleState eyepatchBearIdleState { get; set; }
    // Start is called before the first frame update
    void Start(){
       stateMachine = GetComponent<EyepatchBearStateMachine>();
       eyepatchBearIdleState = new EyepatchBearIdleState(this, stateMachine);
       stateMachine.Initialize(eyepatchBearIdleState);
    }

    // Update is called once per frame
    void Update(){
    }
    private void OnCollisionEnter(Collision other) {
    }
}




