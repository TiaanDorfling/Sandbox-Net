using SandboxCricket.Model;

namespace SandboxCricket.Controller;

public class GmFactory : CricketBatFactory
{
    public override CricketBat CreateBat()
    {
        return new Gm();
    }
}
