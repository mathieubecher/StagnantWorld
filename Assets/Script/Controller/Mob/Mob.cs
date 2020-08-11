using System.Collections;
using System.Collections.Generic;
using StateMob;
using UnityEngine;

public class Mob : AbstractController
{
    [Range(0,100)] public float life = 100;
    
    [SerializeField] public DetectGestor detect;
    [HideInInspector] public AbstractController target;
    public StateMob.Abstract state;

    private Vector3 beginPos;
    private Quaternion beginRotate;
    
    protected override void Awake()
    {
        beginPos = transform.position;
        beginRotate = transform.rotation;
        
        base.Awake();
        state = new Iddle(this);
    }

    void Update()
    {
        state.Update();
    }
    
    public override void Hit(Controller origin, float damage)
    {
        life -= damage;
        state.FollowState(origin);
        if (life <= 0) Destroy(gameObject);
        state.HitState(origin, damage);
    }
}

namespace StateMob
{
    public abstract class Abstract
    {
        protected Mob _controller;
        public Abstract(Mob controller)
        {
            _controller = controller;
        }
        public virtual void Update()
        {
            //TODO déplacement naturel
        }
        public virtual void Exit(){}

        protected virtual void IddleState()
        {
            _controller.state = new Iddle(_controller);
        }

        public virtual void FollowState(AbstractController target)
        {
            _controller.state = new Follow(_controller, target);
        }

        public virtual void HitState(Controller origin, float damage)
        {
            _controller.state = new Hit(_controller,origin,damage,this);
        }
        
    }
    
    public class Iddle : Abstract
    {
        public Iddle(Mob controller):base(controller)
        {
           
        }

        public override void Update()
        {
            base.Update();
            float y = _controller.rigidbody.velocity.y;
            _controller.rigidbody.velocity = new Vector3(0,y,0);
            if (_controller.detect.DetectNear(out AbstractController target, _controller.type))
            {
                FollowState(target);
            }
        }
    }

    public class Follow : Abstract
    {
        private AbstractController _target;
        public Follow(Mob controller, AbstractController target):base(controller)
        {
            _target = target;
        }

        public override void Update()
        {
            base.Update();
            if (_target == null || (_target.transform.position - _controller.transform.position).magnitude > _controller.detect.abandonRadius)
            {
                _controller.state = new Iddle(_controller);
                return;
            }
            
            Vector3 velocity = _controller.rigidbody.velocity;
            velocity.y = 0;
            velocity += (_target.transform.position - _controller.transform.position).normalized * 0.2f;
            if (velocity.magnitude > _controller.speed) velocity *= _controller.speed / velocity.magnitude;
            _controller.character.SetDirection(velocity);
            velocity.y = _controller.rigidbody.velocity.y;
            _controller.rigidbody.velocity = velocity;
        }
    }
    
    public class Hit : Abstract
    {
        private Abstract _last;
        private float timer;
        public Hit(Mob controller, AbstractController origin, float damage, Abstract last):base(controller)
        {
            _last = last;
            timer = damage/10;
            
            float y = _controller.rigidbody.velocity.y;
            _controller.rigidbody.velocity = new Vector3(0,y,0);
            
            Vector3 direction = _controller.transform.position - origin.transform.position;
            direction.y = 0;
            direction.Normalize();
            _controller.rigidbody.AddForce(direction * damage/2,ForceMode.Impulse);
        }

        public override void Update()
        {
            base.Update();
            timer -= Time.deltaTime;
            if (timer < 0) Exit();
        }

        public override void Exit()
        {
            _controller.state = _last;
        }
        
        protected override void IddleState() { }
        public override void FollowState(AbstractController target) { }
    }
}