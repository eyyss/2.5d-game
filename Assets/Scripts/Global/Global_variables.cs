using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global_variables
{

    static Global_variables()
    {
        

    }
    public static int state;
    /*
    0-walk
    1-climb
    2-jump
     
     */
    public static void state_Update(int x)
    {
        state = x;
    }
}
