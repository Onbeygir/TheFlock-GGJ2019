using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput>
{
    [SerializeField] private float _raycastDistance = 10f;
    [SerializeField] private LayerMask _raycastLayerMask;


    [SerializeField] private PlayerUnit SelectedUnit;

    public void SelectUnit(PlayerUnit su)
    {
        if(SelectedUnit != null && !su.Equals(SelectedUnit))
        {
            SelectedUnit.OnDeselect();
        }
        SelectedUnit = su;
    }

    private void Update()
    {
        
        if(Input.GetMouseButtonUp(1))
        {
            if(SelectedUnit)
            {                

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, _raycastDistance, _raycastLayerMask))
                {
                    EnemyUnit temp = hit.collider.GetComponent<EnemyUnit>();
                    AIController aictrl = SelectedUnit.GetComponent<AIController>();
                    if (temp) // must be enemy
                    {
                        //aictrl.Brain.DoThinking();
                    }
                    else //must be ground
                    {
                        aictrl.TargetPosition = hit.point;                        
                    }
                }

            }
        }
    }
}
