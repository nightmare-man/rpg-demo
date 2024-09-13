using System.Collections;
using System.Collections.Generic;


using UnityEngine;


public class player : entity
{

    [Header("attack movement")]
    public float[] attackMovement;
    public bool isBusy { get; private set; }

    [Header("move info")]
    public float moveSpeed = 8.0f;
    public float jumpForce = 8.0f;
    

    [Header("dash info")]
    public float dashTime = 0.3f;
    public float dashSpeed = 18.0f;
    public float dashDir = 1.0f;
   

    [Header("counter attack info")]
    public float counterAttackDuration = 0.2f;
    public GameObject sword;
    #region states
    public playerStateMachine stateMachine { get; private set; }
    public playerStateIdle playerIdle { get; private set; }
    public playerStateMove playerMove { get; private set; }
    public playerStateJump playerJump { get; private set; }
    public playerStateAir playerAir { get; private set; }
    public playerStateDash playerDash { get; private set; }
    public playerStateWallSlide playerWallSlide { get; private set; }
    public playerStateWallJump playerWallJump { get; private set; }
    public playerStatePrimaryAttack playerPrimaryAttack { get; private set; }
    public playerStateCounterAttack playerCounterAttack { get; private set; }
    public playerStateAimSword playerAimSword { get; private set; }
    public playerStateCatchSword playerCatchSword { get; private set; }
    #endregion

    

    
    protected override void Awake()
    {
        base.Awake();
        stateMachine=new playerStateMachine();
        playerIdle  = new playerStateIdle(stateMachine,this,"playerIdle");
        playerMove  = new playerStateMove(stateMachine, this, "playerMove");
        playerJump  = new playerStateJump(stateMachine, this, "playerJump");
        playerAir   = new playerStateAir(stateMachine, this, "playerJump");
        playerDash  = new playerStateDash(stateMachine, this, "playerDash");
        playerWallSlide = new playerStateWallSlide(stateMachine, this, "playerWallSlide");
        playerWallJump = new playerStateWallJump(stateMachine, this, "playerJump");
        playerPrimaryAttack = new playerStatePrimaryAttack(stateMachine, this, "playerAttack");
        playerCounterAttack = new playerStateCounterAttack(stateMachine, this, "playerCounterAttack");
        playerAimSword = new playerStateAimSword(stateMachine, this, "playerAimSword");
        playerCatchSword = new playerStateCatchSword(stateMachine, this, "playerCatchSword");
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stateMachine.initialize(playerIdle);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.update();
        //放在这儿确保任何时候都能dash
        dashInputCheck();

    }
    public void assignSword(GameObject _sword)
    {
        sword = _sword;
    }
    public void clearSword()
    {
        Debug.Log("change to catch");
        stateMachine.changeState(playerCatchSword);
        Destroy(sword);
    }
    private void dashInputCheck()
    {
        if (isWallDetected())
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && skillManager.instance.dashSkill.attemptToUse())
        {
            //实现dash瞬间能够修改方向
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = faceDir;
            //这里不需要因为dash方向和face方向不同而手动flip
            //因为dash的update里调用了setVelocity
            stateMachine.changeState(playerDash);
            
        }
    }
    public IEnumerator busyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }
   
   
    
    public void AnimationTrigger() => stateMachine.currentState.animatorFinishTrigger();
}
