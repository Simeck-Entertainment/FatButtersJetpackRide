using UnityEngine;

public class FailTextViewModel : TextViewModel<FailMenuModel>
{
    protected override string GetText()
    {
        switch (Model.FailReason)
        {
            case FailReason.OneHitKill:
                return "You are no more.\nMaybe don't touch that again!";
            case FailReason.NoHealth:
                return "Your tummy is empty!\nTry upgrading your tummy in the store!";
            case FailReason.NoFuel:
                return "You ran out of fuel!\nTry upgrading your fuel in the store!";
        }

        return "You lose!";
    }
}
