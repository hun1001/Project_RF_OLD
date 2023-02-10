using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Skill : Base.CustomComponent<Tank>
    {
        private bool _isSkill = false;

        protected override void Assignment()
        {
            
        }
        
        public void Skill()
        {
            _isSkill = true;
        }

        private void Update()
        {
            if (_isSkill && Input.GetMouseButtonDown(0))
            {
                _isSkill = false;
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    Debug.Log(hit.transform);
                }
            }
        }
    }
}
