using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Example
{
    public abstract class NonPlayerCharacterBase : CharacterBase
    {
        private NavMeshAgent characterAgent;
        private NonPlayerCharacterAgent npcAgent;

        private string treeName;

        private List<Vector3> patrolRoute;
        private int patrolRouteLength;

        private const float moveSpeed = 5f;
        private const float viewRadius = 2.5f;

        private int currentPatrolIndex = -1;
        private Vector3 nextPosition;

        public override void InitCharacter()
        {
            base.InitCharacter();
            characterAgent = gameObject.GetComponent<NavMeshAgent>();
            characterAgent.speed = moveSpeed;
            characterAgent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
            characterAgent.angularSpeed = 4000;

            currentPatrolIndex = -1;

            InitAgent();

            InitCharacterAgent();
        }

        private void InitAgent()
        {
            treeName = "AiMonster";
        }

        private void InitCharacterAgent()
        {
            if(null == characterAgent)
            {
                throw new System.Exception("characterAgent is not initialized");
            }

            if(string.IsNullOrEmpty(treeName))
            {
                throw new System.Exception("set the tree name first");
            }

            npcAgent = new NonPlayerCharacterAgent();
            npcAgent.InitAgent(this);

            if(npcAgent.btload(treeName))
            {
                npcAgent.btsetcurrent(treeName);
            }
        }

        public void StartMove()
        {
            if(null != npcAgent)
            {
                npcAgent.btexec();
            }
        }

        public void AddPatrolRoute(List<Vector3> route)
        {
            patrolRoute = route ?? throw new System.ArgumentNullException(nameof(route));

            patrolRouteLength = patrolRoute.Count;
        }

        public void MoveToNext()
        {
            if(patrolRouteLength <= 0)
            {
                return;
            }

            currentPatrolIndex = (currentPatrolIndex + 1) % patrolRouteLength;
            nextPosition = patrolRoute[currentPatrolIndex];
            characterAgent.SetDestination(nextPosition);
        }

        /// <summary>
        /// 检查是否到达目的地
        /// </summary>
        public bool ArrivedAtTarget()
        {
            // 初始情况下直接判定已经到达目的地
            if(currentPatrolIndex <= 0)
            {
                return true;
            }

            return Vector3.Distance(transform.position, nextPosition) <= 0.01f;
        }

        public bool CheckTargetAround(bool checkPlayer, out GameObject player)
        {
            if(!checkPlayer)
            {
                player = null;
                return false;
            }

            //var targets = Physics.OverlapSphere(transform.position, viewRadius, )
            Collider[] colliders = new Collider[10];
            var colliderCount = Physics.OverlapSphereNonAlloc(transform.position, viewRadius, colliders, LayerMask.GetMask("Player"));
            if(colliderCount > 0)
            {
                player = colliders[0].gameObject;
                return true;
            }

            player = null;
            return false;
        }

        private Vector3 targetPosition;
        private bool startMove = false;

        public void MoveToPosition(Vector3 position)
        {
            targetPosition = position;
            characterAgent.SetDestination(targetPosition);
            startMove = true;
        }

        public bool CheckArrivedTargetPosition()
        {
            if(!startMove)
            {
                return false;
            }

            return Vector3.Distance(transform.position, targetPosition) <= 0.01f;
        }
    }
}
