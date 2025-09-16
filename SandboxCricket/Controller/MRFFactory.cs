using SandboxCricket.Model;

namespace SandboxCricket.Controller;

public class MRFFactory : CricketBatFactory
{
    public override CricketBat CreateBat()
    {
        return new MRF();
    }
}
