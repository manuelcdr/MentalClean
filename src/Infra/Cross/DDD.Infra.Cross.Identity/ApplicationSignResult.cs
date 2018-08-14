using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Cross.Identity
{
    //public class ApplicationSignResult : SignInResult
    //{
    //    public static ApplicationSignResult Success = new ApplicationSignResult()
    //    {
    //        Succeeded = true
    //    };

    //    public static ApplicationSignResult Failed = new ApplicationSignResult()
    //    {
    //        Succeeded = false,
    //        IsNotAllowed = true
    //    };

    //    public static ApplicationSignResult LockedOut = new ApplicationSignResult()
    //    {
    //        Succeeded = false,
    //        IsNotAllowed = true
    //    };

    //    public static ApplicationSignResult NotAllowed = new ApplicationSignResult()
    //    {
    //        Succeeded = false,
    //        IsNotAllowed = true
    //    };

    //    public static ApplicationSignResult TwoFactorRequired = new ApplicationSignResult()
    //    {
    //        RequiresTwoFactor = true,
    //        Succeeded = false,
    //        IsNotAllowed = true
    //    };

    //    public static ApplicationSignResult NotAllowed_DiaDaSemanaNaoPermitido = new ApplicationSignResult()
    //    {
    //        Succeeded = false,
    //        DiaDaSemanaNaoPermitido = true
    //    };

    //    public static ApplicationSignResult NotAllowed_Inativo => new ApplicationSignResult()
    //    {
    //        Succeeded = false,
    //        Inativo = true
    //    };

    //    public bool DiaDaSemanaNaoPermitido { get; protected set; }
    //    public bool Inativo { get; protected set; }

    //    public static explicit operator ApplicationSignResult(SignInResult signInResult)
    //    {
    //        switch (signInResult)
    //        {
    //            case (SignInResult.Success):
    //                return ApplicationSignResult.Success;

    //        }
    //    }
    //}
}
