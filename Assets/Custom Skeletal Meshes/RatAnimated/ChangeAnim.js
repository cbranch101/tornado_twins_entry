public var currentClip = 0;
var state = 0; //0 = walk, 1 = run, 2 = idle(sniff)
var subState = 0; //0 = noSubstate, 1 = intro, 2 =, cycling 3 = outro, 4 = restart.

function Update () 
{
	var clipCount = animation.GetClipCount;
	
	if(Input.GetKeyDown(KeyCode.UpArrow))
	{
		for (var state : AnimationState in animation) 
		{
   			state.speed += 0.2;
		}
	}
	else if	(Input.GetKeyDown(KeyCode.DownArrow))
	{
		for (var state : AnimationState in animation) 
		{
   			state.speed -= 0.2;
		}
	}
	
	if(Input.GetKeyDown(KeyCode.Mouse0))
	{
			
		if((state == 0 && subState == 0))
		{
        	animation.CrossFade("walk", 0.2);
        	state = 1;
		}
		else if(state == 1 && subState == 0)
		{
        	animation.CrossFade("run", 0.2);
        	state = 2;
		}
		else if(state == 2 && subState == 0)
        {
        	subState = 1;
       		animation.CrossFade("sniffA", 0.2);
        }

        else if(state == 2 && subState == 2)
        {
        	subState = 3;
       		animation.CrossFade("sniffC", 0.2);
        }

	}
        if(state == 2 && subState == 1)
        {
        	if (!animation.isPlaying)
        	{
        		subState = 2;
        		animation.Play("sniffB");
        	}
        }
        else if(state == 2 && subState == 3)
        {
        	if (!animation.isPlaying)
        	{
        		animation.CrossFade("walk",0.2);
        		subState = 0;
        		state = 1;
        	}
        }
}