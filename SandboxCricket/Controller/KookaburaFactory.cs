using SandboxCricket.Model;

namespace SandboxCricket.Controller;

public class KookaburaFactory : CricketBatFactory
{
    public override CricketBat CreateBat()
    {
        return new Kookabura();
    }
}
