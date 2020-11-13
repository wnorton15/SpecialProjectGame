using System.Collections;
using System.Collections.Generic;

public class RegionVariables 
{
    public int infectedTrees;
    public float timeSinceInfectedNewRegion;
    public float timeSinceSpread;
    public float timeSinceAddedMoney;
    public float timeSinceFirstInfested;
    public bool firstDonation;

    public RegionVariables(int infectedTrees, float timeSinceInfectedNewRegion, float timeSinceSpread,
        float timeSinceAddedMoney, float timeSinceFirstInfested, bool firstDonation)
    {
        this.infectedTrees = infectedTrees;
        this.timeSinceInfectedNewRegion = timeSinceInfectedNewRegion;
        this.timeSinceSpread = timeSinceSpread;
        this.timeSinceAddedMoney = timeSinceAddedMoney;
        this.timeSinceFirstInfested = timeSinceFirstInfested;
        this.firstDonation = firstDonation;
    }
}
