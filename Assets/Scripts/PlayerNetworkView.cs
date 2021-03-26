using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkView : MonoBehaviour
{
    public float speed = 3;
    public float smoothFactor = 3;
    Vector3 axis => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    Vector3 axisMov => axis * Time.deltaTime * speed;
    NetworkObject networkObject => GetComponent<NetworkObject>();
    Vector3 newPosition;
    Vector3 newAngle;
    Vector3 axPosition;
    void Start()
    {
        axPosition = transform.position;
        Network.When("Move", (data) => {
            if(((string)data.id).Equals(gameObject.name) && !networkObject.isMine) 
            {
                newPosition = data.position.ToObject<Vector3>();
                newAngle = data.angle.ToObject<Vector3>();
            }
        });
        StartCoroutine(EmitUpdate());
    }
    void Update()
    {
        if(networkObject.isMine) 
        {
            axPosition += axisMov;
            newPosition = axPosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if(groundPlane.Raycast(ray, out rayLength))
            {
                Vector3 pointToLook = ray.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothFactor);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newAngle, Time.deltaTime * smoothFactor);
    }
    IEnumerator EmitUpdate()
    {
        while(true)
        {
            if(networkObject.isMine) Network.Emit("Move", new {
                id = Network.playerID,
                position = axPosition.Round(2),
                angle = transform.eulerAngles
            });
            yield return null;
        }
        yield return null;
    }
    void FixedUpdate()
    {
    }
}
