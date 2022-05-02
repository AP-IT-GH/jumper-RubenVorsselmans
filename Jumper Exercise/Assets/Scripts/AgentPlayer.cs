using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System;
using Random = UnityEngine.Random;

public class AgentPlayer : Agent
{
    public float force = 3.5f;
    public GameObject Obstacle;
    public GameObject Reward;

    private Rigidbody body;
    private bool isJumping = true;

    private bool collisionWithObstacle;
    private bool collisionWithReward;
    private Transform obj;

    public float speedMultiplier;
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, force, 0), ForceMode.VelocityChange);
        }
    }
    private void FixedUpdate()
    {
        if (isJumping && transform.localPosition.y <= 0.70f)
        {
            body.AddForce(new Vector3(0, force, 0), ForceMode.VelocityChange);
            AddReward(-0.15f);
        }
            
        else
            isJumping = false;
    }

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        obj.Translate(speedMultiplier, 0, 0);
        float jumpSignal = Math.Abs(actions.ContinuousActions[0]);
        if(transform.localPosition.y<= 0.70f && jumpSignal>0.5f && !isJumping)
        {
            isJumping = true;
        }
        if (obj.localPosition.x >= 18)
        {
            if (obj.gameObject.tag == "Obstacle")
            {
                AddReward(1.0f);
            }
            if (obj.gameObject.tag == "Reward")
            {
                AddReward(-0.5f);
            }
            EndEpisode();
        }
        if (collisionWithObstacle)
        {
            AddReward(-0.5f);
            EndEpisode();
        }
        if (collisionWithReward)
        {
            AddReward(1.0f);
            EndEpisode();
        }
    }
    public override void OnEpisodeBegin()
    {
        if (obj)
        {
            Destroy(obj.gameObject);
        }
        if (Random.Range(0, 2) == 1)
            obj = Instantiate(Reward).GetComponent<Transform>();
        else
            obj = Instantiate(Obstacle).GetComponent<Transform>();

        obj.gameObject.SetActive(true);
        obj.parent = transform.parent;
        obj.localPosition = new Vector3(-24.4f, 0.8f, 47.5f);
        speedMultiplier = Random.Range(0.30f, 0.40f);
        collisionWithObstacle = false;
        collisionWithReward = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            collisionWithObstacle = true;
        }
        if (collision.gameObject.tag == "Reward")
        {
            collisionWithReward = true;
        }
    }
}
