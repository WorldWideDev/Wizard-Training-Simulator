using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMagic : MonoBehaviour {

    public float castRange = 20f;
    public int numEntitesForSkillUpgrade = 5;
    public Mesh alteredMesh;

    int abilityRating = 0;
    int entitiesAltered = 0;

    Camera cam;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttemptMagic();
        }

        
    }

    void AttemptMagic()
    {
        RaycastHit hit;
        Vector3 origin = cam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(origin, cam.transform.forward, out hit, castRange))
        {
            Entity entity = hit.collider.GetComponent<Entity>();

            //make sure we got an Entity
            if(entity != null)
            {
                // check if we possess the skill required
                if (entity.numRating <= abilityRating)
                {
                    MeshFilter eMesh = entity.GetComponent<MeshFilter>();
                    eMesh.mesh = alteredMesh;
                    entitiesAltered++;
                    UpdatePlayerStatus();
                }
            }
            
        }
        // dray raw
        Debug.DrawRay(origin, cam.transform.forward * castRange, Color.green);
    }

    void UpdatePlayerStatus()
    {
        if(entitiesAltered == numEntitesForSkillUpgrade)
        {
            abilityRating++;
            entitiesAltered = 0;
        }
    }
}
