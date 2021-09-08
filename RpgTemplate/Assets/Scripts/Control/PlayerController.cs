using System;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;


namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;
        Fighter fighter;
        
        private void Awake()
        {
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
        }

        private void Update()
        {
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if (fighter.canAttack(combatTarget)){
                    if (Input.GetMouseButtonDown(0))
                        fighter.Attack(combatTarget);
                    return true;
                }
            }       
            return false;
        }

        

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit, 100);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    mover.startMoveAction(hit.point);    
                }
                return true;
            }
            return false;
        }

       

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}